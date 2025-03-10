using UnityEngine;

[CreateAssetMenu(fileName = "New Inspired", menuName = "Inspired")]
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
        Inspired existingInspired = null;

        foreach (Buff buff in character.activeBuffs)
        {
            if (buff is Inspired inspired)
            {
                existingInspired = inspired;
                break;
            }
        }

        if (existingInspired != null)
        {
            existingInspired.AddStacks(cardInstance.cardData.turnDuration);
        }
        else
        {
            character.ApplyBuff(new Inspired(character, cardInstance.cardData.turnDuration));
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
