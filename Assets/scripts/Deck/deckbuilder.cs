using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class DeckBuilder : MonoBehaviour, IPointerDownHandler
{
    GameObject pixieCards;
    GameObject baldwinCards;
    GameObject barleyCards;

    DeckSelectionManager selectionManager;
    private void Start()
    {
        selectionManager = GameObject.Find("DeckSelectionHandler").GetComponent<DeckSelectionManager>();
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
                //pixieCards.transform.GetChild(i).gameObject.SetActive(true);
                pixieCards.transform.Find("Negotiation").gameObject.SetActive(true);
                baldwinCards.transform.GetChild(i).gameObject.SetActive(false);
                barleyCards.transform.GetChild(i).gameObject.SetActive(false);
                GameObject.Find("filters").transform.Find("PNegotiation").gameObject.SetActive(true);
                GameObject.Find("filters").transform.Find("PCombat").gameObject.SetActive(true);
                GameObject.Find("filters").transform.Find("BDNegotiation").gameObject.SetActive(false);
                GameObject.Find("filters").transform.Find("BDCombat").gameObject.SetActive(false);
                GameObject.Find("filters").transform.Find("BNegotiation").gameObject.SetActive(false);
                GameObject.Find("filters").transform.Find("BCombat").gameObject.SetActive(false);
            }
            
        }
        else if (this.gameObject.name == "Baldwin")
        {
            for (int i = 0; i < baldwinCards.transform.childCount && i < pixieCards.transform.childCount; i++)
            {
                pixieCards.transform.GetChild(i).gameObject.SetActive(false);
                baldwinCards.transform.Find("Negotiation").gameObject.SetActive(true);
                barleyCards.transform.GetChild(i).gameObject.SetActive(false);
                GameObject.Find("filters").transform.Find("PNegotiation").gameObject.SetActive(false);
                GameObject.Find("filters").transform.Find("PCombat").gameObject.SetActive(false);
                GameObject.Find("filters").transform.Find("BDNegotiation").gameObject.SetActive(true);
                GameObject.Find("filters").transform.Find("BDCombat").gameObject.SetActive(true);
                GameObject.Find("filters").transform.Find("BNegotiation").gameObject.SetActive(false);
                GameObject.Find("filters").transform.Find("BCombat").gameObject.SetActive(false);
            } 
        }
        else if (this.gameObject.name == "Barley")
        {
            for (int i = 0; i < barleyCards.transform.childCount && i < pixieCards.transform.childCount; i++)
            {
                pixieCards.transform.GetChild(i).gameObject.SetActive(false);
                baldwinCards.transform.GetChild(i).gameObject.SetActive(false);
                barleyCards.transform.Find("Negotiation").gameObject.SetActive(true);
                GameObject.Find("filters").transform.Find("PNegotiation").gameObject.SetActive(false);
                GameObject.Find("filters").transform.Find("PCombat").gameObject.SetActive(false);
                GameObject.Find("filters").transform.Find("BDNegotiation").gameObject.SetActive(false);
                GameObject.Find("filters").transform.Find("BDCombat").gameObject.SetActive(false);
                GameObject.Find("filters").transform.Find("BNegotiation").gameObject.SetActive(true);
                GameObject.Find("filters").transform.Find("BCombat").gameObject.SetActive(true);
            }
        }

        if (this.gameObject.tag == "negotiation")
        {
            selectionManager.negotiationcardSelected(this.gameObject.name);
        }
        else if (this.gameObject.tag == "combat")
        {
            selectionManager.combatcardSelected(this.gameObject.name);
        }

        if (this.gameObject.name == "PNegotiation")
        {
            pixieCards.transform.Find("Negotiation").gameObject.SetActive(true);
            pixieCards.transform.Find("Combat").gameObject.SetActive(false);
        }
        else if (this.gameObject.name == "PCombat")
        {
            pixieCards.transform.Find("Combat").gameObject.SetActive(true);
            pixieCards.transform.Find("Negotiation").gameObject.SetActive(false);
        }
        else if (this.gameObject.name == "BDCombat")
        {
            baldwinCards.transform.Find("Combat").gameObject.SetActive(true);
            baldwinCards.transform.Find("Negotiation").gameObject.SetActive(false);
        }
        else if (this.gameObject.name == "BDNegotiation")
        {
            baldwinCards.transform.Find("Negotiation").gameObject.SetActive(true);
            baldwinCards.transform.Find("Combat").gameObject.SetActive(false);
        }
        else if (this.gameObject.name == "BCombat")
        {
            barleyCards.transform.Find("Combat").gameObject.SetActive(true);
            barleyCards.transform.Find("Negotiation").gameObject.SetActive(false);
        }
        else if (this.gameObject.name == "BNegotiation")
        {
            barleyCards.transform.Find("Negotiation").gameObject.SetActive(true);
            barleyCards.transform.Find("Combat").gameObject.SetActive(false);
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
