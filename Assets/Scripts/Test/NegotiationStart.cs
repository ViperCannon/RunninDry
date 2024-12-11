using UnityEngine;

public class NegotiationStart : MonoBehaviour
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

        handManager.AttemptDraw(3);

        transform.parent.parent.gameObject.SetActive(false);
    }
}
