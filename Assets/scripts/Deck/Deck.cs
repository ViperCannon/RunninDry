using System.Collections.Generic;
using UnityEngine;
using SpeakeasyStreet;

public class Deck
{
    List<Card> cards;

    public Deck()
    {
        cards = new List<Card>();
    }

    public Deck(List<Card> initCards)
    {
        cards = new List<Card>();

        for (int i = 0; i < initCards.Count; i++)
        {
            cards.Add(initCards[i]);
        }
    }

    public List<Card> Get()
    {
        return cards;
    }

    public void Set(List<Card> newCards)
    {
        Clear();

        for (int i = 0; i < newCards.Count; i++)
        {
            cards.Add(newCards[i]);
        }
    }

    public void Set(Card[] newCards)
    {
        Clear();

        for (int i = 0; i < newCards.Length; i++)
        {
            cards.Add(newCards[i]);
        }
    }

    public void Add(Card card)
    {
        cards.Add(card);
    }

    public void Insert(int index, Card card)
    {
        if(index >= cards.Count)
        {
            cards.Add(card);
        }
        else
        {
            cards.Insert(index, card);
        }
    }

    public bool Remove(Card card)
    {
        return cards.Remove(card);
    }

    public Card Remove(int index)
    {
        Card temp = cards[index];
        cards.RemoveAt(index);

        return temp;
    }

    public int Size()
    {
        return cards.Count;
    }

    public bool IsEmpty()
    {
        return Size() == 0;
    }

    public void Shuffle()
    {
        for(int i = 0; i < cards.Count - 1; i++)
        {
            int rng = Random.Range(i, cards.Count);
            Card temp = cards[i];
            cards[i] = cards[rng];
            cards[rng] = temp;
        }
    }

    public void Copy(Deck other)
    {
        this.Set(other.Get());
    }

    public void Clear()
    {
        cards.Clear();
    }
}
