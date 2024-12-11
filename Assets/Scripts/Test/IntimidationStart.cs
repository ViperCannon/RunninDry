using UnityEngine;
using SpeakeasyStreet;

public class IntimidationStart: MonoBehaviour
{
    public GameObject nManager;
    public DeckManager deckManager;
    public HandManager handManager;
    public Canvas combatCanvas;

    public void onClick()
    {
        nManager.SetActive(true);

        combatCanvas.transform.GetChild(0).gameObject.SetActive(true);

        deckManager.inNegotiation = true;

        Card[] deck = Resources.LoadAll<NegotiationCard>("CardData/Tutorial/Intimidation");

        deckManager.negotiationDeck.Set(deck);

        handManager.AttemptDraw(1);

        transform.parent.parent.gameObject.SetActive(false);
    }
}
