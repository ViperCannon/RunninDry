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
    public bool isBleeding = false;
    public bool isResilient = false;
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
}
