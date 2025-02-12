using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTestTrigger : MonoBehaviour
{
    private TextAsset currentJSON;

    [Header("List of Ink JSON Scenarios")]
    [SerializeField] private TextAsset[] inkJSONs;

    public void TestDialogue()
    {
        if (DialogueManager.GetInstance().DialogueIsPlaying)
        {
            Debug.LogWarning("The dialogue box is already open!");
            return;
        }

        SetNewDialogue();
        DialogueManager.GetInstance().OpenDialogue(currentJSON);
    }

    public void SetNewDialogue()
    {
        currentJSON = inkJSONs[Random.Range(0, inkJSONs.Length)];
    }
}
