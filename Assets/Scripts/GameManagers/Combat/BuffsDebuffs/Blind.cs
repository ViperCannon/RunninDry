public class Blind : Debuff
{
    public Blind()
    {
        DebuffName = "Blind";
        TurnDuration = 0;
        Target = null;
    }

    public Blind(CharacterInstance character)
    {
        DebuffName = "Blind";
        TurnDuration = 1;
        Target = character;
    }

    public Blind(CharacterInstance character, int initTurnDuration)
    {
        DebuffName = "Blind";
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
