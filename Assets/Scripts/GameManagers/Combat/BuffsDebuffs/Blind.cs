public class Blind : Debuff
{
    public Blind()
    {
        debuffName = "Blind";
        turnDuration = 0;
        target = null;
    }

    public Blind(CharacterInstance character)
    {
        debuffName = "Blind";
        turnDuration = 1;
        target = character;
    }

    public Blind(CharacterInstance character, int initTurnDuration)
    {
        debuffName = "Blind";
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
