using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine;

public class CardPhysics : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerEnterHandler, IPointerExitHandler
{
    Vector3 originalPosition;
    Vector3 dragOffset;
    Quaternion originalRotation;
    Canvas canvas;
    
    int siblingIndex;
    
    float floatHeight = 85f; // How high the card should float on hover
    float yThreshold = 200f; // Maximum Y-level the card can go before arc starts

    public Image image;

    void Start()
    {
        canvas = GetComponentInParent<Canvas>();
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
        // Reset position
        transform.localPosition = originalPosition;
        transform.localRotation = originalRotation;
        transform.SetSiblingIndex(siblingIndex);
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

            transform.localPosition += new Vector3(0, floatHeight, 0);
            transform.localRotation = Quaternion.identity;

            image.color = new Color(0, 255, 23, 0.8f);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (!DragManager.isDragging)
        {
            image.color = new Color(0, 255, 23, 0);
            transform.localPosition = originalPosition;
            transform.localRotation = originalRotation;
            transform.SetSiblingIndex(siblingIndex);
        }
    }
}
