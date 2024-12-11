using UnityEngine;

public abstract class Buff : ScriptableObject, ICardEffect
{
    public string buffName;
    public int turnDuration;
    public float intensity;
    public CharacterInstance target;

    public void ResolveEffect(CombatCardDisplay cardInstance, CharacterInstance character, CombatManager cManager)
    {

    }

    public void ResolveEffect(NegotiationCardDisplay cardInstance, NegotiationManager nManager)
    {

    }

    public abstract void UpdateEffect();
}
