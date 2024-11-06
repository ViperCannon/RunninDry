using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewAlly", menuName = "Character/Ally")]
public class AllyData : ScriptableObject
{
    public string allyName;
    public int baseMaxHealth;
    public int caps;
}
