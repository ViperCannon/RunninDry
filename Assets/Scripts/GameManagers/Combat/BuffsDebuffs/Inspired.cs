public class Inspired : Buff
{
    public Inspired()
    {
        BuffName = "Inspired";
        TurnDuration = 0;
        Target = null;
    }

    public Inspired(CharacterInstance character, int initTurnDuration)
    {
        BuffName = "Inspired";
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
