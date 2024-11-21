using UnityEngine;

public abstract class Buff : ScriptableObject, ICardEffect
{
    public string buffName;
    public int turnDuration;
    public float intensity;
    public CharacterInstance target;

    public void ResolveEffect(CardDisplay cardInstance, CharacterInstance character, CombatManager cManager)
    {

    }
    public abstract void UpdateEffect();
}
