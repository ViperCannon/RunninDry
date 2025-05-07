public class Resilient : Buff
{
    public Resilient()
    {
        BuffName = "Resilient";
        UI = null;
        TurnDuration = 0;
        Target = null;
    }

    public Resilient(CharacterInstance character, BuffDebuffUI ui)
    {
        BuffName = "Resilient";
        UI = ui;
        TurnDuration = 1;
        Target = character;
    }

    public Resilient(CharacterInstance character, BuffDebuffUI ui, int initTurnDuration)
    {
        BuffName = "Resilient";
        UI = ui;
        TurnDuration = initTurnDuration;
        Target = character;
    }

    public override void UpdateEffect()
    {
        TurnDuration--;

        if (TurnDuration <= 0)
        {
            Target.hasResilient = false;
            Target.RemoveBuff(this);
        }
    }
}
