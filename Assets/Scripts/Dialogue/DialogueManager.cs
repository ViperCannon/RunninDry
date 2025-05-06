using Ink.Runtime;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
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

    [Header("Choices UI")]
    [SerializeField] private GameObject choiceParent;
    [SerializeField] private Button[] choicebuttons;

    private InkExternalFunctions externalFunctions;
    private InkDialogueVariables dialogueVariables;

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Debug.LogWarning("Found more than one Dialogue Manager instance in the scene! Removing this one!");
            Destroy(this);
        }
        else instance = this;

        if (choiceParent != null)
        {
            choicebuttons = new Button[choices.Length];
            
            for (int i = 0; i < choices.Length; i++)
            {
                choicebuttons[i] = choiceParent.transform.GetChild(i).gameObject.GetComponent<Button>();
            }
        }
        else Debug.LogWarning("Choice Buttons Parent is NULL! Please select it in the editor!");

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
        if (currentStory.currentChoices.Count == 0 && !NegotiationManager.Instance.inNegotiation && (Input.GetMouseButtonDown(0)))
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
        for (int i = 0; i < choices.Length; i++)
        {
            EnableChoice(i);
        }

        currentStory = new Story(inkJSON.text);
        externalFunctions.Bind(currentStory);
        dialogueVariables = new InkDialogueVariables(currentStory);
        dialogueVariables.SyncVariablesAndStartListening(currentStory);

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
        dialogueVariables.StopListening(currentStory);

        DialogueIsPlaying = false;
        dialoguePanel.SetActive(false);
        dialogueText.gameObject.SetActive(false);
        dialogueText.text = "";

        if (!CombatManager.Instance.inCombat)
        {
            GameManager.Instance.EndEncounter();
        }

        if (GameManager.Instance.beforeBoss && MapGenerator.tutorial)
        {
            MapGenerator.tutorial = false;
            GameManager.Instance.LoadHub();
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

    public void EnableChoice(int choice)
    {
        if (choice >= 0 && choice < choices.Length)
        {
            Debug.Log("Enabling choice " + choice + "!");
            choicebuttons[choice].interactable = true;
        }
        else Debug.LogWarning(choice + " is ouitside the range of available choice options!");
    }

    public void DisableChoice(int choice)
    {
        if (choice >= 0 && choice < choicebuttons.Length)
        {
            Debug.Log("Disabling choice " + choice + "!");
            choicebuttons[choice].interactable = false;
        }
        else Debug.LogWarning(choice + " is ouitside the range of available choice options!");
    }

    public void UpdateInkDialogueVariable(string name, Ink.Runtime.Object value)
    {
        dialogueVariables.UpdateVariableState(name, value);
        dialogueVariables.SyncSingleVariableToStory(currentStory, KeyValuePair.Create(name, value));
    }
}
