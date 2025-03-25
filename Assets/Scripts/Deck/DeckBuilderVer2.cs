using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DeckBuilderVer2 : MonoBehaviour
{
    public static DeckBuilderVer2 Instance { get; private set; }

    public List<DeckBuilderTab> Tabs { get; private set; }
    public DeckBuilderCharacter SelectedCharacter { get; private set; }

    void Start()
    {
        //Initialize Singleton Instance
        if (Instance == null)
        {
            Instance = this;
        }
        else Debug.Log("There are multiple instances of the DeckBuilderVer2 script in this scene!");

        //Initialize Tab List and Selected Character
        Tabs = new List<DeckBuilderTab>();
        foreach (DeckBuilderTab tab in Object.FindObjectsOfType<DeckBuilderTab>())
        {
            Tabs.Add(tab);
        }

        SetSelectedCharacter(Tabs.Last().Character);
    }

    public void SetSelectedCharacter(DeckBuilderCharacter newCharacter)
    {
        if (newCharacter == SelectedCharacter)
        {
            Debug.Log("The character file given is the same as the current selected character!");
            return;
        }

        SelectedCharacter = newCharacter;
        DeckBuilderReciept.Instance.SetCharacter(SelectedCharacter);
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

    public void NextScene(int sceneID)
    {
        SceneManager.LoadScene(sceneID);
    }
}
