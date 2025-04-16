public class Resilient : Buff
{
    public Resilient()
    {
        BuffName = "Resilient";
        TurnDuration = 0;
        Target = null;
    }

    public Resilient(CharacterInstance character, int initTurnDuration)
    {
        BuffName = "Resilient";
        TurnDuration = initTurnDuration;
        Target = character;
    }

    public override void UpdateEffect()
    {
        TurnDuration--;

        if (TurnDuration <= 0)
        {
            Target.isResilient = false;
            Target.RemoveBuff(this);
        }
    }
}
