using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New GenericEnemyAttack", menuName = "GenericEnemyAttack")]
public class GenericEnemyAttack : ScriptableObject, IEnemyEffect
{
    public void ResolveEffect(CombatCard action, CharacterInstance target)
    {
        if (target != null)
        {
            Debug.Log("Dealing " + action.damage + " damage to " + target.name);
            target.TakeDamage(action.damage);
        }
    }
}
