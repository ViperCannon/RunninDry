using UnityEngine;
using SpeakeasyStreet;

[CreateAssetMenu(fileName = "New GenericDamageEffect", menuName = "GenericDamageEffect")]
public class GenericDamageEffect : ScriptableObject, CardEffectInterface
{
    //also used to heal characters by utilizing negative damage
    public void ResolveEffect(Card card, CharacterInstance target, int cost, CombatManager cManager)
    {
        for (int i = 0; i < card.damageMulti; i++)
        {
            int totalDamage = card.damage * cost;

            target.TakeDamage(totalDamage);
        }
    }
}
