using UnityEngine;

[CreateAssetMenu(fileName = "New Marked", menuName = "Marked")]
public class Marked : Debuff
{
    public Marked()
    {
        debuffName = "Marked";
        turnDuration = -1;
        intensity = 2;
        target = null;
    }

    public Marked(CharacterInstance character)
    {
        debuffName = "Marked";
        turnDuration = -1;
        intensity = 2;
        target = character;
    }

    public Marked(CharacterInstance character, int initTurnDuration)
    {
        debuffName = "Marked";
        turnDuration = initTurnDuration;
        intensity = 2;
        target = character;
    }

    new public void ResolveEffect(CombatCardDisplay cardInstance, CharacterInstance character)
    {
        bool hasMarked = false;

        foreach (Debuff debuff in character.activeDebuffs)
        {
            if (debuff is Marked)
            {
                hasMarked = true;
                break;
            }
        }

        if (!hasMarked)
        {
            if (cardInstance.cardData.turnDuration > 0)
            {
                character.ApplyDebuff(new Marked(character, cardInstance.cardData.turnDuration));
            }
            else
            {
                character.ApplyDebuff(new Marked(character));
            }
        }
    }

    public override void UpdateEffect()
    {
        if(turnDuration > 0)
        {
            turnDuration--;
        }

        if (turnDuration == 0)
        {
            target.RemoveDebuff(this);
        }
    }
}
