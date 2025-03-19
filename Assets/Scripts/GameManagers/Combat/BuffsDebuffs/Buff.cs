using UnityEngine;

public abstract class Buff : IBuffEffect
{
    public BuffSO buffData;
    public string buffName;
    public int turnDuration;
    public float intensity;
    public CharacterInstance target;

    public void ResolveEffect(CombatCardDisplay cardInstance, CharacterInstance character)
    {

    }

    public void ResolveEffect(CombatCard action, CharacterInstance character)
    {

    }

    public void ResolveEffect(NegotiationCardDisplay cardInstance)
    {

    }

    public abstract void UpdateEffect();
}
