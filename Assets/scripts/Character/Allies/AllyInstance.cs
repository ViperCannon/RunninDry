using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class AllyInstance : CharacterInstance
{
    [SerializeField]
    AllyData baseData;

    const float MAX_HEALTHBAR_SIZE = 7.2f;
    
    PolygonCollider2D col;
    
    public GameObject healthBar;
    public GameObject healthText;
    public int caps;
    void Start()
    {
        maxHealth = baseData.baseMaxHealth;
        currentHealth = maxHealth;

        col = GetComponentInChildren<PolygonCollider2D>();

        UpdateHealthBar();
    }

    public override void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0 && hasResilient)
        {
            currentHealth = 1;

            for (int i = activeBuffs.Count - 1; i >= 0; i--)
            {
                if (activeBuffs[i] is Resilient)
                {
                    activeBuffs[i].UpdateEffect();
                    break;
                }
            }

            Debug.Log("Defied death!");
        }
        else if (currentHealth <= 0)
        {
            currentHealth = 0;
            isDowned = true;
            col.enabled = false;

            ClearDebuffs();
            ClearBuffs();
        }
        else if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
            isDowned = false;
            col.enabled = true;
        }
        else
        {
            isDowned = false;
            col.enabled = true;

            if (hasCounter)
            {
                CounterDamage.CalcCounter(damage);

                for (int i = activeBuffs.Count - 1; i >= 0; i--)
                {
                    if(activeBuffs[i] is Counter)
                    {
                        activeBuffs[i].UpdateEffect();
                        break;
                    }
                }
            }
        }

        UpdateHealthBar();
    }

    private void UpdateHealthBar()
    {
        healthText.GetComponent<TextMeshPro>().text = currentHealth.ToString();

        float temp = (float)currentHealth / maxHealth;

        if (temp > 0.7f)
        {
            healthBar.GetComponentInChildren<SpriteRenderer>().color = Color.green;
        }
        else if (temp > 0.3f)
        {
            healthBar.GetComponentInChildren<SpriteRenderer>().color = Color.yellow;
        }
        else
        {
            healthBar.GetComponentInChildren<SpriteRenderer>().color = Color.red;
        }

        Vector3 newScale = new Vector3(MAX_HEALTHBAR_SIZE * temp, 0.8f, 1f);

        healthBar.transform.localScale = newScale;
    }

    public string GetName()
    {
        return baseData.AllyName;
    }
}
