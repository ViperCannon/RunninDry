using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpeakeasyStreet;

public class EnemyInstance : CharacterInstance
{
    [SerializeField]
    EnemyData baseData;
    public Card[] attacks;

   void Start()
    {
        maxHealth = baseData.baseMaxHealth;
        currentHealth = maxHealth;
    }

    public void PerformAction()
    {

    }
}
