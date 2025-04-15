public abstract class Buff
{
    public string buffName;
    public int turnDuration;
    public CharacterInstance target;

    public abstract void UpdateEffect();

    public void AddStacks(int addTurnDuration)
    {
        turnDuration += addTurnDuration;
    }
}
