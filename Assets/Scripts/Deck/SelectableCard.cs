using SpeakeasyStreet;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SelectableCard : MonoBehaviour, IPointerDownHandler
{
    Card cardData;

    void Start()
    {
        if (GetComponent<NegotiationCardDisplay>() != null)
        {
            cardData = GetComponent<NegotiationCardDisplay>().cardData;
            return;
        }

        if (GetComponent<CombatCardDisplay>() != null)
        {
            cardData = GetComponent<CombatCardDisplay>().cardData;
            return;
        }

        Debug.LogWarning("This Card has no Card Display component assigned, and therefore no data!");
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (cardData == null)
        {
            Debug.LogWarning("This Card has no data!");
            return;
        }

        DeckBuilderVer2.Instance.SelectedCharacter.SelectCard(cardData);
    }
}
