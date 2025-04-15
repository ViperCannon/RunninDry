public class Stun : Debuff
{
    public Stun()
    {
        debuffName = "Stun";
        turnDuration = 0;
        target = null;
    }

    public Stun(CharacterInstance character)
    {
        debuffName = "Stun";
        turnDuration = 1;
        target = character;
    }

    public Stun(CharacterInstance character, int initTurnDuration)
    {
        debuffName = "Stun";
        turnDuration = initTurnDuration;
        target = character;
    }

    public override void UpdateEffect()
    {
        turnDuration--;

        if (turnDuration <= 0)
        {
            target.isStunned = false;
            target.RemoveDebuff(this);
        }
    }
}
