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
    NegotiationCard[] negotiationCards;
    CombatCard[] combatCards;

    public static Dictionary<NegotiationCard, int> negotiationSelection = new();
    public static Dictionary<CombatCard, int> combatSelection = new();
    public Deck negotiationDeck = new Deck();
    public Deck combatDeck = new Deck();
    public Deck discardPile = new Deck();

    public bool inCombat = false;
    public bool inNegotiation = false;

    public AudioSource audioSource;
    public AudioClip[] cardDrawSounds;
    public AudioClip[] cardDiscardSounds;
    public AudioClip[] cardShuffleSounds;

    public void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PopulateDecks()
    {
        if (MapGenerator.tutorial)
        {
            // Load Cards for negotiation deck
            negotiationCards = Resources.LoadAll<NegotiationCard>("CardData/Tutorial/NegotiationFull");

            negotiationMaster.Set(negotiationCards);

            // Load Cards for combat deck
            combatCards = Resources.LoadAll<CombatCard>("CardData/Tutorial/CombatFull");

            combatMaster.Set(combatCards);          
        }
        else
        {
            int nSize = 0;
            int cSize = 0;
            int index = 0;

            foreach (KeyValuePair<NegotiationCard, int> n in negotiationSelection)
            {
                nSize += n.Value;
            }

            foreach (KeyValuePair<CombatCard, int> c in combatSelection)
            {
                cSize += c.Value;
            }

            negotiationCards = new NegotiationCard[nSize];
            combatCards = new CombatCard[cSize];

            foreach (KeyValuePair<NegotiationCard, int> n in negotiationSelection)
            {
                for(int i= 0; i < n.Value; i++)
                {
                    negotiationCards[index] = n.Key;
                    index++;
                }
            }

            
            negotiationMaster.Set(negotiationCards);
            index = 0;

            foreach (KeyValuePair<CombatCard, int> c in combatSelection)
            {
                for (int i = 0; i < c.Value; i++)
                {
                    combatCards[index] = c.Key;
                    index++;
                }
            }

            combatMaster.Set(combatCards);
        }

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

                audioSource.PlayOneShot(cardDrawSounds[Random.Range(0, cardDrawSounds.Length)]);
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

                audioSource.PlayOneShot(cardDrawSounds[Random.Range(0, cardDrawSounds.Length)]);
                return negotiationDeck.Remove(0);
            }
            else
            {
                audioSource.PlayOneShot(cardDrawSounds[Random.Range(0, cardDrawSounds.Length)]);
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
        audioSource.PlayOneShot(cardDiscardSounds[Random.Range(0, cardDiscardSounds.Length)]);
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

    public void PlayShuffleCardSound()
    {
        audioSource.PlayOneShot(cardShuffleSounds[Random.Range(0, cardShuffleSounds.Length)]);
    }

    public void Refresh()
    {
        negotiationDeck.Copy(negotiationMaster);
        negotiationDeck.Shuffle();

        combatDeck.Copy(combatMaster);
        combatDeck.Shuffle();

        discardPile.Clear();
    }

    public void Reset()
    {
        negotiationMaster.Clear();
        combatMaster.Clear();

        Refresh();
    }
}
