using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckBuilderVer2 : MonoBehaviour
{
    public static DeckBuilderVer2 Instance { get; private set; }

    public List<DeckBuilderTab> Tabs { get; private set; }
    DeckBuilderCharacter SelectedCharacter;

    // Start is called before the first frame update
    void Start()
    {
        //Initialize Tab List and Selected Character
        Tabs = new List<DeckBuilderTab>();
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
        DeckBuilderReciept.Instance.SetCharacter(newCharacter);
    }

    public void CheckForSignature()
    {
        if (SelectedCharacter != null)
        {
            Debug.Log("There is currently no character loaded into the DeckBuilder!");
            return;
        }

        if (SelectedCharacter.IsSelectedCardListValid())
        {
            // Display Character Signature
        }
        else
        {
            // Hide Character Signature
        }
    }
}
