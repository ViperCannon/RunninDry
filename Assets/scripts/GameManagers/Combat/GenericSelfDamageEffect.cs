using UnityEngine;

[CreateAssetMenu(fileName = "New GenericSelfDamageEffect", menuName = "GenericSelfDamageEffect")]
public class GenericSelfDamageEffect : ScriptableObject, ICardEffect
{
    public void ResolveEffect(CardDisplay cardInstance, CharacterInstance target, CombatManager cManager)
    {
        CombatCardDisplay card = (CombatCardDisplay)cardInstance;

        int totalDamage = card.currentSelfDamage;

        card.character.GetComponent<AllyInstance>().TakeDamage(totalDamage);
    }
}
