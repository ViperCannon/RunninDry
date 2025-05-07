using UnityEngine;

[CreateAssetMenu(fileName = "New GenericRandomDamageEffect", menuName = "GenericRandomDamageEffect")]
public class GenericRandomDamageEffect : ScriptableObject, ICardEffect
{
    //random target aside from the one specified. If target is null, then just a random target.
    public void ResolveEffect(CombatCardDisplay cardInstance, CharacterInstance target)
    {
        CombatManager cManager = CombatManager.Instance;
        CharacterInstance newTarget = target;

        Debug.Log(cardInstance.cardData.validTargets[0].ToString());

        if (cardInstance.cardData.validTargets.Contains(CombatCard.CardTarget.Enemy))
        {
            while(newTarget == target)
            {
                newTarget = cManager.Enemies[Random.Range(0, cManager.Enemies.Count)];
            }
        }
        else
        {
            while (newTarget == target)
            {
                newTarget = cManager.Allies[Random.Range(0, cManager.Allies.Count)];
            }
        }

        bool takeCounter = false;
        float modifier = 1f;
        int totalDamage = 0;

        if (target.hasBulwark)
        {
            modifier -= 0.5f;
        }

        if (target.hasMarked && cardInstance.cardData.subTypes.Contains(CombatCard.CombatSubType.Projectile))
        {
            modifier += 0.5f;
        }

        totalDamage = Mathf.RoundToInt((cardInstance.currentDamage * modifier) + 0.4999f);

        if(target != null)
        {
            if (target.hasCounter)
            {
                takeCounter = true;
                CounterDamage.CalcCounter(totalDamage);
            }

            target.TakeDamage(totalDamage);

            if (takeCounter)
            {
                target.TakeDamage(CounterDamage.counterDamage);
            }
        }

        takeCounter = false;

        if (newTarget.hasCounter)
        {
            takeCounter = true;
            CounterDamage.CalcCounter(totalDamage);
        }

        newTarget.TakeDamage(totalDamage);

        if (takeCounter)
        {
            newTarget.TakeDamage(CounterDamage.counterDamage);
        }
    }

    public void ResolveEffect(NegotiationCardDisplay cardInstance)
    {

    }
}
