using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DeckBuilderVer2 : MonoBehaviour
{
    public static DeckBuilderVer2 Instance { get; private set; }

    public List<DeckBuilderTab> Tabs { get; private set; }
    public DeckBuilderCharacter SelectedCharacter { get; private set; }

    public List<TextMeshProUGUI> ReceiptCardList;
    public List<TextMeshProUGUI> ReceiptCardQuantities;

    Image signature;

    void Awake()
    {
        //Initialize Singleton Instance
        if (Instance == null)
        {
            Instance = this;
        }
        else Debug.Log("There are multiple instances of the DeckBuilderVer2 script in this scene!");

        //Initialize Tab List and Selected Character
        Tabs = new List<DeckBuilderTab>();
        foreach (DeckBuilderTab tab in Object.FindObjectsOfType<DeckBuilderTab>()) Tabs.Add(tab);

        // Initialize Text Fields
        GameObject cardListParent = GameObject.Find("CardList");
        foreach (Transform childTransform in cardListParent.transform)
        {
            ReceiptCardList.Add(childTransform.GetComponent<TextMeshProUGUI>());
        }

        GameObject cardQuantitiesParent = GameObject.Find("CardQuantities");
        foreach (Transform childTransform in cardQuantitiesParent.transform)
        {
            ReceiptCardQuantities.Add(childTransform.GetComponent<TextMeshProUGUI>());
        }

        // Set all text fields to default to start
        foreach (TextMeshProUGUI tmp in ReceiptCardList) tmp.text = "";
        foreach (TextMeshProUGUI tmp in ReceiptCardQuantities) tmp.text = "";

        signature = GameObject.Find("Signature").GetComponent<Image>();
    }

    void Start()
    {
        Tabs.Last().SelectTab();
    }

    public void SetSelectedCharacter(DeckBuilderCharacter newCharacter)
    {
        if (newCharacter == SelectedCharacter)
        {
            Debug.Log("The character file given is the same as the current selected character!");
            return;
        }

        SelectedCharacter = newCharacter;
        UpdateReceiptEntries();

        // Set Character Signature in Receipt
        signature.sprite = SelectedCharacter.CharacterSignature;
    }

    public void UpdateReceiptEntries()
    {
        // Check if Selected Character has card entries
        if (SelectedCharacter.SelectedCardsEntries == null)
        {
            Debug.Log("This Character's selected card list is NULL! Initialize it!");
            return;
        }

        // Set Card Names
        for (int i = 0; i < ReceiptCardList.Count; i++)
        {
            if (SelectedCharacter.SelectedCardsEntries[i] == null)
            {
                ReceiptCardList[i].text = "";
            }
            else ReceiptCardList[i].text = SelectedCharacter.SelectedCardsEntries[i].cardName;
        }

        // Set Card Quantities
        for (int i = 0; i < ReceiptCardQuantities.Count; i++)
        {
            if (SelectedCharacter.SelectedCardsEntries[i] == null)
            {
                ReceiptCardList[i].text = "";
            }
            else ReceiptCardQuantities[i].text = SelectedCharacter.SelectedCardsEntries[i].quantity.ToString();
        }
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
            signature.gameObject.SetActive(true);
        }
        else
        {
            signature.gameObject.SetActive(true);
        }
    }

    public void NextScene(int sceneID)
    {
        SceneManager.LoadScene(sceneID);
    }
}
