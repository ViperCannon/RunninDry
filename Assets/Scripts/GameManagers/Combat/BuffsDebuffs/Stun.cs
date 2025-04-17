public class Stun : Debuff
{
    public Stun()
    {
        DebuffName = "Stun";
        TurnDuration = 0;
        Target = null;
    }

    public Stun(CharacterInstance character, BuffDebuffUI temp)
    {
        DebuffName = "Stun";
        ui = temp;
        TurnDuration = 1;
        Target = character;

        ui.SetTurns(TurnDuration);
    }

    public Stun(CharacterInstance character, int initTurnDuration, BuffDebuffUI temp)
    {
        DebuffName = "Stun";
        ui = temp;
        TurnDuration = initTurnDuration;
        Target = character;

        ui.SetTurns(TurnDuration);
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

    public new void AddStacks(int addTurnDuration)
    {
        
    }
}
