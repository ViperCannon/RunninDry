using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpeakeasyStreet;

public class CombatManager : MonoBehaviour
{
    public enum CombatPhase
    {
        PlayerTurn,
        EnemyTurn
    }

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

    [Header("Misc. Other Properties")]
    [SerializeField]
    EnemyInstance[] enemyTypes;

    [Header("Misc. Other Properties")]
    [SerializeField]
    CombatPhase currentPhase;

    [SerializeField]
    DeckManager deckManager;
    [SerializeField]
    GameManager gameManager;
    [SerializeField]
    Canvas combatCanvas;
    [SerializeField]
    CapsHolder capsHolder;

    GameObject car;
    bool hasEndedTurn = false;

    public HandManager handManager;

    public int capsRefreshLimit;
    public int currentCaps;

    public Card lastPlayedCard;

    float zoomInSize = 5f;
    float zoomOutSize = 10f;
    float zoomSpeed = 2f;

    // Method to start combat and initialize variables
    public void OnEnable()
    {
        car = GameObject.FindWithTag("car");

        if(car != null)
            car.SetActive(false);

        foreach(Transform child in combatCanvas.transform)
        {
            child.gameObject.SetActive(true);
        }

        /*
        if(Enemies.Count > 0)
        {
            Enemies.Clear();
        }

        foreach(GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            Enemies.Add(enemy.GetComponent<EnemyInstance>());
        }
        */

        deckManager.inCombat = true;
        deckManager.PopulateDecks();
        deckManager.UpdateCounters();

        Debug.Log("Combat Instance Started");

        currentPhase = CombatPhase.PlayerTurn;

        currentCaps = 0;
        capsRefreshLimit = 0;

        foreach(AllyInstance p in Allies)
        {
            if (p != null)
            {
                p.gameObject.SetActive(true);
                capsRefreshLimit += p.caps;
            }          
        }

        foreach (EnemyInstance e in Enemies)
        {
            if(e != null)
            {
                e.gameObject.SetActive(true);
            }
            
        }

        StartCoroutine(ZoomCamera(zoomOutSize));

        StartCoroutine(HandleCombatTurns());
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

    void EndCombat()
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

        if (car != null)
            car.SetActive(true);

        deckManager.inCombat = false;

        gameManager.endEncounter();

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
            EnemyInstance newEnemyInstance = enemyTypes[Random.Range(0, enemyTypes.Length)];

            // Allocate the new enemy it to Enemies!
            Enemies.Add(newEnemyInstance);
        }
    }

    public void GenerateSetCombat(EnemyInstance[] E)
    {
        Enemies.Clear();

        foreach (EnemyInstance enemy in E)
        {
            Enemies.Add(enemy);
        }
    }

    public void StartCombat()
    {

        for (int i = 0; i < Allies.Count; i++)
        {
            // Have ally spawn at EnemySpawnPositions[i]!
            GameObject currentAlly = Instantiate(GetCharacterPrefab(Allies[i].AllyName) as GameObject, PlayerSpawnPoints[i], new Quaternion());
        }
        
        for (int i = 0; i < Enemies.Count; i++)
        {
            // Have enemy spawn at EnemySpawnPositions[i]!
            GameObject currentEnemy = Instantiate(GetCharacterPrefab(Enemies[i].EnemyName) as GameObject, EnemySpawnPoints[i], new Quaternion());
        }
        return;
    }

    private GameObject GetCharacterPrefab(string characterName)
    {
        return Resources.Load<GameObject>("CharacterPrefabs/" + characterName);
    }
}
