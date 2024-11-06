using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bleed : Debuff
{
    void Start()
    {
        debuffName = "Bleed";
        turnDuration = 0;
        intensity = 0f;
    }

    public override void UpdateEffect()
    {
        GetComponentInParent<CharacterInstance>().TakeDamage(turnDuration--);

        if(turnDuration <= 0)
        {
            GetComponentInParent<CharacterInstance>().RemoveDebuff(this);
        }
    }
}
