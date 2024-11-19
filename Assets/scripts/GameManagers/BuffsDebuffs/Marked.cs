using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpeakeasyStreet;

[CreateAssetMenu(fileName = "New Marked", menuName = "Marked")]
public class Marked : Debuff
{
    public Marked()
    {
        debuffName = "Marked";
        turnDuration = -1;
        intensity = 2;
        target = null;
    }

    public Marked(CharacterInstance character)
    {
        debuffName = "Marked";
        turnDuration = -1;
        intensity = 2;
        target = character;
    }

    public Marked(CharacterInstance character, int initTurnDuration)
    {
        debuffName = "Marked";
        turnDuration = initTurnDuration;
        intensity = 2;
        target = character;
    }

    new public void ResolveEffect(CardDisplay cardInstance, CharacterInstance character, CombatManager cManager)
    {
        Effect((CombatCardDisplay)cardInstance, character);
    }

    void Effect(CombatCardDisplay card, CharacterInstance character)
    {
        bool hasMarked = false;

        foreach (Debuff debuff in character.activeDebuffs)
        {
            if (debuff is Marked)
            {
                hasMarked = true;
                break;
            }
        }

        if (!hasMarked)
        {
            if (card.cardData.turnDuration > 0)
            {
                character.ApplyDebuff(new Marked(character, card.cardData.turnDuration));
            }
            else
            {
                character.ApplyDebuff(new Marked(character));
            }
        }
    }

    public override void UpdateEffect()
    {
        if(turnDuration > 0)
        {
            turnDuration--;
        }

        if (turnDuration == 0)
        {
            target.RemoveDebuff(this);
        }
    }
}
