using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New EnemyAttack", menuName = "EnemyAttack")]
public class GenericEnemyAttack : ScriptableObject
{
    CharacterInstance owner;
    public int damage;
    public int secondaryDamage;
    public int selfDamage;
    public int heal;
    public int secondaryHeal;
    public int turnDuration; //for applied effects
    public int chanceEffect; //chance for applied effects (do not use for blind)
    public List<SubType> subTypes;
    public List<EnemyTarget> validTargets;
    public List<ScriptableObject> enemyEffects;

    CharacterInstance currentTarget;

    public enum SubType
    {
        Projectile,
        Melee,
        Buff,
        Debuff,
        Heal
    }

    public enum EnemyTarget
    {
        Self,
        Enemy, //Any enemy except for the case of an enemy using an ability. The active enemy is excluded as a target in that case.
        Player, //Any ally excluding the ally whose card is being played
        AllEnemies,
        AllPlayers,
        AllCharacters
    }

    public bool IsAOE()
    {
        if (validTargets.Contains(EnemyTarget.AllEnemies) || validTargets.Contains(EnemyTarget.AllPlayers) || validTargets.Contains(EnemyTarget.AllCharacters))
        {
            return true;
        }

        return false;
    }

    public bool IsSelfInclusive()
    {
        if (validTargets.Contains(EnemyTarget.Enemy) && validTargets.Contains(EnemyTarget.Self))
        {
            return true;
        }

        return false;
    }

    public void GetRandomTarget()
    {
        if (!IsAOE() && validTargets[0] != EnemyTarget.Self) //Must be a single target action in this case
        {
            int index;
            CharacterInstance temp = null;
            
            if (validTargets[0] == EnemyTarget.Player)
            {
                index = Random.Range(0, 3);

                while(temp == null)
                {
                    if (!CombatManager.Instance.Allies[index].isDowned)
                    {
                        temp = CombatManager.Instance.Allies[index];
                    }
                }

                currentTarget = temp;
            }
            else
            {
                index = Random.Range(0, 5);

                while (temp == null)
                {
                    if (CombatManager.Instance.Enemies[index] != null && CombatManager.Instance.Enemies[index] != owner)
                    {
                        temp = CombatManager.Instance.Enemies[index];
                    }
                }

                currentTarget = temp;
            }
        }
        else if(validTargets[0] == EnemyTarget.Self)
        {
            currentTarget = owner;
        }
        else //AOE don't need a specified target
        {
            currentTarget = null;
        }
    }

    public void SetTarget(CharacterInstance target)
    {
        currentTarget = target;
    }

    public CharacterInstance GetTarget()
    {
        return currentTarget;
    }
}
