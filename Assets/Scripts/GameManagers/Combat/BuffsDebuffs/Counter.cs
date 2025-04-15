public class Counter : Buff
{
    public Counter()
    {
        buffName = "Counter";
        turnDuration = 0;
        target = null;
    }

    public Counter(CharacterInstance character, int initTurnDuration)
    {
        buffName = "Counter";
        turnDuration = initTurnDuration;
        target = character;
    }

    public override void UpdateEffect()
    {
        turnDuration--;

        if (turnDuration <= 0)
        {
            target.RemoveBuff(this);
        }
    }
}
