using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpeakeasyStreet;

public class EnemyInstance : CharacterInstance
{
    [SerializeField]
    EnemyData baseData;

    [SerializeField]
    GameObject[] sprites;

    const float MAX_HEALTHBAR_SIZE = 7.2f;
    GameObject healthBar;

    public List<CombatCard> actions;

    [SerializeField]
    CombatCard currentAction;
    [SerializeField]
    CharacterInstance currentTarget;

   void Start()
    {
        int index = Random.Range(0, sprites.Length);

        sprites[index].SetActive(true);

        maxHealth = baseData.baseMaxHealth;
        currentHealth = maxHealth;

        foreach (Transform child in transform)
        {
            if (child.CompareTag("HealthBar"))
            {
                healthBar = child.GetChild(0).gameObject;
                break;
            }
        }

        UpdateHealthBar();
    }

    public void PerformAction()
    {
        Debug.Log("Enemy attack registered");
        CardEffectResolver.Instance.ResolveEnemyEffect(currentAction, currentTarget);
    }

    public override void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            isDowned = true;
            gameObject.SetActive(false);
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

    public void SetRandomAction()
    {
        currentAction = actions[Random.Range(0, actions.Count)];
    }

    public void SetAction(int i)
    {
        if (i < 0 || i >= actions.Count)
        {
            currentAction = null;
        }
        else
        {
            currentAction = actions[i];
        }
    }

    public CombatCard GetCurrentAction()
    {
        return currentAction;
    }

    public void SetRandomTarget()
    {
        if (!currentAction.IsAOE() && currentAction.validTargets[0] != CombatCard.CardTarget.Self) //Must be a single target action in this case
        {
            int index;
            CharacterInstance temp = null;

            if (currentAction.validTargets[0] == CombatCard.CardTarget.Player)
            {
                index = Random.Range(0, 3);

                while (temp == null)
                {
                    if (!CombatManager.Instance.Allies[index].isDowned)
                    {
                        temp = CombatManager.Instance.Allies[index];
                    }
                    else
                    {
                        index = Random.Range(0, 3);
                    }
                }

                currentTarget = temp;
            }
            else
            {
                index = Random.Range(0, CombatManager.Instance.Enemies.Count);

                while (temp == null)
                {
                    if (CombatManager.Instance.Enemies[index] != null)
                    {
                        temp = CombatManager.Instance.Enemies[index];
                    }
                }

                currentTarget = temp;
            }
        }
        else if (currentAction.validTargets[0] == CombatCard.CardTarget.Self)
        {
            currentTarget = this;
        }
        else //AOE don't need a specified target
        {
            currentTarget = null;
        }
    }

    public void SetTarget(CharacterInstance target)
    {
        currentTarget = target;
    }

    public CharacterInstance GetTarget()
    {
       return currentTarget;
    }

    public void UpdateEnemyIntent()
    {
        //change visual indicators of what the enemy is doing this turn and who they are targeting if applicable
    }
}
