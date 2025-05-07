using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class InfoCardPopUp : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] GameObject InfoCard;
    [SerializeField] Vector3 PositionOffset = Vector3.zero;
    private GameObject InfoCardInstance;

    public void OnPointerEnter(PointerEventData eventData)
    {
        InfoCardInstance = GameObject.Instantiate(InfoCard);

        GameObject canvas = FindObjectOfType<Canvas>().gameObject;
        InfoCardInstance.transform.SetParent(canvas.transform);
        InfoCardInstance.transform.position = new Vector3(Screen.width * 0.5f, (Screen.height * 0.5f), 0) + PositionOffset;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Destroy(InfoCardInstance);
    }
}
