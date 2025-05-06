using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class StatusInfoCard : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] GameObject InfoCard;
    private GameObject InfoCardInstance;

    public void OnPointerEnter(PointerEventData eventData)
    {
        InfoCardInstance = GameObject.Instantiate(InfoCard);

        GameObject canvas = FindObjectOfType<Canvas>().gameObject;
        InfoCardInstance.transform.SetParent(canvas.transform);

        InfoCardInstance.transform.position = Vector3.zero;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Destroy(InfoCardInstance);
    }
}
