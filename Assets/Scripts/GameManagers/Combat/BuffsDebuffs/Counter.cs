public class Counter : Buff
{
    public Counter()
    {
        BuffName = "Counter";
        TurnDuration = 0;
        Target = null;
    }

    public Counter(CharacterInstance character, int initTurnDuration)
    {
        BuffName = "Counter";
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
