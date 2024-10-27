using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine;

public class CardPhysics : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerEnterHandler, IPointerExitHandler
{
    HandManager handManager;
    Vector3 originalPosition;
    Vector3 dragOffset;
    Quaternion originalRotation;
    Canvas canvas;
    
    int siblingIndex;
    
    float floatHeight = 110f; // How high the card should float on hover
    float yThreshold = 210f; // Maximum Y-level the card can go before arc starts

    public Image highlight;

    void Start()
    {
        canvas = GetComponentInParent<Canvas>();
        handManager = transform.parent.parent.GetComponentInChildren<HandManager>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        DragManager.isDragging = true;

        Vector2 pointerPos;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform, eventData.position, canvas.worldCamera, out pointerPos);
        dragOffset = transform.localPosition - new Vector3(pointerPos.x, pointerPos.y, 0);
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (canvas != null)
        {
            Vector2 position;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform, eventData.position, canvas.worldCamera, out position);

            // Center the card around the pointer
            transform.localPosition = new Vector3(position.x + dragOffset.x, Mathf.Clamp(position.y + dragOffset.y, originalPosition.y, originalPosition.y + yThreshold), 0);

        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //card is targeting
        if(transform.localPosition.y >= yThreshold - 0.01)
        {
            handManager.PlayCard(transform.gameObject);
        }
        else
        {
            // Reset position
            transform.localPosition = originalPosition;
            transform.localRotation = originalRotation;
            transform.SetSiblingIndex(siblingIndex);
        }

        DragManager.isDragging = false;
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
}
