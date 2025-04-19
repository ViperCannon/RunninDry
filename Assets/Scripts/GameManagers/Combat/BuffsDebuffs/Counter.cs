public class Counter : Buff
{
    public Counter()
    {
        BuffName = "Counter";
        UI = null;
        TurnDuration = 0;
        Target = null;
    }

    public Counter(CharacterInstance character, BuffDebuffUI ui)
    {
        BuffName = "Counter";
        UI = ui;
        TurnDuration = 1;
        Target = character;
    }

    public Counter(CharacterInstance character, BuffDebuffUI ui, int initTurnDuration)
    {
        BuffName = "Counter";
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
