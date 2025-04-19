public class Protected : Buff
{

    //Bodyguard Baldwin effect
    public Protected()
    {
        BuffName = "Protected";
        UI = null;
        TurnDuration = 0;
        Target = null;
    }

    public Protected(CharacterInstance character, BuffDebuffUI ui)
    {
        BuffName = "Protected";
        UI = ui;
        TurnDuration = 1;
        Target = character;
    }

    public Protected(CharacterInstance character, BuffDebuffUI ui, int initTurnDuration)
    {
        BuffName = "Protected";
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
