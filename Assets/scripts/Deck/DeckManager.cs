using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpeakeasyStreet;


public class DeckManager : MonoBehaviour
{
    Deck negotiationMaster = new Deck();
    Deck combatMaster = new Deck();

    public Deck negotiationDeck = new Deck();
    public Deck combatDeck = new Deck();
    public Deck discardPile = new Deck();

    public void PopulateDecks()
    {
        // Load cards for negotiation deck
        Card[] negotiationCards = Resources.LoadAll<Card>("CardData/Negotiation");

        negotiationMaster.Set(negotiationCards);

        // Load cards for combat deck
        Card[] combatCards = Resources.LoadAll<Card>("CardData/Combat");

        combatMaster.Set(combatCards);

        Refresh();
    }

    public Card DrawCard()
    {
        if(negotiationDeck.IsEmpty() && discardPile.IsEmpty())
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

    public void Refresh()
    {
        negotiationDeck.Copy(negotiationMaster);
        negotiationDeck.Shuffle();

        combatDeck.Copy(combatMaster);
        combatDeck.Shuffle();

        discardPile.Clear();
    }
}
