using UnityEngine;

[CreateAssetMenu(fileName = "New Bulwark", menuName = "Bulwark")]
public class Bulwark : Buff
{
    public Bulwark()
    {
        buffName = "Bulwark";
        turnDuration = 0;
        intensity = 0;
        target = null;
    }

    public Bulwark(CharacterInstance character, int initTurnDuration)
    {
        buffName = "Bulwark";
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
        Bulwark existingBulwark = null;

        foreach (Buff buff in character.activeBuffs)
        {
            if (buff is Bulwark bulwark)
            {
                existingBulwark = bulwark;
                break;
            }
        }

        if (existingBulwark != null)
        {
            existingBulwark.AddStacks(card.cardData.turnDuration);
        }
        else
        {
            character.ApplyBuff(new Bulwark(character, card.cardData.turnDuration));
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
