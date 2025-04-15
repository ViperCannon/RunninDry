public class Bleed : Debuff
{
    public Bleed()
    {
        debuffName = "Bleed";
        turnDuration = 0;
        target = null;
    }

    public Bleed(CharacterInstance character, int initTurnDuration)
    {
        debuffName = "Bleed";
        turnDuration = initTurnDuration;
        target = character;
    }

    public override void UpdateEffect()
    {
        turnDuration--;

        if(turnDuration <= 0)
        {
            target.isBleeding = false;
            target.RemoveDebuff(this);
        }
    }
}
