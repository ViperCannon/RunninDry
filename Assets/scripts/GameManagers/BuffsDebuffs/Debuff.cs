using UnityEngine;

public abstract class Debuff : ScriptableObject, ICardEffect
{
    public string debuffName;
    public int turnDuration;
    public int intensity;
    public CharacterInstance target;

    public void ResolveEffect(CombatCardDisplay cardInstance, CharacterInstance character)
    {

    }

    public void ResolveEffect(NegotiationCardDisplay cardInstance)
    {

    }

    public abstract void UpdateEffect();
}
