using UnityEngine;
using SpeakeasyStreet;

[CreateAssetMenu(fileName = "New GenericRandomDamageEffect", menuName = "GenericRandomDamageEffect")]
public class GenericRandomDamageEffect : ScriptableObject, CardEffectInterface
{
    //random target aside from the one specified. If target is null, then just a random target.
    public void ResolveEffect(Card temp, CharacterInstance target, int cost, CombatManager cManager)
    {
        CombatCard card = (CombatCard)temp;
        CharacterInstance newTarget = null;

        if(target == null)
        {
            if (card.validTargets.Contains(CombatCard.CardTarget.Enemy))
            {
                while(newTarget == target)
                {
                    newTarget = cManager.enemies[Random.Range(0, cManager.enemies.Count)];
                }
            }
            else
            {
                while (newTarget == target)
                {
                    newTarget = cManager.players[Random.Range(0, cManager.players.Count)];
                }
            }
        }
      
        int totalDamage = card.damage * cost;

        newTarget.TakeDamage(totalDamage);     
    }
}