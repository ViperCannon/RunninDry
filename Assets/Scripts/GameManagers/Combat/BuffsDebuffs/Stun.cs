public class Stun : Debuff
{
    public Stun()
    {
        DebuffName = "Stun";
        UI = null;
        TurnDuration = 0;
        Target = null;
    }

    public Stun(CharacterInstance character, BuffDebuffUI ui)
    {
        DebuffName = "Stun";
        UI = ui;
        TurnDuration = 1;
        Target = character;
    }

    public Stun(CharacterInstance character, BuffDebuffUI ui, int initTurnDuration)
    {
        DebuffName = "Stun";
        UI = ui;
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

    public new void AddStacks(int addTurnDuration)
    {
        
    }
}
