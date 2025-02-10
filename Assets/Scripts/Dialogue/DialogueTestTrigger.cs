using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTestTrigger : MonoBehaviour
{
    [Header("Ink JSON")]
    [SerializeField] private TextAsset inkJSON;

    public void TestDialogue()
    {
        if (DialogueManager.GetInstance().DialogueIsPlaying)
        {
            Debug.LogWarning("The dialogue box is already open!");
            return;
        }
        DialogueManager.GetInstance().OpenDialogue(inkJSON);
    }
}
