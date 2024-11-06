using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Buff : MonoBehaviour
{
    public string buffName;
    public int turnDuration;
    public float intensity;

    public abstract void UpdateEffect();
}
