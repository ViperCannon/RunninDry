using UnityEngine;

[CreateAssetMenu(fileName = "New GenericHealEffect", menuName = "GenericHealEffect")]
public class GenericHealEffect : ScriptableObject, ICardEffect
{
    public void ResolveEffect(CombatCardDisplay cardInstance, CharacterInstance target, CombatManager cManager)
    {
        int totalHeal = cardInstance.currentHeal;

        target.Heal(totalHeal);
    }

    public void ResolveEffect(NegotiationCardDisplay cardInstance, NegotiationManager nManager)
    {

    }
}
