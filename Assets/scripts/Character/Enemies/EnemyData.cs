using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpeakeasyStreet;

[CreateAssetMenu(fileName = "NewEnemy", menuName = "Character/Enemy")]
public class EnemyData : ScriptableObject
{
    public string EnemyName;
    public int baseMaxHealth;

    public List<IEnemyEffect> attacks;
}
