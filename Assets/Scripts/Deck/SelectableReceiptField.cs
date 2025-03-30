using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class SelectableReceiptField : MonoBehaviour, IPointerDownHandler
{
    private TextMeshProUGUI receiptField;
    
    void Awake()
    {
        receiptField = GetComponent<TextMeshProUGUI>();
    }
    
    public void OnPointerDown(PointerEventData eventData) 
    {
        if (receiptField == null)
        {
            return;
        }
        DeckBuilderVer2.Instance.SelectedCharacter.DeselectCard(receiptField.text);
    }
}
