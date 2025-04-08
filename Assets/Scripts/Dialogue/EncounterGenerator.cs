using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EncounterGenerator : MonoBehaviour
{
    private static EncounterGenerator Instance;

    [Header("Encounter Lists")]
    [Tooltip("List of Combat Encounter Ink JSONs")]
    [SerializeField] private TextAsset[] combatJSONs;
    [Tooltip("List of Negotiation Encounter Ink JSONs")]
    [SerializeField] private TextAsset[] negotiationJSONs;
    [Tooltip("List of Event Encounter Ink JSONs")]
    [SerializeField] private TextAsset[] eventJSONs;
    [Tooltip("List of Shop Encounter Ink JSONs")]
    [SerializeField] private TextAsset[] shopJSONs;
    [Tooltip("List of Pit Stop Encounter Ink JSONs")]
    [SerializeField] private TextAsset[] pitStopJSONs;
    [Tooltip("List of Elite Encounter Ink JSONs")]
    [SerializeField] private TextAsset[] eliteJSONs;
    [Tooltip("List of Boss Encounter Ink JSONs")]
    [SerializeField] private TextAsset[] bossJSONs;
    [Tooltip("Blank Encounter Ink JSON")]
    [SerializeField] private TextAsset blankJSON;
    [Tooltip("List of Tutorial Ink JSONs")]
    [SerializeField] private TextAsset[] tutorialJSONs;

    private TextAsset currentEncounter;

    public static EncounterGenerator GetInstance()
    {
        return Instance;
    }

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    public void PlayCurrentDialogue()
    {
        DialogueManager.GetInstance().OpenDialogue(currentEncounter);
    }

    public void SetNewCombatDialogue()
    {
        if (combatJSONs.Length == 0)
        {
            Debug.LogWarning("Cannot set a new combat encounter because the combat encounter list is empty!");
            return;
        }
        currentEncounter = combatJSONs[Random.Range(0, combatJSONs.Length)];
        PlayCurrentDialogue();
    }

    public void SetNewNegotiationDialogue()
    {
        if (negotiationJSONs.Length == 0)
        {
            Debug.LogWarning("Cannot set a new negotiation encounter because the negotiation encounter list is empty!");
            return;
        }
        currentEncounter = negotiationJSONs[Random.Range(0, negotiationJSONs.Length)];
        PlayCurrentDialogue();
    }

    public void SetNewEventDialogue()
    {
        if (eventJSONs.Length == 0)
        {
            Debug.LogWarning("Cannot set a new event encounter because the event encounter list is empty!");
            return;
        }
        currentEncounter = eventJSONs[Random.Range(0, eventJSONs.Length)];
        PlayCurrentDialogue();
    }

    public void SetNewShopDialogue()
    {
        if (shopJSONs.Length == 0)
        {
            Debug.LogWarning("Cannot set a new shop encounter because the shop encounter list is empty!");
            return;
        }
        currentEncounter = shopJSONs[Random.Range(0, shopJSONs.Length)];
        PlayCurrentDialogue();
    }

    public void SetNewPitStopDialogue()
    {
        if (pitStopJSONs.Length == 0)
        {
            Debug.LogWarning("Cannot set a pit stop encounter because the pit stop encounter list is empty!");
            return;
        }
        currentEncounter = pitStopJSONs[Random.Range(0, pitStopJSONs.Length)];
        PlayCurrentDialogue();
    }

    public void SetNewEliteDialogue()
    {
        if (eliteJSONs.Length == 0)
        {
            Debug.LogWarning("Cannot set a elite encounter because the elite encounter list is empty!");
            return;
        }
        currentEncounter = eliteJSONs[Random.Range(0, eliteJSONs.Length)];
        PlayCurrentDialogue();
    }

    public void SetNewBossDialogue()
    {
        if (bossJSONs.Length == 0)
        {
            Debug.LogWarning("Cannot set a boss encounter because the boss encounter list is empty!");
            return;
        }
        currentEncounter = bossJSONs[Random.Range(0, bossJSONs.Length)];
        PlayCurrentDialogue();
        GameManager.Instance.atBoss = true;
    }

    public void SetBlankDialogue()
    {
        if (blankJSON == null)
        {
            Debug.LogWarning("Cannot set a blank encounter because the blank encounter JSON hasn't been initialized!");
            return;
        }
        currentEncounter = blankJSON;
        PlayCurrentDialogue();
    }

    public void SetTutorialDialogue(int i)
    {
        if (i < 0 || i >= tutorialJSONs.Length)
        {
            Debug.LogWarning("This index is out of bounds!");
            return;
        }
        currentEncounter = tutorialJSONs[i];
        PlayCurrentDialogue();
    }
}
