using UnityEngine;

[CreateAssetMenu(fileName = "New PissedOff", menuName = "PissedOff")]
public class PissedOff : Buff
{
    public PissedOff()
    {
        buffName = "PissedOff";
        turnDuration = 0;
        intensity = 0;
        target = null;
    }

    public PissedOff(CharacterInstance character, int initTurnDuration)
    {
        buffName = "PissedOff";
        turnDuration = initTurnDuration;
        intensity = 0;
        target = character;
    }

    new public void ResolveEffect(CombatCardDisplay cardInstance, CharacterInstance character, CombatManager cManager)
    {
        PissedOff existingPissedOff = null;

        foreach (Buff buff in character.activeBuffs)
        {
            if (buff is PissedOff pissedOff)
            {
                existingPissedOff = pissedOff;
                break;
            }
        }

        if (existingPissedOff != null)
        {
            existingPissedOff.AddStacks(cardInstance.cardData.turnDuration);
        }
        else
        {
            character.ApplyBuff(new PissedOff(character, cardInstance.cardData.turnDuration));
        }
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
