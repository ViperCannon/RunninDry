public class Unsure : Debuff
{
    public Unsure()
    {
        DebuffName = "Unsure";
        TurnDuration = 0;
        Target = null;
    }

    public Unsure(CharacterInstance character, int initTurnDuration)
    {
        DebuffName = "Unsure";
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
