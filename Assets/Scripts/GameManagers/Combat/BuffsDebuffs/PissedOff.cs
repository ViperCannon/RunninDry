public class PissedOff : Buff
{
    public PissedOff()
    {
        BuffName = "PissedOff";
        TurnDuration = 0;
        Target = null;
    }

    public PissedOff(CharacterInstance character, int initTurnDuration)
    {
        BuffName = "PissedOff";
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
