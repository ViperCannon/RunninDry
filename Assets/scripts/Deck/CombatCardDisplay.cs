using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CombatCardDisplay : CardDisplay
{
    new public CombatCard cardData;

    public Image[] cost;

    public int currentDamage;
    public int currentSecondaryDamage;
    public int currentHeal;
    public int currentSecondaryHeal;

    public int unload = -1; //used to keep track of how many caps an unload card uses. Default to -1 if card is not an unload card.

    new public void UpdateCardDisplay()
    {
        nameText.text = cardData.cardName;

        characterFlair[(int)cardData.character].gameObject.SetActive(true);

        if (cardData.subTypes.Contains(CombatCard.CombatSubType.Unload))
        {
            cost[5].gameObject.SetActive(true);
        }
        else
        {
            cost[cardData.cost].gameObject.SetActive(true);
        }

        descText.text = cardData.cardDescription;
    }
}
