public class Protected : Buff
{

    //Bodyguard Baldwin effect
    public Protected()
    {
        BuffName = "Protected";
        TurnDuration = 0;
        Target = null;
    }

    public Protected(CharacterInstance character, int initTurnDuration)
    {
        BuffName = "Protected";
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
