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
    public GameObject iconPrefab;

    public void CombatAddBuff(CombatCard card, CharacterInstance target)
    {
        foreach (Buff buff in target.activeBuffs)
        {
            if (buff.BuffName == buffName.ToString())
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
        GameObject uiInstance = Instantiate(iconPrefab, target.buffsDebuffs.transform);

        switch (buffName)
        {
            case CombatBuffType.Bulwark:

                Bulwark bulwark = new(target, uiInstance.GetComponent<BuffDebuffUI>(), card.turnDuration);
                target.ApplyBuff(bulwark);
                target.hasBulwark = true;

                break;

            case CombatBuffType.Counter:

                Counter counter = new(target, uiInstance.GetComponent<BuffDebuffUI>(), card.turnDuration);
                target.ApplyBuff(counter);
                target.hasCounter = true;

                break;

            case CombatBuffType.Inspired:

                Inspired inspired = new(target, uiInstance.GetComponent<BuffDebuffUI>(), card.turnDuration);
                target.ApplyBuff(inspired);
                target.hasInspired = true;

                break;

            case CombatBuffType.PissedOff:

                PissedOff pissedOff = new(target, uiInstance.GetComponent<BuffDebuffUI>(), card.turnDuration);
                target.ApplyBuff(pissedOff);
                target.hasPissedOff = true;

                break;

            case CombatBuffType.Protected:

                Protected protect = new(target, uiInstance.GetComponent<BuffDebuffUI>(), card.turnDuration);
                target.ApplyBuff(protect);
                target.hasProtected = true;

                break;

            case CombatBuffType.Resilient:

                Resilient resilient = new(target, uiInstance.GetComponent<BuffDebuffUI>(), card.turnDuration);
                target.ApplyBuff(resilient);
                target.hasResilient = true;

                break;
        }
    }
}
