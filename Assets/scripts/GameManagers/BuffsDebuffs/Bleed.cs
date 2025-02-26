using UnityEngine;

[CreateAssetMenu(fileName = "New Bleed", menuName = "Bleed")]
public class Bleed : Debuff
{
    public Bleed()
    {
        debuffName = "Bleed";
        turnDuration = 0;
        intensity = 0;
        target = null;
    }

    public Bleed(CharacterInstance character, int initTurnDuration)
    {
        debuffName = "Bleed";
        turnDuration = initTurnDuration;
        intensity = 0;
        target = character;
    }

    new public void ResolveEffect(CombatCardDisplay cardInstance, CharacterInstance character)
    {
        Bleed existingBleed = null;

        foreach (Debuff debuff in character.activeDebuffs)
        {
            if (debuff is Bleed bleed)
            {
                existingBleed = bleed;
                break;
            }
        }

        if (existingBleed != null)
        {
            existingBleed.AddStacks(cardInstance.cardData.turnDuration);
        }
        else
        {
            character.ApplyDebuff(new Bleed(character, cardInstance.cardData.turnDuration));
        }
    }

    public override void UpdateEffect()
    {
       target.TakeDamage(turnDuration--);

        if(turnDuration <= 0)
        {
            target.RemoveDebuff(this);
        }
    }

    void AddStacks(int addTurnDurration)
    {
        turnDuration += addTurnDurration;
    }
}
