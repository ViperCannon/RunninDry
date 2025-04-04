using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class TutorialInfoCard : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] TextMeshProUGUI TutorialTextTMP;
    [SerializeField] string TextToDisplay;

    void Start()
    {
        TutorialTextTMP.text = "THIS IS THE DEFAULT TEXT. NO INFO CARD IS HIGHLIGHTED";
        TutorialTextTMP.gameObject.SetActive(false);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        TutorialTextTMP.text = TextToDisplay;
        TutorialTextTMP.gameObject.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        TutorialTextTMP.text = "THIS IS THE DEFAULT TEXT. NO INFO CARD IS HIGHLIGHTED";
        TutorialTextTMP.gameObject.SetActive(false);
    }
}
