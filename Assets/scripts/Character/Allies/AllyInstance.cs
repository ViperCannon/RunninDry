using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllyInstance : CharacterInstance
{
    [SerializeField]
    AllyData baseData;

    public int caps;

    void Start()
    {
        maxHealth = baseData.baseMaxHealth;
        currentHealth = maxHealth;
    }
}
