public class Blind : Debuff
{
    public Blind()
    {
        DebuffName = "Blind";
        UI = null;
        TurnDuration = 0;
        Target = null;
    }

    public Blind(CharacterInstance character, BuffDebuffUI ui)
    {
        DebuffName = "Blind";
        UI = ui;
        TurnDuration = 1;
        Target = character;
    }

    public Blind(CharacterInstance character, BuffDebuffUI ui, int initTurnDuration)
    {
        DebuffName = "Blind";
        UI = ui;
        TurnDuration = initTurnDuration;
        Target = character;
    }

    public override void UpdateEffect()
    {
        TurnDuration--;

        if (TurnDuration <= 0)
        {
            Target.hasBlind = false;
            Target.RemoveDebuff(this);
        }
    }
}
