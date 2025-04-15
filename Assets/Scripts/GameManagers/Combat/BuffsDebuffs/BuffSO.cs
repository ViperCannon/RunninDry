using UnityEngine;

[CreateAssetMenu(fileName = "New Buff", menuName = "Buff")]
public class BuffSO : ScriptableObject
{
    public enum CombatBuffType
    {
        Bulwark,
        Counter,
        Inspired,
        PissedOff,
        Protected,
        Resilient
    }

    public CombatBuffType buffName;

    public void CombatAddBuff(CombatCard card, CharacterInstance target)
    {
        foreach (Buff buff in target.activeBuffs)
        {
            if (buff.buffName == buffName.ToString())
            {
                Debug.Log("Adding additional turns to " + buffName.ToString() + ".");
                buff.AddStacks(card.turnDuration);
                return;
            }
        }

        if (card.chanceEffect > 0)
        {
            int chance = Random.Range(1, 101);

            if (chance > card.chanceEffect)
            {
                CombatAddBuffHelper(card, target);
                Debug.Log("Applying " + buffName.ToString() + ".");
            }
            else
            {
                Debug.Log(buffName.ToString() + " chance failed!");
            }
        }
        else
        {
            CombatAddBuffHelper(card, target);
            Debug.Log("Applying " + buffName.ToString() + ".");
        }
    }

    void CombatAddBuffHelper(CombatCard card, CharacterInstance target)
    {
        switch (buffName)
        {
            case CombatBuffType.Bulwark:

                Bulwark bulwark = new(target, card.turnDuration);
                target.ApplyBuff(bulwark);

                break;

            case CombatBuffType.Counter:

                Counter counter = new(target, card.turnDuration);
                target.ApplyBuff(counter);

                break;

            case CombatBuffType.Inspired:

                Inspired inspired = new(target, card.turnDuration);
                target.ApplyBuff(inspired);

                break;

            case CombatBuffType.PissedOff:

                PissedOff pissedOff = new(target, card.turnDuration);
                target.ApplyBuff(pissedOff);

                break;

            case CombatBuffType.Protected:

                Protected protect = new(target, card.turnDuration);
                target.ApplyBuff(protect);

                break;

            case CombatBuffType.Resilient:

                Resilient resilient = new(target, card.turnDuration);
                target.ApplyBuff(resilient);
                target.isResilient = true;

                break;
        }
    }
}
