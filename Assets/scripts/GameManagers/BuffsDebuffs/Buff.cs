using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpeakeasyStreet;

public abstract class Buff : ScriptableObject, CardEffectInterface
{
    public string BuffName;
    public int turnDuration;
    public float intensity;

    public void ResolveEffect(Card card, CharacterInstance target, int cost, CombatManager cManager)
    {

    }
    public abstract void UpdateEffect();
}
