using UnityEngine;

[CreateAssetMenu(fileName = "New GenericHealEffect", menuName = "GenericHealEffect")]
public class GenericHealEffect : ScriptableObject, ICardEffect
{
    public void ResolveEffect(CardDisplay cardInstance, CharacterInstance target, CombatManager cManager)
    {
        CombatCardDisplay card = (CombatCardDisplay)cardInstance;

        int totalHeal = card.currentHeal;

        target.Heal(totalHeal);
    }
}
