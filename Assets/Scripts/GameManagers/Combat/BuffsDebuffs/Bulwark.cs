public class Bulwark : Buff
{
    public Bulwark()
    {
        BuffName = "Bulwark";
        UI = null;
        TurnDuration = 0;
        Target = null;
    }

    public Bulwark(CharacterInstance character, BuffDebuffUI ui)
    {
        BuffName = "Bulkwark";
        UI = ui;
        TurnDuration = 1;
        Target = character;
    }

    public Bulwark(CharacterInstance character, BuffDebuffUI ui, int initTurnDuration)
    {
        BuffName = "Bulwark";
        UI = ui;
        TurnDuration = initTurnDuration;
        Target = character;
    }

    public override void UpdateEffect()
    {
        TurnDuration--;

        if (TurnDuration <= 0)
        {
            Target.hasBulwark = false;
            Target.RemoveBuff(this);
        }
    }
}
