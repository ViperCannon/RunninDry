public class Marked : Debuff
{
    public Marked()
    {
        debuffName = "Marked";
        turnDuration = 0;
        target = null;
    }

    public Marked(CharacterInstance character)
    {
        debuffName = "Marked";
        turnDuration = 0;
        target = character;
    }

    public Marked(CharacterInstance character, int initTurnDuration)
    {
        debuffName = "Marked";
        turnDuration = initTurnDuration;
        target = character;
    }

    public override void UpdateEffect()
    {
        turnDuration--;

        if (turnDuration <= 0)
        {
            target.RemoveDebuff(this);
        }
    }
}
