public abstract class Buff
{
    string buffName;
    int turnDuration;
    CharacterInstance target;

    public BuffDebuffUI ui;
    public string BuffName
    {
        get { return buffName; }
        set { buffName = value; }
    }

    public int TurnDuration
    {
        get { return turnDuration; }
        set
        {
            turnDuration = value;
            if (ui != null)
            {
                ui.SetTurns(turnDuration);
            }
        }
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
