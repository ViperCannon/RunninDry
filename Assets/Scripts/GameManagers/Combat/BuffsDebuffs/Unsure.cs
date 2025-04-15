public class Unsure : Debuff
{
    public Unsure()
    {
        debuffName = "Unsure";
        turnDuration = 0;
        target = null;
    }

    public Unsure(CharacterInstance character, int initTurnDuration)
    {
        debuffName = "Unsure";
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
