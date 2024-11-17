using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpeakeasyStreet;

public abstract class Debuff : ScriptableObject, CardEffectInterface
{
    public string debuffName;
    public int turnDuration;
    public int intensity;
    public CharacterInstance target;

    public void ResolveEffect(Card card, CharacterInstance character, int cost, CombatManager cManager)
    {

    }
    public abstract void UpdateEffect();
}
