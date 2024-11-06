using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInstance : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;
    public float damageMultiplier = 1f;
    public float defenseMultiplier = 1f;

    public bool isStunned = false;

    public List<Buff> activeBuffs;
    public List<Debuff> activeDebuffs;

    private void Start()
    {
        activeBuffs = new List<Buff>();
        activeDebuffs = new List<Debuff>();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth < 0)
        {
            currentHealth = 0;
        }
        // Trigger any death or health change events here
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
}
