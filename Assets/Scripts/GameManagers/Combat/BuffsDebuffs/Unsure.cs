using UnityEngine;

public class Unsure : Debuff
{
    public Unsure()
    {
        debuffName = "Unsure";
        turnDuration = 0;
        intensity = 0;
        target = null;
    }

    public Unsure(CharacterInstance character, int initTurnDuration)
    {
        debuffName = "Unsure";
        turnDuration = initTurnDuration;
        intensity = 0;
        target = character;
    }

    new public void ResolveEffect(CombatCardDisplay cardInstance, CharacterInstance character)
    {
        Unsure existingUnsure = null;

        foreach (Debuff debuff in character.activeDebuffs)
        {
            if (debuff is Unsure unsure)
            {
                existingUnsure = unsure;
                break;
            }
        }

        if (existingUnsure != null)
        {
            existingUnsure.AddStacks(cardInstance.cardData.turnDuration);
        }
        else
        {
            character.ApplyDebuff(new Unsure(character, cardInstance.cardData.turnDuration));
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

    void AddStacks(int addTurnDurration)
    {
        turnDuration += addTurnDurration;
    }
}
