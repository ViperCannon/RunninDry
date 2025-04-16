public class Disarmed : Debuff
{
    public Disarmed()
    {
        DebuffName = "Disarmed";
        TurnDuration = 0;
        Target = null;
    }

    public Disarmed(CharacterInstance character, int initTurnDuration)
    {
        DebuffName = "Disarmed";
        TurnDuration = initTurnDuration;
        Target = character;
    }

    public override void UpdateEffect()
    {
        TurnDuration--;

        if (TurnDuration <= 0)
        {
            Target.RemoveDebuff(this);
        }
    }
}
