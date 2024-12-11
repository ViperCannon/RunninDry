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

    public List<AllyInstance> players;
    public List<EnemyInstance> enemies;

    public int capsRefreshLimit;
    public int currentCaps;

    public Card lastPlayedCard;

    float zoomInSize = 5f;
    float zoomOutSize = 10f;
    float zoomSpeed = 2f;


    // Method to start combat and initialize variables
    public void Start()
    {
        car = GameObject.FindWithTag("car");

        if(car != null)
            car.SetActive(false);

        foreach(Transform child in combatCanvas.transform)
        {
            child.gameObject.SetActive(true);
        }

        Debug.Log("Combat Instance Started");

        currentPhase = CombatPhase.PlayerTurn;

        currentCaps = 0;
        capsRefreshLimit = 0;

        foreach(AllyInstance p in players)
        {
            if (p != null)
            {
                p.gameObject.SetActive(true);
                capsRefreshLimit += p.caps;
            }          
        }

        foreach (EnemyInstance e in enemies)
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

                // Transition to enemy turn
                currentPhase = CombatPhase.EnemyTurn;
            }
            else if (currentPhase == CombatPhase.EnemyTurn)
            {
                Debug.Log("Start Enemy Turn.");

                // Handle enemies' turn actions
                yield return StartCoroutine(HandleEnemyTurn());

                // Transition back to player turn
                currentPhase = CombatPhase.PlayerTurn;
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

        while (!hasEndedTurn)
        {
            // Wait until the player decides to end their turn
            yield return null;
        }

        handManager.DiscardHand();
    }

    // Method to handle enemy turns
    IEnumerator HandleEnemyTurn()
    {
        foreach (EnemyInstance e in enemies)
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

        foreach(AllyInstance p in players)
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
            foreach (EnemyInstance e in enemies)
            {
                if (e != null && !e.gameObject.activeSelf)
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

        // Check if the game has ended (all enemies defeated or all players dead)
        return over;
    }

    void EndCombat()
    {
        StartCoroutine(ZoomCamera(zoomInSize));
        combatCanvas.gameObject.SetActive(false);

        foreach (AllyInstance p in players)
        {
            if (p != null)
            {
                p.gameObject.SetActive(false);
            }
        }

        if (car != null)
            car.SetActive(true);

        Debug.Log("Combat Ended.");
        // Handle the end of combat (e.g., show results, transition to the next scene, etc.)
    }
}
