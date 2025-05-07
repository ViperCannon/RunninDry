public class Inspired : Buff
{
    public Inspired()
    {
        BuffName = "Inspired";
        UI = null;
        TurnDuration = 0;
        Target = null;
    }

    public Inspired(CharacterInstance character, BuffDebuffUI ui)
    {
        BuffName = "Inspired";
        UI = ui;
        TurnDuration = 1;
        Target = character;
    }

    public Inspired(CharacterInstance character, BuffDebuffUI ui, int initTurnDuration)
    {
        BuffName = "Inspired";
        UI = ui;
        TurnDuration = initTurnDuration;
        Target = character;
    }

    public override void UpdateEffect()
    {
        TurnDuration--;

        if (TurnDuration <= 0)
        {
            Target.hasInspired = false;
            Target.RemoveBuff(this);
        }
    }
}
