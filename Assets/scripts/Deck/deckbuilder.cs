using SpeakeasyStreet;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class DeckBuilder : MonoBehaviour, IPointerDownHandler
{
    GameObject pixieCards;
    GameObject baldwinCards;
    GameObject barleyCards;
    TMP_Text cardName;
    public bool exempt;
    //public string currentDeck = "Pixie";

    DeckSelectionManager selectionManager;
    private void Start()
    {
        selectionManager = GameObject.Find("DeckSelectionHandler").GetComponent<DeckSelectionManager>();
        AddPhysics2DRaycaster();
        pixieCards = GameObject.Find("pixiecards");
        baldwinCards = GameObject.Find("baldwincards");
        barleyCards = GameObject.Find("barleycards");
        cardName = gameObject.GetComponentInChildren<TMP_Text>();
        if (!exempt)
        { 
            cardName.text = this.gameObject.name;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        
        //this.gameObject.GetComponent<health>().takedamage(clickDamage);
        if (this.gameObject.name == "Pixie")
        {
            selectionManager.currentDeck = "Pixie";
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
            ChangeCardList(selectionManager.currentDeck);
            Debug.Log("Clicked: " + eventData.pointerCurrentRaycast.gameObject.name);
            selectionManager.checksignatures(this.gameObject.name);
        }
        else if (this.gameObject.name == "Baldwin")
        {
            selectionManager.currentDeck = "Baldwin";
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
            ChangeCardList(selectionManager.currentDeck);
            selectionManager.checksignatures(this.gameObject.name);
        }
        else if (this.gameObject.name == "Barley")
        {
            selectionManager.currentDeck = "Barley";
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
            ChangeCardList(selectionManager.currentDeck);
            selectionManager.checksignatures(this.gameObject.name);
        }
        else if (this.gameObject.tag == "cardlist")
        {
            selectionManager.removeCard(this.gameObject.GetComponentInChildren<TMP_Text>().text, selectionManager.currentDeck);
        }

        if (this.gameObject.tag == "negotiation")
        {
            selectionManager.negotiationcardSelected(this.gameObject.name, selectionManager.currentDeck);
            Debug.Log(this.gameObject.name + selectionManager.currentDeck);
        }
        else if (this.gameObject.tag == "combat")
        {
            selectionManager.combatcardSelected(this.gameObject.name, selectionManager.currentDeck);
        }

        if (this.gameObject.name == "PNegotiation")
        {
            pixieCards.transform.Find("Negotiation").gameObject.SetActive(true);
            pixieCards.transform.Find("Combat").gameObject.SetActive(false);
            selectionManager.checksignatures(this.gameObject.name);
        }
        else if (this.gameObject.name == "PCombat")
        {
            pixieCards.transform.Find("Combat").gameObject.SetActive(true);
            pixieCards.transform.Find("Negotiation").gameObject.SetActive(false);
            selectionManager.checksignatures(this.gameObject.name);
        }
        else if (this.gameObject.name == "BDCombat")
        {
            baldwinCards.transform.Find("Combat").gameObject.SetActive(true);
            baldwinCards.transform.Find("Negotiation").gameObject.SetActive(false);
            selectionManager.checksignatures(this.gameObject.name);
        }
        else if (this.gameObject.name == "BDNegotiation")
        {
            baldwinCards.transform.Find("Negotiation").gameObject.SetActive(true);
            baldwinCards.transform.Find("Combat").gameObject.SetActive(false);
            selectionManager.checksignatures(this.gameObject.name);
        }
        else if (this.gameObject.name == "BCombat")
        {
            barleyCards.transform.Find("Combat").gameObject.SetActive(true);
            barleyCards.transform.Find("Negotiation").gameObject.SetActive(false);
            selectionManager.checksignatures(this.gameObject.name);
        }
        else if (this.gameObject.name == "BNegotiation")
        {
            barleyCards.transform.Find("Negotiation").gameObject.SetActive(true);
            barleyCards.transform.Find("Combat").gameObject.SetActive(false);
            selectionManager.checksignatures(this.gameObject.name);
        }
    }

    public void ChangeCardList(string DeckName)
    {
        GameObject[] gos = GameObject.FindGameObjectsWithTag("cardlist");
        foreach (GameObject go in gos)
        {
            Destroy(go);
        }
        if (DeckName == "Pixie")
        {
            for (int i = 0; selectionManager.CPixiecards.Count - 1 >= i; i++)
            {
                GameObject newCard = Instantiate(selectionManager.deckCard, selectionManager.combatPosition.transform);
                newCard.gameObject.GetComponentInChildren<TMP_Text>().text = selectionManager.CPixiecards.ToArray()[i];
                newCard.transform.position = newCard.transform.position - new Vector3(0, 50 * i, 0);
            }

            for (int i = 0; selectionManager.NPixiecards.Count - 1 >= i; i++)
            {
                GameObject newCard = Instantiate(selectionManager.deckCard, selectionManager.negotiationPosition.transform);
                newCard.gameObject.GetComponentInChildren<TMP_Text>().text = selectionManager.NPixiecards.ToArray()[i];
                newCard.transform.position = newCard.transform.position + new Vector3(0, 50 * i, 0);
            }
        }
        else if (DeckName == "Baldwin")
        {
            for (int i = 0; selectionManager.CBaldwincards.Count - 1 >= i; i++)
            {
                GameObject newCard = Instantiate(selectionManager.deckCard, selectionManager.combatPosition.transform);
                newCard.gameObject.GetComponentInChildren<TMP_Text>().text = selectionManager.CBaldwincards.ToArray()[i];
                newCard.transform.position = newCard.transform.position - new Vector3(0, 50 * i, 0);
            }

            for (int i = 0; selectionManager.NBaldwincards.Count - 1 >= i; i++)
            {
                GameObject newCard = Instantiate(selectionManager.deckCard, selectionManager.negotiationPosition.transform);
                newCard.gameObject.GetComponentInChildren<TMP_Text>().text = selectionManager.NBaldwincards.ToArray()[i];
                newCard.transform.position = newCard.transform.position + new Vector3(0, 50 * i, 0);
            }
        }
        else if (DeckName == "Barley")
        {
            for (int i = 0; selectionManager.CBarleycards.Count - 1 >= i; i++)
            {
                GameObject newCard = Instantiate(selectionManager.deckCard, selectionManager.combatPosition.transform);
                newCard.gameObject.GetComponentInChildren<TMP_Text>().text = selectionManager.CBarleycards.ToArray()[i];
                newCard.transform.position = newCard.transform.position - new Vector3(0, 50 * i, 0);
            }

            for (int i = 0; selectionManager.NBarleycards.Count - 1 >= i; i++)
            {
                GameObject newCard = Instantiate(selectionManager.deckCard, selectionManager.negotiationPosition.transform);
                newCard.gameObject.GetComponentInChildren<TMP_Text>().text = selectionManager.NBarleycards.ToArray()[i];
                newCard.transform.position = newCard.transform.position + new Vector3(0, 50 * i, 0);
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
