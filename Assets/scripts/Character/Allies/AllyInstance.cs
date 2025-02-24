using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class AllyInstance : CharacterInstance
{
    [SerializeField]
    AllyData baseData;

    const float MAX_HEALTHBAR_SIZE = 7.2f;
    GameObject healthBar;

    public int caps;

    void Start()
    {
        maxHealth = baseData.baseMaxHealth;
        currentHealth = maxHealth;
        
        foreach (Transform child in transform)
        {
            if(child.CompareTag("HealthBar"))
            {
                healthBar = child.GetChild(0).gameObject;
                break;
            }
        }

        UpdateHealthBar();
    }

    public override void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            isDowned = true;
        }
        else if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
            isDowned = false;
        }
        else
        {
            isDowned = false;
        }

        UpdateHealthBar();
    }

    private void UpdateHealthBar()
    {
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
}
