using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpeakeasyStreet;

[CreateAssetMenu(fileName = "New Blind", menuName = "Blind")]
public class Blind : Debuff
{
    public Blind()
    {
        debuffName = "Blind";
        turnDuration = 0;
        intensity = 25;
        target = null;
    }

    public Blind(CharacterInstance character)
    {
        debuffName = "Blind";
        turnDuration = 1;
        intensity = 25;
        target = character;
    }

    public Blind(CharacterInstance character, int initTurnDuration)
    {
        debuffName = "Blin";
        turnDuration = initTurnDuration;
        intensity = 25;
        target = character;
    }

    new public void ResolveEffect(CardDisplay cardInstance, CharacterInstance character, CombatManager cManager)
    {
        Effect((CombatCardDisplay)cardInstance, character);
    }

    void Effect(CombatCardDisplay card, CharacterInstance character)
    {
        Blind existingBlind = null;

        foreach (Debuff debuff in character.activeDebuffs)
        {
            if (debuff is Blind blind)
            {
                existingBlind = blind;
                break;
            }
        }

        for (int i = 0; i < card.cardData.turnDuration; i++)
        {
            AttemptBlind(existingBlind, character);
        }
    }

    void AttemptBlind(Blind existingBlind, CharacterInstance character)
    {
        if(existingBlind == null)
        {
            character.ApplyDebuff(new Blind(character));
        }
        else if(existingBlind.turnDuration < 4)
        {
            int chance = Random.Range(1, 101);

            if(chance > existingBlind.intensity * existingBlind.turnDuration)
            {
                existingBlind.AddBlindStack();
            }
        }
    }

    public override void UpdateEffect()
    {
        turnDuration--;

        if (turnDuration <= 0)
        {
            target.RemoveDebuff(this);
        }
    }

    public void AddBlindStack()
    {
        turnDuration++;

        if(turnDuration > 4)
        {
            turnDuration = 4;
        }
    }
}
