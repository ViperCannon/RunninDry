using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpeakeasyStreet;

public abstract class Buff : ScriptableObject, ICardEffect
{
    public string BuffName;
    public int turnDuration;
    public float intensity;

    public void ResolveEffect(CardDisplay cardInstance, CharacterInstance character, CombatManager cManager)
    {

    }
    public abstract void UpdateEffect();
}
