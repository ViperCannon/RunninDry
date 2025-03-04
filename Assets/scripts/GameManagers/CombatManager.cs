using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpeakeasyStreet;
using System.Linq;

public class CombatManager : MonoBehaviour
{
    public static CombatManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }

        SfxAudioSource = GameObject.Find("SFX").GetComponent<AudioSource>();
        CombatStartSfx = Resources.Load<AudioClip>("SFX/FightStartBell");

        firstLoad = false;

        gameObject.SetActive(false);
    }

    public enum CombatPhase
    {
        PlayerTurn,
        EnemyTurn
    }

    [Header("Combat Participant Data")]
    public List<AllyData> AlliesData;
    public List<EnemyData> EnemiesData;

    [Header("Combat Participant Instances")]
    public List<AllyInstance> Allies;
    public List<EnemyInstance> Enemies;

    [Header("Combat Participant Spawn Points")]
    [SerializeField]
    Vector2[] PlayerSpawnPoints = new Vector2[]
    {
        new Vector2( -4.5f, -2.5f ),
        new Vector2( -9, -2 ),
        new Vector2( -13.5f, -2.5f )
    };
    [SerializeField]
    Vector2[] EnemySpawnPoints = new Vector2[]
    {
        new Vector2( 5.5f, -2.5f ),
        new Vector2( 9, -2 ),
        new Vector2( 12.5f, -2.5f ),
        new Vector2( 16, -2 ),
        new Vector2( 2, -2 ),
    };

    [Header("List of Generic Enemy Types")]
    [SerializeField]
    List<EnemyData> enemyTypes;

    [Header("Misc. Other Properties")]
    [SerializeField]
    CombatPhase currentPhase;

    [SerializeField]
    DeckManager deckManager;
    [SerializeField]
    Canvas combatCanvas;
    [SerializeField]
    CapsHolder capsHolder;

    AudioSource SfxAudioSource;
    AudioClip CombatStartSfx;

    public bool inCombat = false;

    bool firstLoad = true;
    bool hasEndedTurn = false;

    public HandManager handManager;

    public int capsRefreshLimit;
    public int currentCaps;

    public Card lastPlayedCard;

    private float zoomInSize = 5f;
    private float zoomOutSize = 10f;
    private float zoomSpeed = 2f;

    // Method to start combat and initialize Variables
    public void OnEnable()
    {
        if (!firstLoad)
        {
            if (GameManager.Instance != null)
            {
                GameManager.Instance.CarMoveOut();
            }

            foreach (Transform child in combatCanvas.transform)
            {
                child.gameObject.SetActive(true);
            }

            SpawnCombatants();

            inCombat = true;
            deckManager.inCombat = true;
            deckManager.PopulateDecks();
            deckManager.UpdateCounters();

            Debug.Log("Combat Instance Started");

            currentPhase = CombatPhase.PlayerTurn;

            currentCaps = 0;
            capsRefreshLimit = 0;

            foreach (AllyInstance p in Allies)
            {
                if (p != null)
                {
                    p.gameObject.SetActive(true);
                    capsRefreshLimit += p.caps;
                }
            }

            foreach (EnemyInstance e in Enemies)
            {
                if (e != null)
                {
                    e.gameObject.SetActive(true);
                }

            }

            SfxAudioSource.PlayOneShot(CombatStartSfx);
            StartCoroutine(ZoomCamera(zoomOutSize));
            StartCoroutine(HandleCombatTurns());
        } 
    }

    IEnumerator ZoomCamera(float targetSize)
    {
        float startSize = Camera.main.orthographicSize;
        float timeElapsed = 0f;

        while (timeElapsed < 1f)
        {
            Camera.main.orthographicSize = Mathf.Lerp(startSize, targetSize, timeElapsed);
            timeElapsed += Time.deltaTime * zoomSpeed;
            yield return null;
        }

        Camera.main.orthographicSize = targetSize; // Ensure final size is exactly the target

        if(targetSize == zoomInSize)
        {
            gameObject.SetActive(false);
        }
    }

    // Method to handle the turn-based combat flow
    IEnumerator HandleCombatTurns()
    {
        while (!IsCombatOver())
        {
            if (currentPhase == CombatPhase.PlayerTurn)
            {
                Debug.Log("Start Player Turn.");

                // Wait for the player(s) to finish their turn
                yield return StartCoroutine(HandlePlayerTurn());

                if (!IsCombatOver())
                {
                    // Transition to enemy turn
                    currentPhase = CombatPhase.EnemyTurn;
                }
                
            }
            else if (currentPhase == CombatPhase.EnemyTurn)
            {
                Debug.Log("Start Enemy Turn.");

                // Handle Enemies' turn actions
                yield return StartCoroutine(HandleEnemyTurn());
                if (!IsCombatOver())
                {
                    // Transition back to player turn
                    currentPhase = CombatPhase.PlayerTurn;
                }     
            }
        }

        EndCombat();
    }

    // Method to handle player turns
    IEnumerator HandlePlayerTurn()
    {
        hasEndedTurn = false;

        yield return new WaitForEndOfFrame();

        Debug.Log(capsRefreshLimit - currentCaps);

        UpdateCaps(capsRefreshLimit - currentCaps);

        // Handle player actions (drawing cards, playing cards, etc.)
        handManager.AttemptDraw(6);

        while (!hasEndedTurn && !IsCombatOver())
        {
            // Wait until the player decides to end their turn
            yield return null;
        }

        handManager.DiscardHand();
    }

    // Method to handle enemy turns
    IEnumerator HandleEnemyTurn()
    {
        foreach (EnemyInstance e in Enemies)
        {
            if(e != null && e.gameObject.activeSelf)
            {
                e.PerformAction(); // Let each enemy perform its action
                yield return new WaitForSeconds(1f); // Wait for a short period between actions
            }     
        }
    }

    public void UpdateCaps(int c)
    {
        if(c > 0)
        {
            for(int caps = currentCaps; caps < capsHolder.caps.Length && c > 0; caps++)
            {

                capsHolder.caps[caps].SetActive(true);

                currentCaps++;
                c--;
            }
        }
        else
        {
            for (int caps = currentCaps - 1; caps > -1 && c < 0; caps--)
            {

                capsHolder.caps[caps].SetActive(false);

                currentCaps--;
                c++;
            }
        }
    }

    public void EndTurn()
    {
        Debug.Log("Player Turn Ended");
        hasEndedTurn = true;
    }

    bool IsCombatOver()
    {
        bool over = false;

        foreach(AllyInstance p in Allies)
        {
            if (p != null && p.isDowned)
            {
                over = true;
            }
            else
            {
                over = false;
                break;
            }
        }

        if (!over)
        {
            foreach (EnemyInstance e in Enemies)
            {
                if (e == null || (e != null && !e.gameObject.activeSelf))
                {
                    over = true;
                }
                else
                {
                    over = false;
                    break;
                }
            }
        }

        // Check if the game has ended (all Enemies defeated or all PlayerAllyInstances dead)
        return over;
    }

    public void EndCombat()
    {

        foreach (Transform child in combatCanvas.transform)
        {
            child.gameObject.SetActive(false);
        }

        foreach (AllyInstance p in Allies)
        {
            if (p != null)
            {
                p.gameObject.SetActive(false);
            }
        }

        foreach (EnemyInstance e in Enemies)
        {
            if (e != null)
            {
                e.gameObject.SetActive(false);
            }
        }

        EnemiesData.Clear();

        if (GameManager.Instance != null)
        {
            inCombat = false;
            deckManager.inCombat = false;
            GameManager.Instance.EndEncounter();
        } 

        StartCoroutine(ZoomCamera(zoomInSize));

        Debug.Log("Combat Ended.");

        // Handle the end of combat (e.g., show results, transition to the next scene, etc.)
        
    }

    public void GenerateRandomCombat()
    {
        Enemies.Clear();
        
        for (int i = 0; i < Random.Range(1, 5); i++)
        {
            // Pick a random non-boss enemy type! 
            EnemyData currentEnemy = enemyTypes[Random.Range(0, enemyTypes.Count)];

            // Allocate the new enemy it to Enemies!
            EnemiesData.Add(currentEnemy);
        }
    }

    public void GenerateSetCombat(EnemyData[] E)
    {
        EnemiesData.Clear();

        foreach (EnemyData enemy in E)
        {
            EnemiesData.Add(enemy);
        }
    }

    public void SpawnCombatants()
    {
        
        if (!Allies.Any())
        {
            Debug.Log("Populating the ally list and spawning them!");
            for (int i = 0; i < AlliesData.Count; i++)
            {
                GameObject currentAlly = Instantiate(GetCharacterPrefab(AlliesData[i].AllyName) as GameObject, PlayerSpawnPoints[i], new Quaternion());
                Allies.Add(currentAlly.GetComponent<AllyInstance>());

            }
        }
        else
        {
            Debug.Log("Ally list is already populated! Setting allies to active!");
            foreach (AllyInstance Ally in Allies)
            {
                Ally.gameObject.SetActive(true);
            }
        }

        Enemies.Clear();

        Debug.Log("Populating the enemy list and spawning them!");
        for (int i = 0; i < EnemiesData.Count; i++)
        {
            GameObject currentEnemy = Instantiate(GetCharacterPrefab(EnemiesData[i].EnemyName) as GameObject, EnemySpawnPoints[i], new Quaternion());
            Enemies.Add(currentEnemy.GetComponent<EnemyInstance>());
        }
        return;
    }

    private GameObject GetCharacterPrefab(string characterName)
    {
        return Resources.Load<GameObject>("CharacterPrefabs/" + characterName);
    }
}
