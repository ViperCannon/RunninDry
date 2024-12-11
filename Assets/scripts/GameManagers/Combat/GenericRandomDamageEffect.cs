using UnityEngine;

[CreateAssetMenu(fileName = "New GenericRandomDamageEffect", menuName = "GenericRandomDamageEffect")]
public class GenericRandomDamageEffect : ScriptableObject, ICardEffect
{
    //random target aside from the one specified. If target is null, then just a random target.
    public void ResolveEffect(CombatCardDisplay cardInstance, CharacterInstance target, CombatManager cManager)
    {
        CharacterInstance newTarget = target;

        if (cardInstance.cardData.validTargets.Contains(CombatCard.CardTarget.Enemy))
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

        int totalDamage = cardInstance.currentDamage; //account for target's buff/debuffs in future

        newTarget.TakeDamage(totalDamage);     
    }

    public void ResolveEffect(NegotiationCardDisplay cardInstance, NegotiationManager nManager)
    {

    }
}
