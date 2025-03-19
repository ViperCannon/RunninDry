using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckBuilderVer2 : MonoBehaviour
{
    public static DeckBuilderVer2 Instance { get; private set; }

    DeckSelectionManager selectionManager;

    List<DeckBuilderCharacter> cardLists;
    DeckBuilderCharacter currentCardList;

    // Start is called before the first frame update
    void Start()
    {
        selectionManager = GameObject.Find("DeckSelectionHandler").GetComponent<DeckSelectionManager>();
        SetCharacterCardList(0);
    }

    public void SetCharacterCardList(int index)
    {
        if (!IsCardListIndexValid(index)) return;
        currentCardList = cardLists[index];
    }

    bool IsCardListIndexValid(int index)
    {
        // Check if the card list has been properly populated.
        if (cardLists == null || cardLists.Count == 0)
        {
            Debug.Log("The card list array has not been populated!");
            return false;
        }

        // Check if the given index is within the bounds of the list.
        if (index < 0 || index >= cardLists.Count)
        {
            Debug.Log("Invalid index detected! Index must be between 0 and " + cardLists.Count + ", but was " + index + ".");
            return false;
        }

        // Check if the card list at the given index has been initialized.
        if (cardLists[index] == null)
        {
            Debug.Log("The card list at this index has not been initialized!");
            return false;
        }

        return true;
    }
}
