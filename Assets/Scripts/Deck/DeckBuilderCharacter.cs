using SpeakeasyStreet;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(menuName = "DeckBuilderCharacter")]
public class DeckBuilderCharacter : ScriptableObject
{
    public class SelectedCard
    {
        public Card cardData;
        public string cardName;
        public int quantity;

        public SelectedCard(Card data, int quantity)
        {
            this.cardData = data;
            this.cardName = data.cardName;
            this.quantity = quantity;
        }
    }

    [Tooltip("The name of the character represented by this object.")]
    public string CharacterName { get; private set; }

    [Tooltip("The list of negotiation cards tied to this character.")]
    [SerializeField] List<NegotiationCard> negotiationCards;
    [Tooltip("The list of combat cards tied to this character.")]
    [SerializeField] List<CombatCard> combatCards;

    //The list of all cards selected by this character; stores their name, the card's data, and quantity selected.
    public List<SelectedCard> SelectedCardsEntries { get; private set; }

    // Adds a card to the list of Selected Cards.
    public void SelectCard (Card c)
    {
        if (SumTotalCards() >= 10)
        {
            Debug.Log(CharacterName + " already has 10 cards selected and cannot select any more!");
            return;
        }

        foreach (SelectedCard card in SelectedCardsEntries)
        {
            if (card.cardName == c.cardName)
            {
                card.quantity += 1;
                return;
            }
        }

        SelectedCardsEntries.Add(new SelectedCard(c, 1));
    }

    // Removes a card from the list of Selected Cards.
    public void DeselectCard(Card c)
    {
        if (SumTotalCards() <= 0)
        {
            Debug.Log(CharacterName + " has no cards selected to deselect!");
            return;
        }

        foreach (SelectedCard card in SelectedCardsEntries)
        {
            if (card.cardName == c.cardName)
            {
                card.quantity -= 1;

                if (card.quantity < 1)
                {
                    SelectedCardsEntries.Remove(card);
                }
                
                return;
            }
        }
    }

     int SumTotalCards()
    {
        int sum = 0;

        foreach (SelectedCard card in SelectedCardsEntries)
        {
            sum += card.quantity;
        }

        return sum;
    }

    int SumNegotiationCards()
    {
        int sum = 0;

        foreach (SelectedCard card in SelectedCardsEntries)
        {
            /* if (???)
            {
                sum += card.quantity;
            } */
        }

        return sum;
    }

    int SumCombatCards()
    {
        int sum = 0;

        foreach (SelectedCard card in SelectedCardsEntries)
        {
            /* if (???)
            {
                sum += card.quantity;
            } */
        }

        return sum;
    }
}
