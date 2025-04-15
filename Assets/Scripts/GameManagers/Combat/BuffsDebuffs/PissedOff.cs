public class PissedOff : Buff
{
    public PissedOff()
    {
        buffName = "PissedOff";
        turnDuration = 0;
        target = null;
    }

    public PissedOff(CharacterInstance character, int initTurnDuration)
    {
        buffName = "PissedOff";
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
