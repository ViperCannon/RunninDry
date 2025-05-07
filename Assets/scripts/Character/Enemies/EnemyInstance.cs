using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpeakeasyStreet;
using TMPro;

public class EnemyInstance : CharacterInstance
{
    [SerializeField]
    EnemyData baseData;

    [SerializeField]
    GameObject[] sprites;

    const float MAX_HEALTHBAR_SIZE = 7.2f;

    public GameObject healthBar;
    public GameObject healthText;
    public List<CombatCard> actions;

    public GameObject intentsContainer;

    [SerializeField]
    GameObject deathAnimation;

    [SerializeField]
    GameObject intent;

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

        UpdateHealthBar();
    }

    public void PerformAction()
    {
        Debug.Log("Enemy attack registered");
        CardEffectResolver.Instance.ResolveEnemyEffect(currentAction, currentTarget);

        if (intent != null)
        {
            intent.SetActive(false);
        }
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
            Debug.Log(CombatManager.Instance.lastPlayedCard.cardName);

            if(CombatManager.Instance.lastPlayedCard.cardName is "Sleight of Hand")
            {
                RelationshipsFramework.Instance.cash += 10;
                Debug.Log("Added 10 cash");
            }

            currentHealth = 0;
            isDowned = true;

            StartCoroutine(Die());
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

    public CharacterInstance SetRandomTarget()
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

        return currentTarget;
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
        if(intent != null)
        {
            intent.SetActive(false);
        }


        if (isStunned)
        {
            intent = intentsContainer.transform.GetChild(11).gameObject;
            intent.SetActive(true);
            return;
        }
        
        if(currentAction.subTypes.Count > 1 && currentAction.subTypes.Contains(CombatCard.CombatSubType.Projectile))
        {
            if (currentAction.subTypes.Contains(CombatCard.CombatSubType.Buff))
            {
                intent = intentsContainer.transform.GetChild(6).gameObject;
                intent.SetActive(true);
            }
            else
            {
                intent = intentsContainer.transform.GetChild(8).gameObject;
                intent.SetActive(true);
            }

            return;
        }
        else if (currentAction.subTypes.Count > 1 && currentAction.subTypes.Contains(CombatCard.CombatSubType.Melee))
        {
            if (currentAction.subTypes.Contains(CombatCard.CombatSubType.Buff))
            {
                intent = intentsContainer.transform.GetChild(5).gameObject;
                intent.SetActive(true);
            }
            else
            {
                intent = intentsContainer.transform.GetChild(7).gameObject;
                intent.SetActive(true);
            }

            return;
        }
        
        switch(currentAction.subTypes[0])
        {
            case CombatCard.CombatSubType.Melee:

                intent = intentsContainer.transform.GetChild(0).gameObject;
                intent.SetActive(true);

                break;

            case CombatCard.CombatSubType.Projectile:

                intent = intentsContainer.transform.GetChild(1).gameObject;
                intent.SetActive(true);

                break;

            case CombatCard.CombatSubType.Buff:
            case CombatCard.CombatSubType.Heal:

                intent = intentsContainer.transform.GetChild(2).gameObject;
                intent.SetActive(true);

                break;

            case CombatCard.CombatSubType.Debuff:

                intent = intentsContainer.transform.GetChild(3).gameObject;
                intent.SetActive(true);

                break;

            case CombatCard.CombatSubType.Special:

                intent = intentsContainer.transform.GetChild(9).gameObject;
                intent.SetActive(true);

                break;

            case CombatCard.CombatSubType.Flee:

                intent = intentsContainer.transform.GetChild(10).gameObject;
                intent.SetActive(true);

                break;
        }

    }

    IEnumerator Die()
    {
        Instantiate(deathAnimation, gameObject.transform);

        yield return new WaitForSeconds (.57f);
        gameObject.SetActive(false);
    }
}
