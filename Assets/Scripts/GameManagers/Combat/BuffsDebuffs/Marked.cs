public class Marked : Debuff
{
    public Marked()
    {
        DebuffName = "Marked";
        UI = null;
        TurnDuration = 0;
        Target = null;
    }

    public Marked(CharacterInstance character, BuffDebuffUI ui)
    {
        DebuffName = "Marked";
        UI = ui;
        TurnDuration = 0;
        Target = character;
    }

    public Marked(CharacterInstance character, BuffDebuffUI ui, int initTurnDuration)
    {
        DebuffName = "Marked";
        UI = ui;
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
