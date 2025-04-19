public class PissedOff : Buff
{
    public PissedOff()
    {
        BuffName = "PissedOff";
        UI = null;
        TurnDuration = 0;
        Target = null;
    }

    public PissedOff(CharacterInstance character, BuffDebuffUI ui)
    {
        BuffName = "PissedOff";
        UI = ui;
        TurnDuration = 1;
        Target = character;
    }

    public PissedOff(CharacterInstance character, BuffDebuffUI ui, int initTurnDuration)
    {
        BuffName = "PissedOff";
        UI = ui;
        TurnDuration = initTurnDuration;
        Target = character;
    }
    public override void UpdateEffect()
    {
        TurnDuration--;

        if (TurnDuration <= 0)
        {
            Target.RemoveBuff(this);
        }
    }
}
