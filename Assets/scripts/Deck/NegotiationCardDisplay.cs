using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NegotiationCardDisplay : CardDisplay
{
    new public NegotiationCard cardData;

    public Image[] type;

    public int cost; //mainly for bribery cards

    new public void UpdateCardDisplay()
    {
        nameText.text = cardData.cardName;

        characterFlair[(int)cardData.character].gameObject.SetActive(true);

        type[(int)cardData.subTypes[0]].gameObject.SetActive(true);

        descText.text = cardData.cardDescription;
    }
}
