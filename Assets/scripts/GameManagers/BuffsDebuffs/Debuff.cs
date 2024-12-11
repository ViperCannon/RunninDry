using UnityEngine;

public abstract class Debuff : ScriptableObject, ICardEffect
{
    public string debuffName;
    public int turnDuration;
    public int intensity;
    public CharacterInstance target;

    public void ResolveEffect(CombatCardDisplay cardInstance, CharacterInstance character, CombatManager cManager)
    {

    }

    public void ResolveEffect(NegotiationCardDisplay cardInstance, NegotiationManager nManager)
    {

    }

    public abstract void UpdateEffect();
}
