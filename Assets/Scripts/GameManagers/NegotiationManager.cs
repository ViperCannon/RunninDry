using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NegotiationManager : MonoBehaviour
{
    public static NegotiationManager Instance { get; private set; }

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

        firstLoad = false;

        gameObject.SetActive(false);
    }

    GameManager gameManager;

    [SerializeField]
    GameObject deckSystem;
    [SerializeField]
    DeckManager deckManager;
    [SerializeField]
    GameObject success;
    [SerializeField]
    GameObject fail;

    bool firstLoad = true;
    int diplomacyDifficulty = 12;
    int intimidationDifficulty = 12;
    int briberyDifficulty = 12;

    public HandManager handManager;
    public Canvas combatCanvas;


    private void OnEnable()
    {
        if(gameManager == null)
        {
            gameManager = GameManager.Instance;
        }

        if (!firstLoad)
        {
            deckSystem.SetActive(true);

            deckManager.inNegotiation = true;
            deckManager.PopulateDecks();
            deckManager.UpdateCounters();

            handManager.AttemptDraw(3);
        } 
    }

    public void SetDiplomacyDifficulty(int d)
    {
        diplomacyDifficulty = d;
    }

    public int GetDiplomacyDifficulty()
    {
        return diplomacyDifficulty;
    }

    public void SetIntimidationDifficulty(int i)
    {
        intimidationDifficulty = i;
    }

    public int GetIntimidationDifficulty()
    {
        return intimidationDifficulty;
    }

    public void SetBriberyDifficulty(int b)
    {
        briberyDifficulty = b;
    }

    public int GetBriberyDifficulty()
    {
        return briberyDifficulty;
    }

    public void Success()
    {
        success.SetActive(true);
    }
    public void Fail()
    {
        fail.SetActive(true);
    }

    public void EndNegotiation()
    {
        deckManager.inNegotiation = false;
        handManager.DiscardHand();
        deckManager.gameObject.GetComponentInParent<Transform>().gameObject.SetActive(false);
        //gameManager.EndEncounter();

        Debug.Log("Negotiation Ended.");
        gameObject.SetActive(false);
    }
}
