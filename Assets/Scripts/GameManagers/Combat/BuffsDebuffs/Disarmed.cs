public class Disarmed : Debuff
{
    public Disarmed()
    {
        debuffName = "Disarmed";
        turnDuration = 0;
        target = null;
    }

    public Disarmed(CharacterInstance character, int initTurnDuration)
    {
        debuffName = "Disarmed";
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
