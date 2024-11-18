using UnityEngine;
using SpeakeasyStreet;

[CreateAssetMenu(fileName = "New GenericDamageEffect", menuName = "GenericDamageEffect")]
public class GenericDamageEffect : ScriptableObject, CardEffectInterface
{
    //also used to heal characters by utilizing negative damage
    public void ResolveEffect(Card temp, CharacterInstance target, int cost, CombatManager cManager)
    {
        CombatCard card = (CombatCard)temp;

        int totalDamage = card.damage * cost;

        target.TakeDamage(totalDamage);
    }
}
