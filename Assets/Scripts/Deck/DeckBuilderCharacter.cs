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
    public List<NegotiationCard> negotiationCards;
    [Tooltip("The list of combat cards tied to this character.")]
    public List<CombatCard> combatCards;

    //The list of all Cards selected by this character; stores their name, the card's data, and quantity selected.
    public List<SelectedCard> SelectedCardsEntries { get; private set; } = new List<SelectedCard>();

    // Adds a card to the list of Selected Cards. Works if c is of type Card, NegotiationCard, or CombatCard.
    public void SelectCard(Card c)
    {
        if (SumTotalCards() >= 10)
        {
            Debug.Log(CharacterName + " already has 10 cards selected and cannot select any more!");
            return;
        }

        DeckBuilderVer2.Instance.PlayAddCardSound();

        foreach (SelectedCard card in SelectedCardsEntries)
        {
            if (card.cardName == c.cardName)
            {
                card.quantity += 1;
                DeckBuilderVer2.Instance.UpdateReceiptFields();

                if (c.GetType() == typeof(CombatCard))
                {
                    DeckManager.combatSelection[(CombatCard)c] += 1;
                }
                else
                {
                    DeckManager.negotiationSelection[(NegotiationCard)c] += 1;
                }

                Debug.Log(c.cardName + " updated in the selected list!");
                return;
            }
        }

        SelectedCardsEntries.Add(new SelectedCard(c, 1));
        DeckBuilderVer2.Instance.UpdateReceiptFields();
        
        if(c.GetType() == typeof(CombatCard))
        {
            DeckManager.combatSelection.Add((CombatCard)c, 1);
        }
        else
        {
            DeckManager.negotiationSelection.Add((NegotiationCard)c, 1);
        }

        Debug.Log(c.cardName + " added to the selected list!");
    }

    // Removes a card from the list of Selected Cards.
    public void DeselectCard(string cName)
    {
        if (SumTotalCards() <= 0)
        {
            Debug.Log(CharacterName + " has no cards selected to deselect!");
            return;
        }

        DeckBuilderVer2.Instance.PlayRemoveCardSound();

        foreach (SelectedCard c in SelectedCardsEntries)
        {
            if (c.cardName == cName)
            {
                if (c.cardData.GetType() == typeof(CombatCard))
                {
                    DeckManager.combatSelection[(CombatCard)c.cardData] -= 1;

                    if (DeckManager.combatSelection[(CombatCard)c.cardData] < 1)
                    {
                        DeckManager.combatSelection.Remove((CombatCard)c.cardData);
                    }
                }
                else
                {
                    DeckManager.negotiationSelection[(NegotiationCard)c.cardData] -= 1;

                    if (DeckManager.negotiationSelection[(NegotiationCard)c.cardData] < 1)
                    {
                        DeckManager.negotiationSelection.Remove((NegotiationCard)c.cardData);
                    }
                }

                c.quantity -= 1;

                if (c.quantity < 1)
                {
                    SelectedCardsEntries.Remove(c);
                    DeckBuilderVer2.Instance.UpdateReceiptFields();
                    Debug.Log(c.cardName + " removed from the selected list!");
                    return;
                }

                DeckBuilderVer2.Instance.UpdateReceiptFields();
                Debug.Log(c.cardName + " updated in the selected list!");
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
            return false;
        }

        if (SumNegotiationCards() < 2)
        {
            return false;
        }

        if (SumCombatCards() < 2)
        {
            return false;
        }

        return true;
    }
}
