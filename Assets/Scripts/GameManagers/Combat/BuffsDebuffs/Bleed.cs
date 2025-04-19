public class Bleed : Debuff
{
    public Bleed()
    {
        DebuffName = "Bleed";
        UI = null;
        TurnDuration = 0;
        Target = null;
    }

    public Bleed(CharacterInstance character, BuffDebuffUI ui)
    {
        DebuffName = "Bleed";
        UI = ui;
        TurnDuration = 1;
        Target = character;
    }

    public Bleed(CharacterInstance character, BuffDebuffUI ui, int initTurnDuration)
    {
        DebuffName = "Bleed";
        UI = ui;
        TurnDuration = initTurnDuration;
        Target = character;
    }

    public override void UpdateEffect()
    {
        TurnDuration--;

        if(TurnDuration <= 0)
        {
            Target.isBleeding = false;
            Target.RemoveDebuff(this);
        }
    }
}
