public abstract class Debuff
{
    public string debuffName;
    public int turnDuration;
    public CharacterInstance target;

    public abstract void UpdateEffect();

    public void AddStacks(int addTurnDuration)
    {
        turnDuration += addTurnDuration;
    }
}
