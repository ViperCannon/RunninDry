using UnityEngine;

[CreateAssetMenu(fileName = "New GenericDamageEffect", menuName = "GenericDamageEffect")]
public class GenericDamageEffect : ScriptableObject, ICardEffect
{
    public void ResolveEffect(CardDisplay cardInstance, CharacterInstance target, CombatManager cManager)
    {
        CombatCardDisplay card = (CombatCardDisplay)cardInstance;
        int totalDamage = 0;

        if(card.unload < 0)
        {
            totalDamage = card.currentDamage;
        }
        else
        {
            totalDamage = card.currentDamage * card.unload;
        }
        

        target.TakeDamage(totalDamage);

        Debug.Log(target.name + " recieved " + totalDamage + " damnage.");
    }
}
