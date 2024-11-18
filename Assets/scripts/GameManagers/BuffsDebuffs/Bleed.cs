using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpeakeasyStreet;

[CreateAssetMenu(fileName = "New Bleed", menuName = "Bleed")]
public class Bleed : Debuff
{
    public Bleed()
    {
        debuffName = "Bleed";
        turnDuration = 0;
        intensity = 0;
        target = null;
    }

    public Bleed(CharacterInstance character, int initTurnDuration)
    {
        debuffName = "Bleed";
        turnDuration = initTurnDuration;
        intensity = 0;
        target = character;
    }

    new public void ResolveEffect(Card card, CharacterInstance character, int cost, CombatManager cManager)
    {
        Effect((CombatCard)card, character);
    }

    void Effect(CombatCard card, CharacterInstance character)
    {
        Bleed existingBleed = null;

        foreach (Debuff debuff in character.activeDebuffs)
        {
            if (debuff is Bleed bleed)
            {
                existingBleed = bleed;
                break;
            }
        }

        if (existingBleed != null)
        {
            existingBleed.AddStacks(card.turnDuration);
        }
        else
        {
            character.ApplyDebuff(new Bleed(character, card.turnDuration));
        }
    }

    public override void UpdateEffect()
    {
       target.TakeDamage(turnDuration--);

        if(turnDuration <= 0)
        {
            target.RemoveDebuff(this);
        }
    }

    void AddStacks(int addTurnDurration)
    {
        turnDuration += addTurnDurration;
    }
}
