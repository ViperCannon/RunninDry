using UnityEngine;

[CreateAssetMenu(fileName = "New Counter", menuName = "Counter")]
public class Counter : Buff
{
    public Counter()
    {
        buffName = "Counter";
        turnDuration = 0;
        intensity = 0;
        target = null;
    }

    public Counter(CharacterInstance character, int initTurnDuration)
    {
        buffName = "Counter";
        turnDuration = initTurnDuration;
        intensity = 0;
        target = character;
    }

    new public void ResolveEffect(CardDisplay cardInstance, CharacterInstance character, CombatManager cManager)
    {
        Effect((CombatCardDisplay)cardInstance, character);
    }

    void Effect(CombatCardDisplay card, CharacterInstance character)
    {
        Counter existingCounter = null;

        foreach (Buff buff in character.activeBuffs)
        {
            if (buff is Counter counter)
            {
                existingCounter = counter;
                break;
            }
        }

        if (existingCounter != null)
        {
            existingCounter.AddStacks(card.cardData.turnDuration);
        }
        else
        {
            character.ApplyBuff(new Counter(character, card.cardData.turnDuration));
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
