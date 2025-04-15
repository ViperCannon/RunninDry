public class Protected : Buff
{

    //Bodyguard Baldwin effect
    public Protected()
    {
        buffName = "Protected";
        turnDuration = 0;
        target = null;
    }

    public Protected(CharacterInstance character, int initTurnDuration)
    {
        buffName = "Protected";
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
