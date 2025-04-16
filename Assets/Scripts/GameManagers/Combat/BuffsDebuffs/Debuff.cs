public abstract class Debuff
{
    string debuffName;
    int turnDuration;
    CharacterInstance target;

    public string DebuffName
    {
        get { return debuffName; }
        set { debuffName = value; }
    }

    public int TurnDuration
    {
        get { return turnDuration; }
        set { turnDuration = value; }
    }

    public CharacterInstance Target
    {
        get { return target; }
        set { target = value; }
    }

    public abstract void UpdateEffect();

    public void AddStacks(int addTurnDuration)
    {
        turnDuration += addTurnDuration;
    }
}
