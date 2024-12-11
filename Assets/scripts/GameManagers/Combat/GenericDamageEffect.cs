using UnityEngine;

[CreateAssetMenu(fileName = "New GenericDamageEffect", menuName = "GenericDamageEffect")]
public class GenericDamageEffect : ScriptableObject, ICardEffect
{
    public void ResolveEffect(CombatCardDisplay cardInstance, CharacterInstance target, CombatManager cManager)
    {
        int totalDamage = 0;

        if(cardInstance.unload < 0)
        {
            totalDamage = cardInstance.currentDamage;
        }
        else
        {
            totalDamage = cardInstance.currentDamage * cardInstance.unload;
        }
        
        if(target != null)
        {
            target.TakeDamage(totalDamage);
        }   
        else
            foreach(EnemyInstance enemy in cManager.enemies)
            {
                if (enemy != null)
                {
                    enemy.TakeDamage(totalDamage);   
                }
                    
            }

        
    }

    public void ResolveEffect(NegotiationCardDisplay cardInstance, NegotiationManager nManager)
    {
        
    }
}
