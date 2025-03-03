using Ink.Runtime;
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

    public bool inNegotiation = false;

    bool firstLoad = true;

    int diplomacyDifficulty = 12;
    int intimidationDifficulty = 12;
    int briberyDifficulty = 12;

    public HandManager handManager;
    public Canvas combatCanvas;


    private void OnEnable()
    {
        inNegotiation = true;
        
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
        DialogueManager.GetInstance().UpdateInkDialogueVariable("negotiationSuccess", (Ink.Runtime.Object) new BoolValue(true));
        success.SetActive(true);
        EndNegotiation();
    }
    public void Fail()
    {
        DialogueManager.GetInstance().UpdateInkDialogueVariable("negotiationSuccess", (Ink.Runtime.Object) new BoolValue(false));
        fail.SetActive(true);
        EndNegotiation();
    }

    public void EndNegotiation()
    {
        inNegotiation = false;
        
        deckManager.inNegotiation = false;
        handManager.DiscardHand();
        deckSystem.SetActive(false);

        Debug.Log("Negotiation Ended.");
        gameObject.SetActive(false);
    }
}
