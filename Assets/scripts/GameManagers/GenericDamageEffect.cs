using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpeakeasyStreet;

[System.Serializable]
[CreateAssetMenu(fileName = "New GenericDamageEffect", menuName = "GenericDamageEffect")]
public class GenericDamageEffect : ScriptableObject, CardEffectInterface
{
    public void ResolveEffect(Card card, CharacterInstance target, int cost, CombatManager cManager)
    {
        for (int i = 0; i < card.damageMulti; i++)
        {
            int totalDamage = card.damage * cost;

            target.TakeDamage(totalDamage);
        }
    }
}
