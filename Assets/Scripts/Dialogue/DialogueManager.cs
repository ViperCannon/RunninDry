using Ink.Runtime;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.EventSystems;
using static Ink.Runtime.Story;

public class DialogueManager : MonoBehaviour
{
    private static DialogueManager instance;

    [Header("Dialogue UI")]
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TextMeshProUGUI dialogueText;

    private Story currentStory;
    public bool DialogueIsPlaying {get; private set;}

    [Header("Choices UI")]
    [SerializeField] private GameObject[] choices;
    private TextMeshProUGUI[] choicesText;

    private InkExternalFunctions externalFunctions;

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Debug.LogWarning("Found more than one Dialogue Manager instance in the scene! Removing this one!");
            Destroy(this);
        }
        else instance = this;

        externalFunctions = new InkExternalFunctions();
    }

    private void Start()
    {
        DialogueIsPlaying = false;
        dialoguePanel.SetActive(false);

        choicesText = new TextMeshProUGUI[choices.Length];
        for (int i = 0; i < choices.Length; i++)
        {
            choices[i].SetActive(false);
            choicesText[i] = choices[i].GetComponentInChildren<TextMeshProUGUI>();
        }
    }

    private void Update()
    {
        
        // No need to update anything if the dialogue prompt is closed!
        if (!DialogueIsPlaying)
        {
            return;
        }

        if (dialogueText.text == "")
        {
            CloseDialogue();
        }

        // Handle continuing to the next line of dialogue if the submit button has been pressed!
        if (currentStory.currentChoices.Count == 0 && (Input.GetMouseButtonDown(0)))
        {
            ContinueStory();
        }

    }

    public static DialogueManager GetInstance()
    {
        return instance;
    }

    public void OpenDialogue(TextAsset inkJSON)
    {
        Debug.Log("Opening the dialogue box and starting the current Dialogue Story!");
        currentStory = new Story(inkJSON.text);
        externalFunctions.Bind(currentStory);

        DialogueIsPlaying = true;
        dialoguePanel.SetActive(true);
        dialogueText.gameObject.SetActive(true);
        
        ContinueStory();
    }

    private void ContinueStory()
    {
        if (currentStory.canContinue)
        {
            Debug.Log("Continuing the current Dialogue Story!");
            // Set text for the current dialogue line.
            dialogueText.text = currentStory.Continue();
            // Display choices for this line if any exist.
            DisplayChoices();
        }
        else
        {
            Debug.Log("The current Dialogue Story has no more to it!");
            CloseDialogue();
        }
    }

    public void CloseDialogue()
    {
        Debug.Log("Closing the dialogue box!");
        externalFunctions.Unbind(currentStory);

        DialogueIsPlaying = false;
        dialoguePanel.SetActive(false);
        dialogueText.gameObject.SetActive(false);
        dialogueText.text = "";

        if (!CombatManager.Instance.inCombat)
        {
            Debug.Log("THIS IS BEING ACCESSED!");
            GameManager.Instance.EndEncounter();
        }
    }

    private void DisplayChoices()
    {
        List<Choice> currentChoices = currentStory.currentChoices;

        // Defensive check to ensure UI can support the number of choices coming in.
        if (currentChoices.Count > choices.Length)
        {
            Debug.LogError("More choices Were given than the UI Can Support! Number of choices given: " + currentChoices.Count);
        }

        int index = 0;
        // Enable and initialize the choices for this line of dialogue!
        for (int i = 0; i < currentChoices.Count; i++)
        {
            choices[i].SetActive(true);
            choicesText[i].text = currentChoices[i].text;
            index++;
        }
        // For any choices that are supported but unused, hide them.
        for (int i = index; i < choices.Length; i++)
        {
            choices[i].SetActive(false);
        }
    }

    public void MakeChoice(int choiceIndex)
    {
        currentStory.ChooseChoiceIndex(choiceIndex);
        ContinueStory();
    }

    private void OnDestroy()
    {
        externalFunctions.Unbind(currentStory);
    }
}
