using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CombatCardDisplay : CardDisplay
{
    public CombatCard cardData;

    public GameObject character; //character reference for who the card belongs to

    public Image[] cost;

    public int currentDamage;
    public int currentSelfDamage;
    public int currentHeal;
    public int currentSelfHeal;

    public int unload = -1; //used to keep track of how many caps an unload card uses. Default to -1 if card is not an unload card.

    public void UpdateCardDisplay()
    {
        currentDamage = cardData.damage;
        currentSelfDamage = cardData.selfDamage;
        currentHeal = cardData.heal;
        currentSelfHeal = cardData.secondaryHeal;

        if (character == null)
        {
            AllyInstance[] allies = FindObjectsOfType<AllyInstance>();

            foreach(AllyInstance ally in allies)
            {
                if(cardData.character.ToString() + "(Clone)" == ally.gameObject.name)
                {
                    character = ally.gameObject;
                }
            } 
        }

        cardImage.sprite = cardData.cardArt;

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
