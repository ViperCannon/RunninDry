public class Disarmed : Debuff
{
    public Disarmed()
    {
        DebuffName = "Disarmed";
        UI = null;
        TurnDuration = 0;
        Target = null;
    }

    public Disarmed(CharacterInstance character, BuffDebuffUI ui)
    {
        DebuffName = "Disarmed";
        UI = ui;
        TurnDuration = 1;
        Target = character;
    }

    public Disarmed(CharacterInstance character, BuffDebuffUI ui, int initTurnDuration)
    {
        DebuffName = "Disarmed";
        UI = ui;
        TurnDuration = initTurnDuration;
        Target = character;
    }

    public override void UpdateEffect()
    {
        TurnDuration--;

        if (TurnDuration <= 0)
        {
            Target.hasDisarmed = false;
            Target.RemoveDebuff(this);
        }
    }
}
