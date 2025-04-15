public class Bulwark : Buff
{
    public Bulwark()
    {
        buffName = "Bulwark";
        turnDuration = 0;
        target = null;
    }

    public Bulwark(CharacterInstance character, int initTurnDuration)
    {
        buffName = "Bulwark";
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
