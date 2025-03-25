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
    public string CharacterName;

    public Sprite CharacterSignature;

    [Tooltip("The list of negotiation cards tied to this character.")]
    [SerializeField] List<NegotiationCard> negotiationCards;
    [Tooltip("The list of combat cards tied to this character.")]
    [SerializeField] List<CombatCard> combatCards;

    //The list of all Cards selected by this character; stores their name, the card's data, and quantity selected.
    public List<SelectedCard> SelectedCardsEntries { get; private set; }

    // Adds a card to the list of Selected Cards.
    public void SelectCard (NegotiationCard c)
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

    // Adds a card to the list of Selected Cards.
    public void SelectCard(CombatCard c)
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
                DeckBuilderReciept.Instance.UpdateReciept();
                return;
            }
        }

        SelectedCardsEntries.Add(new SelectedCard(c, 1));
        DeckBuilderReciept.Instance.UpdateReciept();
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
                    DeckBuilderReciept.Instance.UpdateReciept();
                    return;
                }
                
                return;
            }
        }
    }

     private int SumTotalCards()
    {
        int sum = 0;

        foreach (SelectedCard card in SelectedCardsEntries)
        {
            sum += card.quantity;
        }

        return sum;
    }

    private int SumNegotiationCards()
    {
        int sum = 0;

        foreach (SelectedCard card in SelectedCardsEntries)
        {
            if (card.cardData.GetType() == typeof(NegotiationCard))
            {
                sum += card.quantity;
            }
        }

        return sum;
    }

    private int SumCombatCards()
    {
        int sum = 0;

        foreach (SelectedCard card in SelectedCardsEntries)
        {
            if (card.cardData.GetType() == typeof(CombatCard))
            {
                sum += card.quantity;
            }
        }

        return sum;
    }

    public bool IsSelectedCardListValid()
    {
        if (SumTotalCards() != 10)
        {
            Debug.Log("There should be exactly 10 total cards in the deck! There are currently " + SumTotalCards());
            return false;
        }

        if (SumNegotiationCards() < 2)
        {
            Debug.Log("There should be at least two Negotiation cards in the deck! There are currently " + SumNegotiationCards());
            return false;
        }

        if (SumCombatCards() < 2)
        {
            Debug.Log("There should be at least two Combat cards in the deck! There are currently " + SumCombatCards());
            return false;
        }

        return true;
    }
}
