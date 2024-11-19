using UnityEngine;

[CreateAssetMenu(fileName = "New GenericDamageEffect", menuName = "GenericDamageEffect")]
public class GenericDamageEffect : ScriptableObject, ICardEffect
{
    //also used to heal characters by utilizing negative damage
    public void ResolveEffect(CardDisplay cardInstance, CharacterInstance target, CombatManager cManager)
    {
        CombatCardDisplay card = (CombatCardDisplay)cardInstance;

        int totalDamage = card.currentDamage;

        target.TakeDamage(totalDamage);
    }
}
