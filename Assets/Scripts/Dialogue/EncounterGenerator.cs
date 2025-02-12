using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EncounterGenerator : MonoBehaviour
{
    [Header("Encounter Lists")]
    [Tooltip("List of Combat Encounter Ink JSONs")]
    [SerializeField] private TextAsset[] combatJSONs;
    [Tooltip("List of  Event Encounter Ink JSONs")]
    [SerializeField] private TextAsset[] eventJSONs;
    [Tooltip("List of Negotiation Encounter Ink JSONs")]
    [SerializeField] private TextAsset[] negotiationJSONs;

    private TextAsset currentEncounter;

    public void PlayCurrentEncounter()
    {
        if (DialogueManager.GetInstance().DialogueIsPlaying)
        {
            Debug.LogWarning("The dialogue box is already open!");
            return;
        }
        DialogueManager.GetInstance().OpenDialogue(currentEncounter);
    }

    public void SetNewCombat()
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
        PlayCurrentEncounter();
    }

    public void SetNewEvent()
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
        PlayCurrentEncounter();
    }

    public void SetNewNegotiation()
    {
        if (DialogueManager.GetInstance().DialogueIsPlaying)
        {
            Debug.LogWarning("Cannot set a new negotiation encounter cannot be set because the dialogue box is open!");
            return;
        }
        if (negotiationJSONs.Length == 0)
        {
            Debug.LogWarning("Cannot set a new negotiation encounter because the negotiation encounter list is empty!");
            return;
        }
        currentEncounter = negotiationJSONs[Random.Range(0, negotiationJSONs.Length)];
        PlayCurrentEncounter();
    }
}
