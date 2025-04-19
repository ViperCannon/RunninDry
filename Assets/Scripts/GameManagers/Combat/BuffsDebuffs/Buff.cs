public abstract class Buff
{
    string buffName;
    BuffDebuffUI ui;
    int turnDuration;
    CharacterInstance target;

   

    public string BuffName
    {
        get { return buffName; }
        set { buffName = value; }
    }

    public BuffDebuffUI UI
    {
        get { return ui; }
        set { ui = value; }
    }

    public int TurnDuration
    {
        get { return turnDuration; }
        set
        {
            turnDuration = value;
            if (ui != null && turnDuration >= 0)
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
        ui.SetTurns(turnDuration);
    }
}
