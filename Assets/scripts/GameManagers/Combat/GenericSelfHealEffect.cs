using UnityEngine;

[CreateAssetMenu(fileName = "New GenericSelfHealEffect", menuName = "GenericSelfHealEffect")]
public class GenericSelfHealEffect : ScriptableObject, ICardEffect
{
    public void ResolveEffect(CardDisplay cardInstance, CharacterInstance target, CombatManager cManager)
    {
        CombatCardDisplay card = (CombatCardDisplay)cardInstance;

        int totalHeal = card.currentSelfHeal;

        card.character.GetComponent<AllyInstance>().Heal(totalHeal);
    }
}

