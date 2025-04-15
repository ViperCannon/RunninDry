public class Inspired : Buff
{
    public Inspired()
    {
        buffName = "Inspired";
        turnDuration = 0;
        target = null;
    }

    public Inspired(CharacterInstance character, int initTurnDuration)
    {
        buffName = "Inspired";
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
