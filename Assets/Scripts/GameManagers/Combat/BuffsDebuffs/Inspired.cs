using System.Linq;
using UnityEngine;

public class Inspired : Buff
{
    public Inspired()
    {
        buffName = "Inspired";
        turnDuration = 0;
        intensity = 0;
        target = null;
    }

    public Inspired(CharacterInstance character, int initTurnDuration)
    {
        buffName = "Inspired";
        turnDuration = initTurnDuration;
        intensity = 0;
        target = character;
    }

    new public void ResolveEffect(CombatCardDisplay cardInstance, CharacterInstance character)
    {
        Inspired existingInspired = GetExistingBuff(character);

        if (existingInspired != null)
        {
            existingInspired.AddStacks(cardInstance.cardData.turnDuration);
        }
        else
        {
            character.ApplyBuff(new Inspired(character, cardInstance.cardData.turnDuration));
        }
    }

    new public void ResolveEffect(CombatCard action, CharacterInstance character)
    {
        Inspired existingInspired = GetExistingBuff(character);

        if (existingInspired != null)
        {
            existingInspired.AddStacks(action.turnDuration);
        }
        else
        {
            target.ApplyBuff(new Inspired(character, action.turnDuration));
        }
    }

    Inspired GetExistingBuff(CharacterInstance character)
    {
        return character.activeBuffs.OfType<Inspired>().FirstOrDefault();
    }

    public override void UpdateEffect()
    {
        turnDuration--;

        if (turnDuration <= 0)
        {
            target.RemoveBuff(this);
        }
    }

    void AddStacks(int addTurnDurration)
    {
        turnDuration += addTurnDurration;
    }
}
