using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CounterDamage : MonoBehaviour
{
    public static int counterDamage;

    public static void CalcCounter(int damage)
    {
        if(damage % 2 == 1)
        {
            damage++;
        }

        counterDamage = damage / 2;
    }
}
