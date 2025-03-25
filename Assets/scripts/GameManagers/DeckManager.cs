using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using SpeakeasyStreet;

public class DeckManager : MonoBehaviour
{
    [SerializeField]
    HandManager handManager;

    [SerializeField]
    TMP_Text deckCounter;
    [SerializeField]
    TMP_Text discardCounter;

    Deck negotiationMaster = new Deck();
    Deck combatMaster = new Deck();

    public Deck negotiationDeck = new Deck();
    public Deck combatDeck = new Deck();
    public Deck discardPile = new Deck();

    public bool inCombat = false;
    public bool inNegotiation = false;

    public void PopulateDecks()
    {
        // Load Cards for negotiation deck
        Card[] negotiationCards = Resources.LoadAll<NegotiationCard>("CardData/Tutorial/NegotiationFull");

        negotiationMaster.Set(negotiationCards);

        // Load Cards for combat deck
        Card[] combatCards = Resources.LoadAll<CombatCard>("CardData/Tutorial/CombatFull");

        combatMaster.Set(combatCards);

        Refresh();
    }

    public Card DrawCard()
    {
        if (inCombat)
        {
            if (combatDeck.IsEmpty() && discardPile.IsEmpty())
            {
                Debug.Log("No more cards to draw from.");
                return null;
            }
            else if (combatDeck.IsEmpty())
            {
                combatDeck.Copy(discardPile);
                discardPile.Clear();
                combatDeck.Shuffle();

                return combatDeck.Remove(0);
            }
            else
            {
                return combatDeck.Remove(0);
            }
        }
        else if (inNegotiation)
        {
            if (negotiationDeck.IsEmpty() && discardPile.IsEmpty())
            {
                Debug.Log("No more cards to draw from.");
                return null;
            }
            else if (negotiationDeck.IsEmpty())
            {
                negotiationDeck.Copy(discardPile);
                discardPile.Clear();
                negotiationDeck.Shuffle();

                return negotiationDeck.Remove(0);
            }
            else
            {
                return negotiationDeck.Remove(0);
            }
        }
        else
        {
            Debug.Log("Not In Valid Encounter!");
            return null;
        }    
    }

    public void DiscardCard(Card card)
    {
        discardPile.Add(card);
        UpdateCounters();
    }

    public void UpdateCounters()
    {
        if (inCombat)
        {
            deckCounter.text = combatDeck.Size().ToString();
        }
        else if (inNegotiation)
        {
            deckCounter.text = negotiationDeck.Size().ToString();
        }
        
        discardCounter.text = discardPile.Size().ToString();
    }

    public void Refresh()
    {
        negotiationDeck.Copy(negotiationMaster);
        negotiationDeck.Shuffle();

        combatDeck.Copy(combatMaster);
        combatDeck.Shuffle();

        discardPile.Clear();
    }
}
