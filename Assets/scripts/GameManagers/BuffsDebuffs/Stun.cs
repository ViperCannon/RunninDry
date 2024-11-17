using UnityEngine;
using SpeakeasyStreet;

[CreateAssetMenu(fileName = "New Stun", menuName = "Stun")]
public class Stun : Debuff
{
    public Stun()
    {
        debuffName = "Stun";
        turnDuration = 0;
        intensity = 0;
        target = null;
    }

    public Stun(CharacterInstance character)
    {
        debuffName = "Stun";
        turnDuration = 1;
        intensity = 0;
        target = character;
    }

    public Stun(CharacterInstance character, int initTurnDuration)
    {
        debuffName = "Stun";
        turnDuration = initTurnDuration;
        intensity = 0;
        target = character;
    }

    new public void ResolveEffect(Card card, CharacterInstance character, int cost, CombatManager cManager)
    {
        Stun existingStun = null;

        foreach (Debuff debuff in character.activeDebuffs)
        {
            if (debuff is Stun)
            {
                existingStun = (Stun)debuff;
                break;
            }
        }

        if (existingStun != null)
        {
            existingStun.AddStacks(card.turnDuration);
        }
        else
        {
            character.ApplyDebuff(new Bleed(character, card.turnDuration));
        }
    }

    public override void UpdateEffect()
    {
        target.TakeDamage(turnDuration--);

        if (turnDuration <= 0)
        {
            target.RemoveDebuff(this);
        }
    }

    void AddStacks(int addTurnDurration)
    {
        turnDuration += addTurnDurration;
    }
}
