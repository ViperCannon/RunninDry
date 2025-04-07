using UnityEngine;

[CreateAssetMenu(fileName = "New GenericHealEffect", menuName = "GenericHealEffect")]
public class GenericHealEffect : ScriptableObject, ICardEffect
{
    public void ResolveEffect(CombatCardDisplay cardInstance, CharacterInstance target)
    {
        int totalHeal = int.Parse(cardInstance.currentHeal);

        target.Heal(totalHeal);
    }

    public void ResolveEffect(NegotiationCardDisplay cardInstance)
    {

    }
}
