using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Debuff : MonoBehaviour
{
    public string debuffName;
    public int turnDuration;
    public float intensity;

    public abstract void UpdateEffect();
}
