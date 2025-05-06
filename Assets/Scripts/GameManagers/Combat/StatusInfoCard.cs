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
        Debug.Log(transform.localPosition.y);
        
        InfoCardInstance = GameObject.Instantiate(InfoCard);

        GameObject canvas = FindObjectOfType<Canvas>().gameObject;
        InfoCardInstance.transform.SetParent(canvas.transform);

        Vector3 InfoCardSpawnPosition = (transform.localPosition.y >= 0) ? new Vector3(transform.position.x, transform.position.y - 100, transform.position.z) : new Vector3(transform.position.x, transform.position.y + 100, transform.position.z);
        InfoCardInstance.transform.position = InfoCardSpawnPosition;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Destroy(InfoCardInstance);
    }
}
