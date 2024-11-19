using UnityEngine;

[CreateAssetMenu(fileName = "New GenericRandomDamageEffect", menuName = "GenericRandomDamageEffect")]
public class GenericRandomDamageEffect : ScriptableObject, ICardEffect
{
    //random target aside from the one specified. If target is null, then just a random target.
    public void ResolveEffect(CardDisplay cardInstance, CharacterInstance target, CombatManager cManager)
    {
        CombatCardDisplay card = (CombatCardDisplay)cardInstance;
        CharacterInstance newTarget = target;

        if (card.cardData.validTargets.Contains(CombatCard.CardTarget.Enemy))
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

        int totalDamage = card.currentDamage; //account for target's buff/debuffs in future

        newTarget.TakeDamage(totalDamage);     
    }
}
