using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class AllyInstance : CharacterInstance
{
    [SerializeField]
    AllyData baseData;
    public string AllyName;

    public int caps;

    void Start()
    {
        AllyName = baseData.allyName;
        maxHealth = baseData.baseMaxHealth;
        currentHealth = maxHealth;
    }

    public override void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            isDowned = true;
        }
        else
        {
            isDowned = false;
        }
    }
}
