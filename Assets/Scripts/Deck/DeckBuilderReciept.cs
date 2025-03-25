using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DeckBuilderReciept : MonoBehaviour
{
    public static DeckBuilderReciept Instance { get; private set; }

    public List<TextMeshProUGUI> CardList;
    public List<TextMeshProUGUI> CardQuantities;

    Image signature;

    void Start()
    {
        // Initialize Text Fields
        GameObject cardListParent = GameObject.Find("CardList");
        foreach (Transform childTransform in cardListParent.transform)
        {
            CardList.Add(childTransform.GetComponent<TextMeshProUGUI>());
        }

        GameObject cardQuantitiesParent = GameObject.Find("CardQuantities");
        foreach (Transform childTransform in cardQuantitiesParent.transform)
        {
            CardQuantities.Add(childTransform.GetComponent<TextMeshProUGUI>());
        }

        // Set all text fields to default to start
        foreach (TextMeshProUGUI tmp in CardList)
        {
            tmp.text = "";
        }

        foreach (TextMeshProUGUI tmp in CardQuantities)
        {
            tmp.text = "";
        }

        signature = GameObject.Find("Signature").GetComponent<Image>();
    }

    public void SetCharacter(DeckBuilderCharacter newCharacter)
    {
        // Set Card Names
        for (int i = 0; i < CardList.Count; i++)
        {
            if (newCharacter.SelectedCardsEntries[i] == null)
            {
                CardList[i].text = "";
            }
            else CardList[i].text = newCharacter.SelectedCardsEntries[i].cardName;
        }

        // Set Card Quantities
        for (int i = 0; i < CardQuantities.Count; i++)
        {
            if (newCharacter.SelectedCardsEntries[i] == null)
            {
                CardList[i].text = "";
            }
            else CardQuantities[i].text = newCharacter.SelectedCardsEntries[i].quantity.ToString();
        }

        signature.sprite = newCharacter.CharacterSignature;
    }

    public void UpdateReciept()
    {
        // Set Card Names
        for (int i = 0; i < CardList.Count; i++)
        {
            if (DeckBuilderVer2.Instance.SelectedCharacter.SelectedCardsEntries[i] == null)
            {
                CardList[i].text = "";
            }
            else CardList[i].text = DeckBuilderVer2.Instance.SelectedCharacter.SelectedCardsEntries[i].cardName;
        }

        // Set Card Quantities
        for (int i = 0; i < CardQuantities.Count; i++)
        {
            if (DeckBuilderVer2.Instance.SelectedCharacter.SelectedCardsEntries[i] == null)
            {
                CardList[i].text = "";
            }
            else CardQuantities[i].text = DeckBuilderVer2.Instance.SelectedCharacter.SelectedCardsEntries[i].quantity.ToString();
        }
    }
}
