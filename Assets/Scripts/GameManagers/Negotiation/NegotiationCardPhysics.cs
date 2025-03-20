using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using SpeakeasyStreet;

public class NegotiationCardPhysics : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler
{
    HandManager handManager;
    Vector3 originalPosition;
    Quaternion originalRotation;
    Canvas canvas;

    int siblingIndex;

    float floatHeight = 110f; // How high the card should float on hover

    public Image highlight;

    void Start()
    {
        canvas = GetComponentInParent<Canvas>();
        handManager = transform.parent.parent.GetComponentInChildren<HandManager>();

        if (handManager == null)
        {
            Debug.LogError("HandManager not found!");
        }
    }

    private void ResetCardPosition()
    {
        transform.localPosition = originalPosition;
        transform.localRotation = originalRotation;
        transform.SetSiblingIndex(siblingIndex);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (!DragManager.isDragging)
        {
            siblingIndex = transform.GetSiblingIndex();
            originalPosition = transform.localPosition;
            originalRotation = transform.localRotation;

            transform.SetAsLastSibling();

            float addHeight = floatHeight - transform.localPosition.y;

            transform.localPosition += new Vector3(0, addHeight, 0);
            transform.localRotation = Quaternion.identity;

            highlight.color = new Color(0, 255, 23, 0.8f);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (!DragManager.isDragging)
        {
            highlight.color = new Color(0, 255, 23, 0);
            transform.localPosition = originalPosition;
            transform.localRotation = originalRotation;
            transform.SetSiblingIndex(siblingIndex);
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (eventData.button != PointerEventData.InputButton.Left)
            return;

        if (gameObject.GetComponent<NegotiationCardDisplay>() == null)
        {
            Debug.Log("No NegotiationCardDisplay");
        }

        Debug.Log("Prefab Component CardData dice count: " + gameObject.GetComponent<NegotiationCardDisplay>().cardData.numberOfDice);

        foreach (var component in gameObject.GetComponents<Component>())
        {
            Debug.Log("Component: " + component.GetType().Name);
        }

        if (!handManager.PlayCard(gameObject.GetComponent<NegotiationCardDisplay>()))
        {
            Debug.Log("Not enough cash!");
        }
    }
}
