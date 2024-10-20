using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using SpeakeasyStreet;

public class CardDisplay : MonoBehaviour
{
    public Card cardData;

    public Image cardImage;
    public TMP_Text nameText;
    public TMP_Text costText;
    public TMP_Text dmgText;
    public Image[] type;

    void Start()
    {
        UpdateCardDisplay();
    }

    public void UpdateCardDisplay()
    {
        nameText.text = cardData.cardName;
        costText.text = cardData.cost.ToString();
        dmgText.text = cardData.damage.ToString();

        if(cardData.cardType is Card.CardType.Negotiation)
        {
            type[1].gameObject.SetActive(false);
        }
        else
        {
            type[0].gameObject.SetActive(false);
        }
    }
}
