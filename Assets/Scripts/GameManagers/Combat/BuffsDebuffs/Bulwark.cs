public class Bulwark : Buff
{
    public Bulwark()
    {
        BuffName = "Bulwark";
        TurnDuration = 0;
        Target = null;
    }

    public Bulwark(CharacterInstance character, int initTurnDuration)
    {
        BuffName = "Bulwark";
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
