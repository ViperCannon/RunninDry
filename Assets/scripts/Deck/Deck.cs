using System.Collections.Generic;
using UnityEngine;
using SpeakeasyStreet;

public class Deck
{
    public List<Card> Cards { get; private set; }

    public Deck()
    {
        Cards = new List<Card>();
    }

    public Deck(List<Card> initCards)
    {
        Cards = new List<Card>();

        for (int i = 0; i < initCards.Count; i++)
        {
            Cards.Add(initCards[i]);
        }
    }

    public List<Card> Get()
    {
        return Cards;
    }

    public void Set(List<Card> newCards)
    {
        Clear();

        for (int i = 0; i < newCards.Count; i++)
        {
            Cards.Add(newCards[i]);
        }
    }

    public void Set(Card[] newCards)
    {
        Clear();

        for (int i = 0; i < newCards.Length; i++)
        {
            Cards.Add(newCards[i]);
        }
    }

    public void Add(Card card)
    {
        Cards.Add(card);
    }

    public void Insert(int index, Card card)
    {
        if(index >= Cards.Count)
        {
            Cards.Add(card);
        }
        else
        {
            Cards.Insert(index, card);
        }
    }

    public bool Remove(Card card)
    {
        return Cards.Remove(card);
    }

    public Card Remove(int index)
    {
        Card temp = Cards[index];
        Cards.RemoveAt(index);

        return temp;
    }

    public int Size()
    {
        return Cards.Count;
    }

    public bool IsEmpty()
    {
        return Size() == 0;
    }

    public void Shuffle()
    {
        for(int i = 0; i < Cards.Count - 1; i++)
        {
            int rng = Random.Range(i, Cards.Count);
            (Cards[i], Cards[rng]) = (Cards[rng], Cards[i]);
        }
    }

    public void Copy(Deck other)
    {
        this.Set(other.Get());
    }

    public void Clear()
    {
        Cards.Clear();
    }
}
