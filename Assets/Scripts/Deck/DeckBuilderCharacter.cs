using SpeakeasyStreet;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(menuName = "DeckBuilderCharacter")]
public class DeckBuilderCharacter : ScriptableObject
{
    protected class SelectedCard
    {
        public string name;
        public int quantity;

        public SelectedCard(string name, int quantity)
        {
            this.name = name;
            this.quantity = quantity;
        }
    }

    [Tooltip("The name of the character represented by this object.")]
    [SerializeField] public string characterName { get; private set; }

    [Tooltip("The name of the character represented by this object.")]
    [SerializeField] List<NegotiationCard> negotiationCards;
    [Tooltip("The name of the character represented by this object.")]
    [SerializeField] List<CombatCard> combatCards;

    List<SelectedCard> selectedCards;

    public void SelectCard (string cardName)
    {
        if (SumCards() >= 10)
        {
            Debug.Log(characterName + " already has 10 cards selected and cannot select any more!");
            return;
        }

        foreach (SelectedCard card in selectedCards)
        {
            if (card.name == cardName)
            {
                card.quantity += 1;
                return;
            }
        }

        selectedCards.Add(new SelectedCard(cardName, 1));
    }

    public void DeselectCard(string cardName)
    {
        if (SumCards() <= 0)
        {
            Debug.Log(characterName + " has no cards selected to deselect!");
            return;
        }

        foreach (SelectedCard card in selectedCards)
        {
            if (card.name == cardName)
            {
                card.quantity -= 1;
                if (card.quantity < 1)
                {
                    selectedCards.Remove(card);
                }
                
                return;
            }
        }
    }

     int SumCards()
    {
        int sum = 0;
        return sum;
    } 
}
