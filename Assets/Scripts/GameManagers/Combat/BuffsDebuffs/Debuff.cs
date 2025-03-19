using UnityEngine;

public abstract class Debuff : IBuffEffect
{
    public string debuffName;
    public int turnDuration;
    public int intensity;
    public CharacterInstance target;

    public void ResolveEffect(CombatCardDisplay cardInstance, CharacterInstance character)
    {

    }

    public void ResolveEffect(CombatCard action, CharacterInstance target)
    {

    }

    public void ResolveEffect(NegotiationCardDisplay cardInstance)
    {

    }

    public abstract void UpdateEffect();
}
