using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New GenericEnemyAttack", menuName = "GenericEnemyAttack")]
public class GenericEnemyAttack : ScriptableObject, IEnemyEffect
{
    public void ResolveEffect(CombatCard action, CharacterInstance target)
    {
        EnemyInstance e = CombatManager.Instance.activeEnemy;
        int damage;
        float modifier = 1f;
        bool takeCounter = false;

        if (e.hasBlind)
        {
            modifier -= 0.5f;
        }

        if (target.hasBulwark)
        {
            modifier -= 0.5f;
        }

        if(action.subTypes.Contains(CombatCard.CombatSubType.Projectile))
        {
            if (e.hasDisarmed)
            {
                modifier -= 0.5f;
            }

            if (target.hasMarked)
            {
                modifier += 0.5f;
            }
            
        }

        if (e.hasPissedOff && action.subTypes.Contains(CombatCard.CombatSubType.Melee))
        {
            modifier += 0.5f;
        }

        if (e.hasInspired)
        {
            modifier += 0.25f;
        }

        if (e.hasUnsure)
        {
            modifier -= 0.25f;
        }

        damage = Mathf.RoundToInt((action.damage * modifier) + 0.4999f);

        if (target.hasCounter)
        {
            takeCounter = true;
            CounterDamage.CalcCounter(damage);
        }

        if (target != null && !target.isDowned)
        {
            Debug.Log("Dealing " + damage + " damage to " + target.name);
            target.TakeDamage(damage);
        }
        else
        {
            Debug.Log("Dealing " + damage + " damage to " + target.name);
            e.SetRandomTarget().TakeDamage(damage);
        }

        if (takeCounter)
        {
            e.TakeDamage(CounterDamage.counterDamage);
        }
    }
}
