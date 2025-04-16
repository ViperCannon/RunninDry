public class Marked : Debuff
{
    public Marked()
    {
        DebuffName = "Marked";
        TurnDuration = 0;
        Target = null;
    }

    public Marked(CharacterInstance character)
    {
        DebuffName = "Marked";
        TurnDuration = 0;
        Target = character;
    }

    public Marked(CharacterInstance character, int initTurnDuration)
    {
        DebuffName = "Marked";
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
