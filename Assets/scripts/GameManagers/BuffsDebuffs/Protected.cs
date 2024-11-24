using UnityEngine;

[CreateAssetMenu(fileName = "New Protected", menuName = "Protected")]
public class Protected : Buff
{
    public Protected()
    {
        buffName = "Protected";
        turnDuration = 0;
        intensity = 0;
        target = null;
    }

    public Protected(CharacterInstance character, int initTurnDuration)
    {
        buffName = "Protected";
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
        Protected existingProtected = null;

        foreach (Buff buff in character.activeBuffs)
        {
            if (buff is Protected protect)
            {
                existingProtected = protect;
                break;
            }
        }

        if (existingProtected != null)
        {
            existingProtected.AddStacks(card.cardData.turnDuration);
        }
        else
        {
            character.ApplyBuff(new Protected(character, card.cardData.turnDuration));
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
