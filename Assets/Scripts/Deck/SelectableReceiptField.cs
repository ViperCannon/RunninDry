using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class SelectableReceiptField : MonoBehaviour, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler
{
    private TextMeshProUGUI receiptField;

    private Color32 originalColor;
    private Color32 highlightedColor = new(163, 39, 39, 255);

    void Awake()
    {
        receiptField = GetComponent<TextMeshProUGUI>();
        originalColor = receiptField.color;
    }
    
    public void OnPointerDown(PointerEventData eventData) 
    {
        if (receiptField == null)
        {
            return;
        }
        DeckBuilderVer2.Instance.SelectedCharacter.DeselectCard(receiptField.text);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (receiptField == null)
        {
            return;
        }
        receiptField.color = highlightedColor;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (receiptField == null)
        {
            return;
        }
        receiptField.color = originalColor;
    }
}
