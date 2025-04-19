using UnityEngine;

[CreateAssetMenu(fileName = "New Debuff", menuName = "Debuff")]
public class DebuffSO : ScriptableObject
{
    public enum CombatDebuffType
    {
        Bleed,
        Blind,
        Disarmed,
        Marked,
        Stun,
        Unsure
    }

    public CombatDebuffType debuffName;
    public GameObject iconPrefab;

    public void CombatAddDebuff(CombatCard card, CharacterInstance target)
    {
        foreach (Debuff debuff in target.activeDebuffs)
        {
            if (debuff.DebuffName == debuffName.ToString())
            {
                Debug.Log("Adding additional turns to " + debuffName.ToString() + ".");
                debuff.AddStacks(card.turnDuration);
                return;
            }
        }

        if (card.chanceEffect > 0)
        {
            int chance = Random.Range(1, 101);

            if (chance > card.chanceEffect)
            {
                CombatAddDebuffHelper(card, target);
                Debug.Log("Applying " + debuffName.ToString() + ".");
            }
            else
            {
                Debug.Log(debuffName.ToString() + " chance failed!");
            }
        }
        else
        {
            CombatAddDebuffHelper(card, target);
            Debug.Log("Applying " + debuffName.ToString() + ".");
        }
    }

    void CombatAddDebuffHelper(CombatCard card, CharacterInstance target)
    {
        GameObject uiInstance = Instantiate(iconPrefab, target.buffsDebuffs.transform);

        switch (debuffName)
        {
            case CombatDebuffType.Bleed:

                Bleed bleed = new(target, uiInstance.GetComponent<BuffDebuffUI>(), card.turnDuration);
                target.ApplyDebuff(bleed);
                target.isBleeding = true;

                break;

            case CombatDebuffType.Blind:

                Blind blind = new(target, uiInstance.GetComponent<BuffDebuffUI>(), card.turnDuration);
                target.ApplyDebuff(blind);

                break;

            case CombatDebuffType.Disarmed:

                Disarmed disarmed = new(target, uiInstance.GetComponent<BuffDebuffUI>(), card.turnDuration);
                target.ApplyDebuff(disarmed);

                break;

            case CombatDebuffType.Marked:

                Marked marked = new(target, uiInstance.GetComponent<BuffDebuffUI>(), card.turnDuration);
                target.ApplyDebuff(marked);

                break;

            case CombatDebuffType.Stun:
     
                Stun stun = new(target, uiInstance.GetComponent<BuffDebuffUI>());

                target.ApplyDebuff(stun);
                target.isStunned = true;

                break;

            case CombatDebuffType.Unsure:

                Unsure unsure = new(target, uiInstance.GetComponent<BuffDebuffUI>(), card.turnDuration);
                target.ApplyDebuff(unsure);

                break;
        }
    }
}
