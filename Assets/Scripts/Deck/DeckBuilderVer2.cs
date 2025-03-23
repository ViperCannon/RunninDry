using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckBuilderVer2 : MonoBehaviour
{
    public static DeckBuilderVer2 Instance { get; private set; }

    DeckSelectionManager selectionManager;

    List<DeckBuilderTab> Tabs;
    DeckBuilderCharacter SelectedCharacter;

    // Start is called before the first frame update
    void Start()
    {
        //Initialize Selection Manager
        selectionManager = GameObject.Find("DeckSelectionHandler").GetComponent<DeckSelectionManager>();

        //Initialize Tab List and Selected Character
        foreach (DeckBuilderTab tab in Object.FindObjectsOfType<DeckBuilderTab>())
        {
            Tabs.Add(tab);
        }
        SelectedCharacter = Tabs[0].Character;
    }

    public void SetSelectedCharacter(DeckBuilderCharacter newCharacter)
    {
        if (newCharacter == null)
        {
            Debug.Log("The character file given is null!");
            return;
        }

        if (newCharacter == SelectedCharacter)
        {
            Debug.Log("The character file given is the same as the current selected character!");
            return;
        }

        SelectedCharacter = newCharacter;
    }
}
