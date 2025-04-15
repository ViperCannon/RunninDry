public class Resilient : Buff
{
    public Resilient()
    {
        buffName = "Resilient";
        turnDuration = 0;
        target = null;
    }

    public Resilient(CharacterInstance character, int initTurnDuration)
    {
        buffName = "Resilient";
        turnDuration = initTurnDuration;
        target = character;
    }

    public override void UpdateEffect()
    {
        turnDuration--;

        if (turnDuration <= 0)
        {
            target.isResilient = false;
            target.RemoveBuff(this);
        }
    }
}
