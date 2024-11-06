using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpeakeasyStreet;

public class EnemyInstance : CharacterInstance
{
    EnemyData baseData;
    public Card[] attacks;

    public EnemyInstance(EnemyData enemyData)
    {
        baseData = enemyData;
        maxHealth = baseData.baseMaxHealth;
        currentHealth = maxHealth;
        attacks = baseData.attacks;
    }
}
