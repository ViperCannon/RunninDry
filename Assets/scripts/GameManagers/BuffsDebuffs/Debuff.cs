using UnityEngine;

public abstract class Debuff : ScriptableObject, ICardEffect
{
    public string debuffName;
    public int turnDuration;
    public int intensity;
    public CharacterInstance target;

    public void ResolveEffect(CardDisplay cardInstance, CharacterInstance character, CombatManager cManager)
    {

    }
    public abstract void UpdateEffect();
}
