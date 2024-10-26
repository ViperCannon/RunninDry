using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class deckbuilder : MonoBehaviour, IPointerDownHandler
{
    GameObject pixieCards;
    GameObject baldwinCards;
    GameObject barleyCards;
    private void Start()
    {
        AddPhysics2DRaycaster();
        pixieCards = GameObject.Find("pixiecards");
        baldwinCards = GameObject.Find("baldwincards");
        barleyCards = GameObject.Find("barleycards");
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("Clicked: " + eventData.pointerCurrentRaycast.gameObject.name);
        //this.gameObject.GetComponent<health>().takedamage(clickDamage);
        if (this.gameObject.name == "Pixie")
        {
            for (int i = 0; i< pixieCards.transform.childCount; i++) 
            {
                pixieCards.transform.GetChild(i).gameObject.SetActive(true);
                baldwinCards.transform.GetChild(i).gameObject.SetActive(false);
                barleyCards.transform.GetChild(i).gameObject.SetActive(false);
            }
            
        }
        else if (this.gameObject.name == "Baldwin")
        {
            for (int i = 0; i < baldwinCards.transform.childCount; i++)
            {
                pixieCards.transform.GetChild(i).gameObject.SetActive(false);
                baldwinCards.transform.GetChild(i).gameObject.SetActive(true);
                barleyCards.transform.GetChild(i).gameObject.SetActive(false);
            } 
        }
        else if(this.gameObject.name == "Barley")
        {
            for (int i = 0; i < barleyCards.transform.childCount; i++)
            {
                pixieCards.transform.GetChild(i).gameObject.SetActive(false);
                baldwinCards.transform.GetChild(i).gameObject.SetActive(false);
                barleyCards.transform.GetChild(i).gameObject.SetActive(true);
            }
        }
    }

    private void AddPhysics2DRaycaster()
    {
        Physics2DRaycaster physicsRaycaster = FindObjectOfType<Physics2DRaycaster>();
        if (physicsRaycaster == null)
        {
            Camera.main.gameObject.AddComponent<Physics2DRaycaster>();
        }
    }
}
