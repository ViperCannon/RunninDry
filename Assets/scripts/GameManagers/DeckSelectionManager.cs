using SpeakeasyStreet;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DeckSelectionManager : MonoBehaviour, IDataPersistence
{
    public float spacing;
    [Header("Total Cards")]
    public List<string> TotalNegotiationCards = new();
    public List<string> TotalCombatCards = new();
    public List<string> Pixiecards = new();
    public List<string> Baldwincards = new();
    public List<string> Barleycards = new();
    public List<string> NPixiecards = new();
    public List<string> CPixiecards = new();
    public List<string> NBaldwincards = new();
    public List<string> CBaldwincards = new();
    public List<string> NBarleycards = new();
    public List<string> CBarleycards = new();
    public GameObject maxcardsbutton;
    public GameObject deckCard;
    public GameObject negotiationPosition;
    public GameObject combatPosition;
    public string currentDeck = "Pixie";
    public RawImage pixiesignature;
    public RawImage barleysignature;
    public RawImage baldwinsignature;
    
    void Start()
    {
        Object.DontDestroyOnLoad(this);
    }

    public void NextScene(int sceneID)
    {
        SceneManager.LoadScene(sceneID);
    }

    public void RemoveCard(string cardname, string deckname)
    {
        GameObject[] gos = GameObject.FindGameObjectsWithTag("cardlist");
        foreach (GameObject go in gos)
        {
            Destroy(go);
        }
        if (TotalCombatCards.Contains(cardname))
        {
            TotalCombatCards.Remove(cardname);
        }
        else if (TotalNegotiationCards.Contains(cardname))
        {
            TotalNegotiationCards.Remove(cardname);
        }

        if (deckname == "Pixie")
        {
            Pixiecards.Remove(cardname);
            if (CPixiecards.Contains(cardname))
            {
                CPixiecards.Remove(cardname);
            }
            else if (NPixiecards.Contains(cardname))
            {
                NPixiecards.Remove(cardname);
            }
            for (int i = 0; CPixiecards.Count - 1 >= i; i++)
            {
                GameObject newCard = Instantiate(deckCard, combatPosition.transform);
                newCard.GetComponentInChildren<TMP_Text>().text = CPixiecards.ToArray()[i];
                newCard.transform.position = newCard.transform.position - new Vector3(0, spacing * i, 0);
            }

            for (int i = 0; NPixiecards.Count - 1 >= i; i++)
            {
                GameObject newCard = Instantiate(deckCard, negotiationPosition.transform);
                newCard.GetComponentInChildren<TMP_Text>().text = NPixiecards.ToArray()[i];
                newCard.transform.position = newCard.transform.position + new Vector3(0, spacing * i, 0);
            }
            pixiesignature.gameObject.SetActive(false);
        }
        else if (deckname == "Barley")
        {
            Barleycards.Remove(cardname);
            if (CBarleycards.Contains(cardname))
            {
                CBarleycards.Remove(cardname);
            }
            else if (NBarleycards.Contains(cardname))
            {
                NBarleycards.Remove(cardname);
            }
            for (int i = 0; CBarleycards.Count - 1 >= i; i++)
            {
                GameObject newCard = Instantiate(deckCard, combatPosition.transform);
                newCard.GetComponentInChildren<TMP_Text>().text = CBarleycards.ToArray()[i];
                newCard.transform.position = newCard.transform.position - new Vector3(0, spacing * i, 0);
            }

            for (int i = 0; NBarleycards.Count - 1 >= i; i++)
            {
                GameObject newCard = Instantiate(deckCard, negotiationPosition.transform);
                newCard.GetComponentInChildren<TMP_Text>().text = NBarleycards.ToArray()[i];
                newCard.transform.position = newCard.transform.position + new Vector3(0, spacing * i, 0);
            }
            barleysignature.gameObject.SetActive(false);
        }
        else if (deckname == "Baldwin")
        {
            Baldwincards.Remove(cardname);
            if (CBaldwincards.Contains(cardname))
            {
                CBaldwincards.Remove(cardname);
            }
            else if (NBaldwincards.Contains(cardname))
            {
                NBaldwincards.Remove(cardname);
            }
            for (int i = 0; CBaldwincards.Count - 1 >= i; i++)
            {
                GameObject newCard = Instantiate(deckCard, combatPosition.transform);
                newCard.GetComponentInChildren<TMP_Text>().text = CBaldwincards.ToArray()[i];
                newCard.transform.position = newCard.transform.position - new Vector3(0, spacing * i, 0);
            }

            for (int i = 0; NBaldwincards.Count - 1 >= i; i++)
            {
                GameObject newCard = Instantiate(deckCard, negotiationPosition.transform);
                newCard.GetComponentInChildren<TMP_Text>().text = NBaldwincards.ToArray()[i];
                newCard.transform.position = newCard.transform.position + new Vector3(0, spacing * i, 0);
            }
            baldwinsignature.gameObject.SetActive(false);
        }
        //Cards.Clear();
        
        
        /*for (int i = 0; Cards.Count-1 >= i; i++)
        {
            GameObject newCard = Instantiate(deckCard, negotiationPosition.transform);
            newCard.gameObject.GetComponentInChildren<TMP_Text>().text = Cards.ToArray()[i];
            newCard.transform.position = newCard.transform.position + new Vector3(0, 75 * i, 0);
        }*/
        maxcardsbutton.SetActive(false);
    }

    void MaxCards()
    {
        if (NPixiecards.Count >= 1 && CPixiecards.Count >= 1)
        {
            maxcardsbutton.SetActive(true);
        }
    }
    public void NegotiationCardSelected(string cardname, string deckname)
    {
        TotalNegotiationCards.Add(cardname);
        if (deckname == "Pixie")
        {
            if (Pixiecards.Count < 10)
            {
                GameObject newCard = Instantiate(deckCard, negotiationPosition.transform);
                newCard.GetComponentInChildren<TMP_Text>().text = cardname;
                newCard.transform.position = newCard.transform.position + new Vector3(0, spacing * NPixiecards.Count, 0);
                Pixiecards.Add(cardname);
                NPixiecards.Add(cardname);
                Debug.Log("Pixie negotiation " + cardname);
                if (Pixiecards.Count == 10)
                {
                    pixiesignature.gameObject.SetActive(true);
                }
            }
        }
        else if (deckname == "Baldwin")
        {
            if (Baldwincards.Count < 10)
            {
                GameObject newCard = Instantiate(deckCard, negotiationPosition.transform);
                newCard.GetComponentInChildren<TMP_Text>().text = cardname;
                newCard.transform.position = newCard.transform.position + new Vector3(0, spacing * NBaldwincards.Count, 0);
                Baldwincards.Add(cardname);
                NBaldwincards.Add(cardname);
                Debug.Log("Baldwin negotiation " + cardname);
                if (Baldwincards.Count == 10)
                {
                    baldwinsignature.gameObject.SetActive(true);
                }
            }
        }
        else if (deckname == "Barley")
        {
            if (Barleycards.Count < 10)
            {
                GameObject newCard = Instantiate(deckCard, negotiationPosition.transform);
                newCard.GetComponentInChildren<TMP_Text>().text = cardname;
                newCard.transform.position = newCard.transform.position + new Vector3(0, spacing * NBarleycards.Count, 0);
                Barleycards.Add(cardname);
                NBarleycards.Add(cardname);
                Debug.Log("Barley negotiation " + cardname);
                if (Barleycards.Count == 10)
                {
                    barleysignature.gameObject.SetActive(true);
                }
            }
        }
        if (Pixiecards.Count >= 10 && Barleycards.Count >= 10 && Baldwincards.Count >= 10)
        {
            MaxCards();
        }
    }
    public void CombatCardSelected(string cardname, string deckname)
    {
        TotalCombatCards.Add(cardname);
        if (deckname == "Pixie")
        {
            if (Pixiecards.Count < 10)
            {
                GameObject newCard = Instantiate(deckCard, combatPosition.transform);
                newCard.GetComponentInChildren<TMP_Text>().text = cardname;
                newCard.transform.position = newCard.transform.position - new Vector3(0, spacing * CPixiecards.Count, 0);
                Pixiecards.Add(cardname);
                CPixiecards.Add(cardname);
                Debug.Log("combat " + cardname);
                if (Pixiecards.Count == 10)
                {
                    pixiesignature.gameObject.SetActive(true);
                }
            }
        }
        else if (deckname == "Barley")
        {
            if (Barleycards.Count < 10)
            {
                GameObject newCard = Instantiate(deckCard, combatPosition.transform);
                newCard.GetComponentInChildren<TMP_Text>().text = cardname;
                newCard.transform.position = newCard.transform.position - new Vector3(0, spacing * CBarleycards.Count, 0);
                Barleycards.Add(cardname);
                CBarleycards.Add(cardname);
                Debug.Log("combat " + cardname);
                if (Barleycards.Count == 10)
                {
                    barleysignature.gameObject.SetActive(true);
                }
            }
        }
        else if (deckname == "Baldwin")
        {
            if (Baldwincards.Count < 10)
            {
                GameObject newCard = Instantiate(deckCard, combatPosition.transform);
                newCard.GetComponentInChildren<TMP_Text>().text = cardname;
                newCard.transform.position = newCard.transform.position - new Vector3(0, spacing * CBaldwincards.Count, 0);
                Baldwincards.Add(cardname);
                CBaldwincards.Add(cardname);
                Debug.Log("combat " + cardname);
                if (Baldwincards.Count == 10)
                {
                    baldwinsignature.gameObject.SetActive(true);
                }
            }
        }
        if (Pixiecards.Count >= 10 && Barleycards.Count >= 10 && Baldwincards.Count >= 10)
        {
            MaxCards();
        }
    }

    public void CheckSignatures(string character)
    {
        if (character == "Pixie")
        {
            if (Pixiecards.Count == 10)
            {
                pixiesignature.gameObject.SetActive(true);
            }
        }
        if (character == "Barley")
        {
            if (Barleycards.Count == 10)
            {
                barleysignature.gameObject.SetActive(true);
            }
        }
        if (character == "Baldwin")
        {
            if (Baldwincards.Count == 10)
            {
                baldwinsignature.gameObject.SetActive(true);
            }
        }
        else
        {
            //do nothing
        }
    }

    //beginnings of card display to help out with logic. Feel free to change as you see fit, but want to hopefully provide a good basis

    public GameObject cardDisplayPanel;
    public GameObject combatCardPrefabVariant;
    public GameObject negotiationCardPrefabVariant;

    public void PrepCardDisplay(string characterName, bool displayCombat)
    {
        characterName = characterName.ToLower();

        if(displayCombat)
        {
            switch (characterName)
            {
                case "pixie":

                    DisplayCombatCards(Resources.LoadAll<NegotiationCard>("CardData/Combat/Pixie"));

                    break;

                case "baldwin":

                    DisplayCombatCards(Resources.LoadAll<NegotiationCard>("CardData/Combat/Baldwin"));

                    break;

                case "barley":

                    DisplayCombatCards(Resources.LoadAll<NegotiationCard>("CardData/Combat/Barley"));

                    break;
            }
        }
        else
        {
            switch (characterName)
            {
                case "pixie":

                    DisplayNegotiationCards(Resources.LoadAll<NegotiationCard>("CardData/Negotiation/Pixie"));

                    break;

                case "baldwin":

                    DisplayNegotiationCards(Resources.LoadAll<NegotiationCard>("CardData/Negotiation/Baldwin"));

                    break;

                case "barley":

                    DisplayNegotiationCards(Resources.LoadAll<NegotiationCard>("CardData/Negotiation/Barley"));

                    break;
            }
        }
    }

    public void DisplayCombatCards(Card[] cards)
    {
        foreach(CombatCard c in cards)
        {
            GameObject temp = Instantiate(combatCardPrefabVariant, cardDisplayPanel.transform);

            temp.GetComponent<CombatCardDisplay>().cardData = c;
        }     
    }

    public void DisplayNegotiationCards(Card[] cards)
    {
        foreach (NegotiationCard n in cards)
        {
            GameObject temp = Instantiate(negotiationCardPrefabVariant, cardDisplayPanel.transform);

            temp.GetComponent<NegotiationCardDisplay>().cardData = n;
        }
    }

    public void ClearCardDisplay()
    {
        foreach(Transform child in cardDisplayPanel.transform)
        {
            Destroy(child.gameObject);
        }
    }

    public void LoadData(GameData data)
    {
        TotalCombatCards = data.TotalCombatCards;
        TotalNegotiationCards = data.TotalNegotiationCards;
        Pixiecards = data.Pixiecards;
        Barleycards = data.Barleycards;
        Baldwincards = data.Baldwincards;
        CPixiecards = data.CPixiecards;
        CBarleycards = data.CBarleycards;
        CBaldwincards = data.CBaldwincards;
        NPixiecards = data.NPixiecards;
        NBarleycards = data.NBarleycards;
        NBaldwincards = data.NBaldwincards;
    }

    public void SaveData(ref GameData data)
    {
        data.TotalCombatCards = TotalCombatCards;
        data.TotalNegotiationCards = TotalNegotiationCards;
        data.Pixiecards = Pixiecards;
        data.Barleycards = Barleycards;
        data.Baldwincards = Baldwincards;
        data.CPixiecards = CPixiecards;
        data.CBarleycards = CBarleycards;
        data.CBaldwincards = CBaldwincards;
        data.NPixiecards = NPixiecards;
        data.NBarleycards = NBarleycards;
        data.NBaldwincards = NBaldwincards;
    }

}
