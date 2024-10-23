using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpeakeasyStreet;

public class HandManager : MonoBehaviour
{
    [SerializeField]
    GameObject cardPrefab;

    [SerializeField]
    DeckManager deckManager;

    [SerializeField]
    Transform handTransform;

    [SerializeField]
    float fanSpread = -2.5f;
    [SerializeField]
    float cardSpacing = 166f;
    [SerializeField]
    float verticalSpacing;

    public List<GameObject> cardsInHand = new List<GameObject>();

    const int MAX_HAND_SIZE = 7;
    public int initialDraw = 6;

    void Start()
    {
        deckManager.PopulateDecks();

        for(int i = 0; i < initialDraw; i++)
        {
            AddCardToHand(deckManager.DrawCard());
        }
    }

    public void AddCardToHand(Card cardData)
    {
        if(cardData != null)
        {
            GameObject newCard = Instantiate(cardPrefab, handTransform.position, Quaternion.identity, handTransform);
            cardsInHand.Add(newCard);

            newCard.GetComponent<CardDisplay>().cardData = cardData;
            newCard.GetComponent<CardDisplay>().UpdateCardDisplay();

            verticalSpacing = (6f * cardsInHand.Count * cardsInHand.Count - 28f * cardsInHand.Count + 65f) / 5;

            UpdateHandVisuals();
        }
    }

    /*private void Update()
    {
        UpdateHandVisuals();
    }*/

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
