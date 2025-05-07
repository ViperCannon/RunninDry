using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CombatCardDisplay : CardDisplay
{
    public CombatCard cardData;

    public GameObject character; //character reference for who the card belongs to

    public Image[] cost;

    public int currentDamage;
    public string currentSecondaryDamage;
    public string currentSelfDamage;
    public string currentHeal;
    public string currentSelfHeal;

    public int unload = -1; //used to keep track of how many caps an unload card uses. Default to -1 if card is not an unload card.

    string newDesc;

    public void UpdateCardDisplay()
    {
        currentSecondaryDamage = (cardData.secondaryDamage).ToString();
        currentSelfDamage = (cardData.selfDamage).ToString();
        currentHeal = (cardData.heal).ToString();
        currentSelfHeal = (cardData.secondaryHeal).ToString();

        if (CombatManager.Instance != null && CombatManager.Instance.inCombat && character == null)
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
        if(CombatManager.Instance != null && CombatManager.Instance.inCombat)
        {
            currentDamage = UpdateDamage();
        }
        else
        {
            currentDamage = cardData.damage;
        }
        

        cardImage.sprite = cardData.cardArt;

        nameText.text = cardData.cardName;

        characterFlair[(int)cardData.character - 1].gameObject.SetActive(true);

        if (cardData.subTypes.Contains(CombatCard.CombatSubType.Unload))
        {
            cost[5].gameObject.SetActive(true);
        }
        else
        {
            cost[cardData.cost].gameObject.SetActive(true);
        }

        newDesc = cardData.cardDescription;

        newDesc = newDesc.Replace("{damage}", currentDamage.ToString());
        newDesc = newDesc.Replace("{secondaryDamage}", currentSecondaryDamage);
        newDesc = newDesc.Replace("{selfDamage}", currentSelfDamage);
        newDesc = newDesc.Replace("{heal}", currentHeal);
        newDesc = newDesc.Replace("{selfHeal}", currentSelfHeal);


        descText.text = newDesc;
    }


    int UpdateDamage()
    {
        AllyInstance a = character.GetComponent<AllyInstance>();
        int damage;
        float modifier = 1f;

        if (a.hasBlind)
        {
            modifier -= 0.5f;
        }

        if (cardData.subTypes.Contains(CombatCard.CombatSubType.Projectile) && a.hasDisarmed)
        {
            modifier -= 0.5f;
        }

        if (cardData.subTypes.Contains(CombatCard.CombatSubType.Melee) && a.hasPissedOff)
        {
            modifier += 0.5f;
        }

        if (a.hasInspired)
        {
            modifier += 0.25f;
        }

        if (a.hasUnsure)
        {
            modifier -= 0.25f;
        }

        damage = Mathf.RoundToInt((cardData.damage * modifier) + 0.4999f);

        return damage;
    }
}
