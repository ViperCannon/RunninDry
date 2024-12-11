using UnityEngine;

[CreateAssetMenu(fileName = "New GenericSelfDamageEffect", menuName = "GenericSelfDamageEffect")]
public class GenericSelfDamageEffect : ScriptableObject, ICardEffect
{
    public void ResolveEffect(CombatCardDisplay cardInstance, CharacterInstance target, CombatManager cManager)
    {
        int totalDamage = cardInstance.currentSelfDamage;

        cardInstance.character.GetComponent<AllyInstance>().TakeDamage(totalDamage);
    }

    public void ResolveEffect(NegotiationCardDisplay cardInstance, NegotiationManager nManager)
    {

    }
}
