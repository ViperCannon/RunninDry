using UnityEngine;

[CreateAssetMenu(fileName = "New Disarmed", menuName = "Disarmed")]
public class Disarmed : Debuff
{
    public Disarmed()
    {
        debuffName = "Disarmed";
        turnDuration = 0;
        intensity = 0;
        target = null;
    }

    public Disarmed(CharacterInstance character, int initTurnDuration)
    {
        debuffName = "Disarmed";
        turnDuration = initTurnDuration;
        intensity = 0;
        target = character;
    }

    new public void ResolveEffect(CombatCardDisplay cardInstance, CharacterInstance character)
    {
        Disarmed existingDisarmed = null;

        foreach (Debuff debuff in character.activeDebuffs)
        {
            if (debuff is Disarmed disarmed)
            {
                existingDisarmed = disarmed;
                break;
            }
        }

        if (existingDisarmed != null)
        {
            existingDisarmed.AddStacks(cardInstance.cardData.turnDuration);
        }
        else
        {
            character.ApplyDebuff(new Disarmed(character, cardInstance.cardData.turnDuration));
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
