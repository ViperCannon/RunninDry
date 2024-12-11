using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using SpeakeasyStreet;

public class CombatCardPhysics : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerEnterHandler, IPointerExitHandler
{
    HandManager handManager;
    CombatManager combatManager;
    Vector3 originalPosition;
    Vector3 dragOffset;
    Quaternion originalRotation;
    Canvas canvas;

    int siblingIndex;

    float floatHeight = 110f; // How high the card should float on hover
    float yThreshold = 210f; // Maximum Y-level the card can go before arc starts

    GameObject currentTarget;

    public Image highlight;
    

    void Start()
    {
        canvas = GetComponentInParent<Canvas>();
        handManager = transform.parent.parent.GetComponentInChildren<HandManager>();
        combatManager = GameObject.Find("CombatManager").GetComponent<CombatManager>();
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

            UpdateTargetUnderMouse(eventData);
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        CombatCardDisplay cardDisplay = GetComponent<CombatCardDisplay>();

        if (transform.localPosition.y >= yThreshold - 0.01f || currentTarget != null)
        {

            if (cardDisplay.cardData.validTargets[0] != CombatCard.CardTarget.Player && cardDisplay.cardData.validTargets[0] != CombatCard.CardTarget.Enemy && handManager.PlayCard(transform.gameObject, cardDisplay, null))
            {
                Debug.Log("Successfully Played Card!");
            }
            else if (((cardDisplay.cardData.cost == 0)  || (combatManager.currentCaps >= cardDisplay.cardData.cost)) && currentTarget != null && currentTarget.CompareTag(cardDisplay.cardData.validTargets[0].ToString()) && (currentTarget.name != cardDisplay.cardData.character.ToString() 
                || cardDisplay.cardData.IsSelfInclusive()) && handManager.PlayCard(transform.gameObject, cardDisplay, currentTarget.GetComponent<CharacterInstance>()))
            {
                Debug.Log("Successfully Played Card!");
            }
            else
            {
                ResetCardPosition();
                highlight.color = new Color(0, 255, 23, 0);
            }
        }
        else
        {
            ResetCardPosition();
            highlight.color = new Color(0, 255, 23, 0);
        }

        DragManager.isDragging = false;
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

    void UpdateTargetUnderMouse(PointerEventData eventData)
    {
        // Create a ray from the mouse cursor
        Ray ray = Camera.main.ScreenPointToRay(eventData.position);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);  // Use Physics2D.Raycast for 2D colliders

        // Cast the ray and check if it hits anything
        if (hit.collider != null)
        {
            // Update the target if the ray hits a valid object
            currentTarget = hit.collider.gameObject.transform.parent.gameObject;

            if (currentTarget != null)
            {
                // Add custom logic here (e.g., highlight the target and update card numbers)
                Debug.Log(currentTarget.name);
            }
        }
        else
        {
            // If no target is hit, reset the current target
            currentTarget = null;
        }
    }
}
