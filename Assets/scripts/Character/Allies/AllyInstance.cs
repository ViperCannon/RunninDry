using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllyInstance : CharacterInstance
{
    AllyData baseData;

    public string allyName;
    public int caps;
    
    public AllyInstance(AllyData allyData)
    {
        baseData = allyData;
        allyName = baseData.allyName;
        maxHealth = baseData.baseMaxHealth;
        currentHealth = maxHealth;
        caps = baseData.caps;
    }
}
