using UnityEngine;

[CreateAssetMenu(fileName = "New GenericDamageEffect", menuName = "GenericDamageEffect")]
public class GenericDamageEffect : ScriptableObject, ICardEffect
{
    public void ResolveEffect(CombatCardDisplay cardInstance, CharacterInstance target)
    {
        bool takeCounter = false;
        float modifier = 1f;
        int totalDamage = 0;
        
        if(target != null)
        {
            if (target.hasBulwark)
            {
                modifier -= 0.5f;
            }

            if (target.hasMarked && cardInstance.cardData.subTypes.Contains(CombatCard.CombatSubType.Projectile))
            {
                modifier += 0.5f;
            }

            if (cardInstance.unload < 0)
            {
                totalDamage = Mathf.RoundToInt((cardInstance.currentDamage * modifier) + 0.4999f);
            }
            else
            {
                totalDamage = Mathf.RoundToInt((cardInstance.currentDamage * modifier) + 0.4999f) * cardInstance.unload;
            }

            if (target.hasCounter)
            {
                takeCounter = true;
                CounterDamage.CalcCounter(totalDamage);
            }

            target.TakeDamage(totalDamage);

            if (takeCounter)
            {
                cardInstance.character.GetComponent<AllyInstance>().TakeDamage(CounterDamage.counterDamage);
            }
        }   
        else
        {
            foreach(EnemyInstance enemy in CombatManager.Instance.Enemies)
            {
                if (enemy.hasBulwark)
                {
                    modifier -= 0.5f;
                }

                if (enemy.hasMarked && cardInstance.cardData.subTypes.Contains(CombatCard.CombatSubType.Projectile))
                {
                    modifier += 0.5f;
                }

                if (cardInstance.unload < 0)
                {
                    totalDamage = Mathf.RoundToInt((cardInstance.currentDamage * modifier) + 0.4999f);
                }
                else
                {
                    totalDamage = Mathf.RoundToInt((cardInstance.currentDamage * modifier) + 0.4999f) * cardInstance.unload;
                }

                if (enemy.hasCounter)
                {
                    takeCounter = true;
                    CounterDamage.CalcCounter(totalDamage);
                }

                if(enemy != null && enemy.gameObject != null)
                {
                    enemy.TakeDamage(totalDamage);
                }

                if (takeCounter)
                {
                    cardInstance.character.GetComponent<AllyInstance>().TakeDamage(CounterDamage.counterDamage);
                }

                takeCounter = false;
                modifier = 1f;
            }
        }
    }

    public void ResolveEffect(NegotiationCardDisplay cardInstance)
    {
        
    }
}
