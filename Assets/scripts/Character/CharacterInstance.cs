using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpeakeasyStreet;

public class CharacterInstance : MonoBehaviour, IDataPersistence
{
    CombatManager combatManager;
    
    public int maxHealth;
    public int currentHealth;
    public float damageMultiplier = 1f;
    public float defenseMultiplier = 1f;

    public bool hasBleeding = false;
    public bool hasBlind = false;
    public bool hasBulwark = false;
    public bool hasCounter = false;
    public bool hasDisarmed = false;
    public bool hasInspired = false;
    public bool hasMarked = false;
    public bool hasPissedOff = false;
    public bool hasProtected = false;
    public bool hasResilient = false;
    public bool hasUnsure = false;
    public bool isStunned = false;
    
    
    public bool isDowned = false;

    public List<Buff> activeBuffs = new();
    public List<Debuff> activeDebuffs = new();

    public GameObject buffsDebuffs;

    private void Start()
    {
        combatManager = CombatManager.Instance;
    }

    public virtual void TakeDamage(int damage)
    {
        
    }

    public void Heal(int amount)
    {
        TakeDamage(amount * -1);

        // Trigger health change events here
    }

    public void ApplyBuff(Buff buff)
    {
        activeBuffs.Add(buff);
        // Apply buff effects if needed
    }

    public bool RemoveBuff(Buff buff)
    {
        Destroy(buff.UI.gameObject);

        return activeBuffs.Remove(buff);
    }

    public void ApplyDebuff(Debuff debuff)
    {
        activeDebuffs.Add(debuff);
        // Apply debuff effects if needed
    }

    public bool RemoveDebuff(Debuff debuff)
    {
        Destroy(debuff.UI.gameObject);

        return activeDebuffs.Remove(debuff);
    }

    public void UpdateEffects()
    {
        // Update buffs and debuffs each turn or frame as necessary
    }
    public void LoadData(GameData data)
    {
        activeBuffs = data.activeBuffs;
        activeDebuffs = data.activeDebuffs;
    }

    public void SaveData(ref GameData data)
    {
        data.activeBuffs = activeBuffs;
        data.activeDebuffs = activeDebuffs;
    }

    public void ClearDebuffs()
    {
        for (int i = activeDebuffs.Count - 1; i >= 0; i--)
        {
            activeDebuffs[i].TurnDuration = 0;
            activeDebuffs[i].UpdateEffect();
        }
    }

    public void ClearBuffs()
    {
        for (int i = activeBuffs.Count - 1; i >= 0; i--)
        {
            activeBuffs[i].TurnDuration = 0;
            activeBuffs[i].UpdateEffect();
        }
    }
}
