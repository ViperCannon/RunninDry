using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DeckBuilderVer2 : MonoBehaviour
{
    public static DeckBuilderVer2 Instance { get; private set; }
    public DeckBuilderCharacter SelectedCharacter { get; private set; }

    // Character Tabs
    public DeckBuilderTab[] Tabs { get; private set; }

    // Card Display Objects
    GameObject CardDisplayParent;

    [SerializeField] GameObject NegotiationCardPrefabVariant;
    [SerializeField] GameObject CombatCardPrefabVariant;

    // Receipt Objects
    public List<TextMeshProUGUI> ReceiptCardList;
    public List<TextMeshProUGUI> ReceiptCardQuantities;
    Image signature;
    GameObject ContinueButton;

    public AudioSource audioSource;
    public AudioClip[] addCardSounds;
    public AudioClip[] removeCardSounds;
    public AudioClip[] sortCardSounds;

    void Awake()
    {
        //Initialize Singleton Instance
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.LogWarning("There are multiple instances of the DeckBuilderVer2 script in this scene! Removing the second.");
            Destroy(this);
        }

        //Initialize Character Tabs List
        Tabs = GameObject.FindObjectsOfType<DeckBuilderTab>();

        // Initialize Card Display Parent
        CardDisplayParent = GameObject.Find("CardDisplayPanel");

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

        signature = GameObject.Find("Signature").GetComponent<Image>();
        ContinueButton = GameObject.Find("ContinueButton");

        audioSource = GetComponent<AudioSource>();
    }

    void Start()
    {
        // Select the leftmost character tab.
        GameObject.Find("tab0Button").GetComponent<DeckBuilderTab>().SelectTab();
    }

    public void SetSelectedCharacter(DeckBuilderCharacter newCharacter)
    {
        if (newCharacter == SelectedCharacter)
        {
            Debug.Log("The character file given is the same as the current selected character!");
            return;
        }

        SelectedCharacter = newCharacter;
        UpdateReceiptFields();

        // Set Character Signature in Receipt
        signature.sprite = SelectedCharacter.CharacterSignature;

        switch (DeckBuilderFilters.Instance.CurrentFilter) {
            case 0:
                DisplayAllCards();
                break;

            case 1:
                DisplayNegotiationCards();
                break;

            case 2:
                DisplayCombatCards();
                break;
        }
    }

    #region Card Display Functions
    public void ClearCardDisplay()
    {
        foreach (Transform childTransform in CardDisplayParent.transform)
        {
            Destroy(childTransform.gameObject);
        }
        Debug.Log("Card Display Cleared!");
    }

    public void DisplayAllCards()
    {
        ClearCardDisplay();

        Debug.Log("Populating the Card Display with ALL of " + SelectedCharacter.CharacterName + "'s cards!");
        // Populate the display cards using SelectedCharacter.negotiationCards and SelectedCharacter.combatCards.
        foreach (NegotiationCard card in SelectedCharacter.negotiationCards)
        {
            GameObject temp = Instantiate(NegotiationCardPrefabVariant, CardDisplayParent.transform);
            temp.GetComponent<NegotiationCardDisplay>().cardData = card;
            temp.GetComponent<NegotiationCardDisplay>().UpdateCardDisplay();
        }

        foreach (CombatCard card in SelectedCharacter.combatCards)
        {
            GameObject temp = Instantiate(CombatCardPrefabVariant, CardDisplayParent.transform);
            temp.GetComponent<CombatCardDisplay>().cardData = card;
            temp.GetComponent<CombatCardDisplay>().UpdateCardDisplay();
        }
    }

    public void DisplayNegotiationCards()
    {
        ClearCardDisplay();

        audioSource.PlayOneShot(sortCardSounds[Random.Range(0, sortCardSounds.Length - 1)]);

        Debug.Log("Populating the Card Display with " + SelectedCharacter.CharacterName + "'s Negotioation Cards!");
        // Populate the display cards using SelectedCharacter.negotiationCards.
        foreach (NegotiationCard card in SelectedCharacter.negotiationCards)
        {
            GameObject temp = Instantiate(NegotiationCardPrefabVariant, CardDisplayParent.transform);
            temp.GetComponent<NegotiationCardDisplay>().cardData = card;
            temp.GetComponent<NegotiationCardDisplay>().UpdateCardDisplay();
        }
    }

    public void DisplayCombatCards()
    {
        ClearCardDisplay();

        audioSource.PlayOneShot(sortCardSounds[Random.Range(0, sortCardSounds.Length)]);

        Debug.Log("Populating the Card Display with " + SelectedCharacter.CharacterName + "'s Combat Cards!");
        // Populate the display cards using SelectedCharacter.combatCards.
        foreach (CombatCard card in SelectedCharacter.combatCards)
        {
            GameObject temp = Instantiate(CombatCardPrefabVariant, CardDisplayParent.transform);
            temp.GetComponent<CombatCardDisplay>().cardData = card;
            temp.GetComponent<CombatCardDisplay>().UpdateCardDisplay();
        }
    }
    #endregion

    #region Receipt Field Functions
    public void UpdateReceiptFields()
    {
        // Clear Fields to prevent potential visual bugs.
        ClearReceiptFields();

        // Check if Selected Character has a Selected Card List.
        if (SelectedCharacter.SelectedCardsEntries == null)
        {
            Debug.LogWarning(SelectedCharacter.CharacterName + "'s selected card list is NULL! Initialize it!");
            return;
        }

        //Check if the Selected Character's Selected Card List has any entries.
        if (SelectedCharacter.SelectedCardsEntries.Count <= 0)
        {
            return;
        }

        // Set Card Names/Quantities
        int CombatIndex = 0;
        int NegotiationIndex = ReceiptCardList.Count - 1;

        foreach (DeckBuilderCharacter.SelectedCard card in SelectedCharacter.SelectedCardsEntries)
        {
            if (card.cardData.GetType() == typeof(CombatCard))
            {
                ReceiptCardList[CombatIndex].text = card.cardName;
                ReceiptCardQuantities[CombatIndex].text = card.quantity.ToString();

                CombatIndex++;
            }

            if (card.cardData.GetType() == typeof(NegotiationCard))
            {
                ReceiptCardList[NegotiationIndex].text = card.cardName;
                ReceiptCardQuantities[NegotiationIndex].text = card.quantity.ToString();

                NegotiationIndex--;
            }
        }

        ToggleSignature();
        ToggleContinueButton();
    }

    void ClearReceiptFields()
    {
        foreach (TextMeshProUGUI tmp in ReceiptCardList)
        {
            tmp.text = "";
        }
        foreach (TextMeshProUGUI tmp in ReceiptCardQuantities)
        {
            tmp.text = "";
        }

        ToggleSignature();
        ToggleContinueButton();
    }
    #endregion

    #region Toggle Element Visibilty Functions
    public void ToggleSignature()
    {
        if (SelectedCharacter == null)
        {
            Debug.Log("There is currently no character loaded into the DeckBuilder! Hiding the signature graphic.");
            signature.gameObject.SetActive(false);
            return;
        }

        if (SelectedCharacter.IsSelectedCardListValid())
        {
            signature.gameObject.SetActive(true);
        }
        else
        {
            signature.gameObject.SetActive(false);
        }
    }

    public void ToggleContinueButton()
    {
        foreach(DeckBuilderTab tab in Tabs)
        {
            if (!tab.Character.IsSelectedCardListValid()) {
                if (!ContinueButton.activeSelf)
                {
                    return;
                }
                Debug.Log("At least one character's selected card list does not fit the continue criteria! Hiding the Continue button.");
                ContinueButton.SetActive(false);
                return;
            }
        }
        ContinueButton.SetActive(true);
    }
    #endregion

    public void PlayAddCardSound() 
    {
        audioSource.PlayOneShot(addCardSounds[Random.Range(0, addCardSounds.Length)]);
    }

    public void PlayRemoveCardSound()
    {
        audioSource.PlayOneShot(removeCardSounds[Random.Range(0, removeCardSounds.Length)]);
    }

    public void NextScene(int sceneID)
    {
        SceneManager.LoadScene(sceneID);
    }
}
