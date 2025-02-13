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

    public bool isStunned = false;
    public bool isResilient = false;
    public bool isDowned = false;

    public List<Buff> activeBuffs;
    public List<Debuff> activeDebuffs;

    private void Start()
    {
        combatManager = FindObjectOfType<CombatManager>();

        activeBuffs = new List<Buff>();
        activeDebuffs = new List<Debuff>();
    }

    public virtual void TakeDamage(int damage)
    {
    
    }

    public void Heal(int amount)
    {
        currentHealth += amount;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        // Trigger health change events here
    }

    public void ApplyBuff(Buff buff)
    {
        activeBuffs.Add(buff);
        // Apply buff effects if needed
    }

    public bool RemoveBuff(Buff buff)
    {
        return activeBuffs.Remove(buff);
    }

    public void ApplyDebuff(Debuff debuff)
    {
        activeDebuffs.Add(debuff);
        // Apply debuff effects if needed
    }

    public bool RemoveDebuff(Debuff debuff)
    {
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
}
