using UnityEngine;

[CreateAssetMenu(fileName = "New Resilient", menuName = "Resilient")]
public class Resilient : Buff
{
    public Resilient()
    {
        buffName = "Resilient";
        turnDuration = 0;
        intensity = 0;
        target = null;
    }

    public Resilient(CharacterInstance character, int initTurnDuration)
    {
        buffName = "Resilient";
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
        Resilient existingResilient = null;

        foreach (Buff buff in character.activeBuffs)
        {
            if (buff is Resilient resilient)
            {
                existingResilient = resilient;
                break;
            }
        }

        if (existingResilient != null)
        {
            existingResilient.AddStacks(card.cardData.turnDuration);
        }
        else
        {
            character.ApplyBuff(new Resilient(character, card.cardData.turnDuration));
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