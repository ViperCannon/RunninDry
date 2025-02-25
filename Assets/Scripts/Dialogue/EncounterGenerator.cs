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
        if (DialogueManager.GetInstance().DialogueIsPlaying)
        {
            Debug.LogWarning("The dialogue box is already open!");
            return;
        }
        DialogueManager.GetInstance().OpenDialogue(currentEncounter);
    }

    public void SetNewCombatDialogue()
    {
        if (DialogueManager.GetInstance().DialogueIsPlaying)
        {
            Debug.LogWarning("Cannot set a new combat encounter because the dialogue box is open!");
            return;
        }
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
        if (DialogueManager.GetInstance().DialogueIsPlaying)
        {
            Debug.LogWarning("Cannot set a new negotiation encounter because the dialogue box is open!");
            return;
        }
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
        if (DialogueManager.GetInstance().DialogueIsPlaying)
        {
            Debug.LogWarning("Cannot set a new event encounter because the dialogue box is open!");
            return;
        }
        if (eventJSONs.Length == 0)
        {
            Debug.LogWarning("Cannot set a new event encounter because the event encounter list is empty!");
            return;
        }
        currentEncounter = eventJSONs[Random.Range(0, eventJSONs.Length)];
        PlayCurrentDialogue();
    }
}
