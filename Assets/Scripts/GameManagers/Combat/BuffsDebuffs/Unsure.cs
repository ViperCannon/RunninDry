public class Unsure : Debuff
{
    public Unsure()
    {
        DebuffName = "Unsure";
        UI = null;
        TurnDuration = 0;
        Target = null;
    }

    public Unsure(CharacterInstance character, BuffDebuffUI ui)
    {
        DebuffName = "Unsure";
        UI = ui;
        TurnDuration = 0;
        Target = character;
    }

    public Unsure(CharacterInstance character, BuffDebuffUI ui, int initTurnDuration)
    {
        DebuffName = "Unsure";
        UI = ui;
        TurnDuration = initTurnDuration;
        Target = character;
    }

    public override void UpdateEffect()
    {
        TurnDuration--;

        if (TurnDuration <= 0)
        {
            Target.hasUnsure = false;
            Target.RemoveDebuff(this);
        }
    }
}
