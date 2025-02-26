using UnityEngine;

[CreateAssetMenu(fileName = "New GenericSelfHealEffect", menuName = "GenericSelfHealEffect")]
public class GenericSelfHealEffect : ScriptableObject, ICardEffect
{
    public void ResolveEffect(CombatCardDisplay cardInstance, CharacterInstance target)
    {

        int totalHeal = cardInstance.currentSelfHeal;

        cardInstance.character.GetComponent<AllyInstance>().Heal(totalHeal);
    }

    public void ResolveEffect(NegotiationCardDisplay cardInstance)
    {

    }
}

