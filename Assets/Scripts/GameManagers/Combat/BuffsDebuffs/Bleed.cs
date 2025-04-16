public class Bleed : Debuff
{
    public Bleed()
    {
        DebuffName = "Bleed";
        TurnDuration = 0;
        Target = null;
    }

    public Bleed(CharacterInstance character, int initTurnDuration)
    {
        DebuffName = "Bleed";
        TurnDuration = initTurnDuration;
        Target = character;
    }

    public override void UpdateEffect()
    {
        TurnDuration--;

        if(TurnDuration <= 0)
        {
            Target.isBleeding = false;
            Target.RemoveDebuff(this);
        }
    }
}
