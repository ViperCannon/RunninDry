using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NegotiationManager : MonoBehaviour
{
    [SerializeField]
    DeckManager deckManager;
    [SerializeField]
    GameManager gameManager;
    [SerializeField]
    GameObject success;
    [SerializeField]
    GameObject fail;

    public HandManager handManager;
    public Canvas combatCanvas;

    private void OnEnable()
    {  
        deckManager.inNegotiation = true;
        deckManager.PopulateDecks();
        deckManager.UpdateCounters();
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
        combatCanvas.transform.GetChild(0).gameObject.SetActive(false);
        gameManager.endEncounter();

        Debug.Log("Negotiation Ended.");
        gameObject.SetActive(false);
    }
}
