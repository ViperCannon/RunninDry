using UnityEngine;

[CreateAssetMenu(fileName = "New GenericDamageEffect", menuName = "GenericDamageEffect")]
public class GenericDamageEffect : ScriptableObject, ICardEffect
{
    public void ResolveEffect(CombatCardDisplay cardInstance, CharacterInstance target)
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
        {
            foreach(EnemyInstance enemy in CombatManager.Instance.Enemies)
            {
                if (enemy != null)
                {
                    enemy.TakeDamage(totalDamage);   
                }
                    
            }
        }
    }

    public void ResolveEffect(NegotiationCardDisplay cardInstance)
    {
        
    }
}
