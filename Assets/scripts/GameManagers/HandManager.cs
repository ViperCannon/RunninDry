using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpeakeasyStreet;

public class HandManager : MonoBehaviour
{
    [SerializeField]
    CombatManager combatManager;
    [SerializeField]
    CardEffectResolver cardResolver;
    [SerializeField]
    GameObject cardPrefab;
    [SerializeField]
    DeckManager deckManager;

    [SerializeField]
    Transform handTransform;
    [SerializeField]
    Transform deckTransform;
    [SerializeField]
    Transform discardTransform;

    [SerializeField]
    float fanSpread = -2.5f;
    [SerializeField]
    float cardSpacing = 166f;
    [SerializeField]
    float verticalSpacing;

    public List<GameObject> cardsInHand = new();

    const int MAX_HAND_SIZE = 6;
    public int initialDraw = 6;

    void Start()
    {
        deckManager.PopulateDecks();
        deckManager.UpdateCounters();

        if(combatManager == null)
        {
            AttemptDraw(initialDraw);
        }   
    }

    public void AttemptDraw(int draw)
    {
        for(int i = 0; i < draw; i++)
        {
            if (cardsInHand.Count >= MAX_HAND_SIZE)
            {
                Debug.Log("Hand is full!");
                break;
            }

            CallAddCardToHand(deckManager.DrawCard());
        }
    }

    public void Discard(GameObject cardDisplay)
    {
        cardsInHand.Remove(cardDisplay);
        UpdateHandVisuals();
        deckManager.DiscardCard(cardDisplay.GetComponent<CardDisplay>().cardData);
        
        //animation of card going to discard
    }

    public void DiscardHand()
    {
        while(cardsInHand.Count > 0)
        {
            Discard(cardsInHand[0]);
        }
    }

    public void CallAddCardToHand(Card card)
    {
        if (card is CombatCard cc)
        {
            AddCardToHand(cc);
        }
        else if (card is NegotiationCard nc)
        {
            AddCardToHand(nc);
        }
        else
        {
            Debug.Log("Invalid Card!");
        }
    }

    public void AddCardToHand(CombatCard card)
    {
        if(card != null)
        {
            GameObject newCard = Instantiate(cardPrefab, handTransform.position, Quaternion.identity, handTransform);
            cardsInHand.Add(newCard);

            newCard.GetComponent<CombatCardDisplay>().cardData = card;
            newCard.GetComponent<CombatCardDisplay>().UpdateCardDisplay();

            verticalSpacing = (6f * cardsInHand.Count * cardsInHand.Count - 28f * cardsInHand.Count + 65f) / 5;

            UpdateHandVisuals();
            deckManager.UpdateCounters();
        }
    }

    public void AddCardToHand(NegotiationCard card)
    {
        if (card != null)
        {
            GameObject newCard = Instantiate(cardPrefab, handTransform.position, Quaternion.identity, handTransform);
            cardsInHand.Add(newCard);

            newCard.GetComponent<NegotiationCardDisplay>().cardData = card;
            newCard.GetComponent<NegotiationCardDisplay>().UpdateCardDisplay();

            verticalSpacing = (6f * cardsInHand.Count * cardsInHand.Count - 28f * cardsInHand.Count + 65f) / 5;

            UpdateHandVisuals();
            deckManager.UpdateCounters();
        }
    }

    public bool PlayCard(GameObject cardDisplay, CombatCard cardData, CharacterInstance target)
    {
        //resolve card effect (need to add logic if player is downed.)
        if (cardData.cost <= combatManager.currentCaps && ((target != null && !target.isDowned) || cardData.IsAOE() || cardData.validTargets[0] == CombatCard.CardTarget.Generic))
        {
            Discard(cardDisplay);

            if (cardData.subTypes.Contains(CombatCard.CombatSubType.Unload))
            {
                cardResolver.ResolveCardEffects(cardData, target, combatManager.currentCaps);
                combatManager.currentCaps = 0;
            }
            else
            {
                cardResolver.ResolveCardEffects(cardData, target, 1);
                combatManager.currentCaps -= cardData.cost;
            }

            combatManager.lastPlayedCard = cardData;

            Destroy(cardDisplay);

            return true;
        }
        else
        {
            Debug.Log("Can't Play Card!");

            return false;
        }   
    }

    public bool PlayCard(GameObject cardDisplay, NegotiationCard cardData)
    {
        //check bribery cost, otherwise card always plays
        return true;
    }

    private void UpdateHandVisuals()
    {
        int cardCount = cardsInHand.Count;

        for (int i = 0; i < cardCount; i++)
        {
            float cardPosition = i - (cardCount - 1) / 2f;

            float rotationAngle = fanSpread * cardPosition;
            cardsInHand[i].transform.localRotation = Quaternion.Euler(0f, 0f, rotationAngle);

            float horizontalOffset = cardSpacing * cardPosition;

            float normalizedPosition;
            
            if(cardCount != 1)
            {
                normalizedPosition = 2f * i  / (cardCount - 1) - 1f;
            }
            else
            {
                normalizedPosition = 0;
            }
            
            float verticalOffset = verticalSpacing * (1 - normalizedPosition * normalizedPosition);

            cardsInHand[i].transform.localPosition = new Vector3(horizontalOffset, verticalOffset, 0f);
        }
    }

    public void NewEncounter()
    {
        Clear();
        deckManager.Refresh();
    }

    public void Clear()
    {
        cardsInHand.Clear();
    }
}
