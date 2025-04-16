public class Stun : Debuff
{
    public Stun()
    {
        DebuffName = "Stun";
        TurnDuration = 0;
        Target = null;
    }

    public Stun(CharacterInstance character)
    {
        DebuffName = "Stun";
        TurnDuration = 1;
        Target = character;
    }

    public Stun(CharacterInstance character, int initTurnDuration)
    {
        DebuffName = "Stun";
        TurnDuration = initTurnDuration;
        Target = character;
    }

    public override void UpdateEffect()
    {
        TurnDuration--;

        if (TurnDuration <= 0)
        {
            Target.isStunned = false;
            Target.RemoveDebuff(this);
        }
    }
}
