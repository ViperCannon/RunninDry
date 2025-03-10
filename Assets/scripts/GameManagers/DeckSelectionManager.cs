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
    public List<string> TotalNegotiationCards = new List<string>();
    public List<string> TotalCombatCards = new List<string>();
    public List<string> Pixiecards = new List<string>();
    public List<string> Baldwincards = new List<string>();
    public List<string> Barleycards = new List<string>();
    public List<string> NPixiecards = new List<string>();
    public List<string> CPixiecards = new List<string>();
    public List<string> NBaldwincards = new List<string>();
    public List<string> CBaldwincards = new List<string>();
    public List<string> NBarleycards = new List<string>();
    public List<string> CBarleycards = new List<string>();
    public GameObject maxcardsbutton;
    public GameObject deckCard;
    public GameObject negotiationPosition;
    public GameObject combatPosition;
    public string currentDeck = "Pixie";
    public RawImage pixiesignature;
    public RawImage barleysignature;
    public RawImage baldwinsignature;
    
    // Start is called before the first frame update
    void Start()
    {
        Object.DontDestroyOnLoad(this);
    }
    public void nextScene(int sceneID)
    {
        SceneManager.LoadScene(sceneID);
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void removeCard(string cardname, string deckname)
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
                newCard.gameObject.GetComponentInChildren<TMP_Text>().text = CPixiecards.ToArray()[i];
                newCard.transform.position = newCard.transform.position - new Vector3(0, spacing * i, 0);
            }

            for (int i = 0; NPixiecards.Count - 1 >= i; i++)
            {
                GameObject newCard = Instantiate(deckCard, negotiationPosition.transform);
                newCard.gameObject.GetComponentInChildren<TMP_Text>().text = NPixiecards.ToArray()[i];
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
                newCard.gameObject.GetComponentInChildren<TMP_Text>().text = CBarleycards.ToArray()[i];
                newCard.transform.position = newCard.transform.position - new Vector3(0, spacing * i, 0);
            }

            for (int i = 0; NBarleycards.Count - 1 >= i; i++)
            {
                GameObject newCard = Instantiate(deckCard, negotiationPosition.transform);
                newCard.gameObject.GetComponentInChildren<TMP_Text>().text = NBarleycards.ToArray()[i];
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
                newCard.gameObject.GetComponentInChildren<TMP_Text>().text = CBaldwincards.ToArray()[i];
                newCard.transform.position = newCard.transform.position - new Vector3(0, spacing * i, 0);
            }

            for (int i = 0; NBaldwincards.Count - 1 >= i; i++)
            {
                GameObject newCard = Instantiate(deckCard, negotiationPosition.transform);
                newCard.gameObject.GetComponentInChildren<TMP_Text>().text = NBaldwincards.ToArray()[i];
                newCard.transform.position = newCard.transform.position + new Vector3(0, spacing * i, 0);
            }
            baldwinsignature.gameObject.SetActive(false);
        }
        //cards.Clear();
        
        
        /*for (int i = 0; cards.Count-1 >= i; i++)
        {
            GameObject newCard = Instantiate(deckCard, negotiationPosition.transform);
            newCard.gameObject.GetComponentInChildren<TMP_Text>().text = cards.ToArray()[i];
            newCard.transform.position = newCard.transform.position + new Vector3(0, 75 * i, 0);
        }*/
        maxcardsbutton.SetActive(false);
    }

    void maxcards()
    {
        if (NPixiecards.Count >= 1 && CPixiecards.Count >= 1)
        {
            maxcardsbutton.SetActive(true);
        }
    }
    public void negotiationcardSelected(string cardname, string deckname)
    {
        TotalNegotiationCards.Add(cardname);
        if (deckname == "Pixie")
        {
            if (Pixiecards.Count < 10)
            {
                GameObject newCard = Instantiate(deckCard, negotiationPosition.transform);
                newCard.gameObject.GetComponentInChildren<TMP_Text>().text = cardname;
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
                newCard.gameObject.GetComponentInChildren<TMP_Text>().text = cardname;
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
                newCard.gameObject.GetComponentInChildren<TMP_Text>().text = cardname;
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
            maxcards();
        }
    }
    public void combatcardSelected(string cardname, string deckname)
    {
        TotalCombatCards.Add(cardname);
        if (deckname == "Pixie")
        {
            if (Pixiecards.Count < 10)
            {
                GameObject newCard = Instantiate(deckCard, combatPosition.transform);
                newCard.gameObject.GetComponentInChildren<TMP_Text>().text = cardname;
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
                newCard.gameObject.GetComponentInChildren<TMP_Text>().text = cardname;
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
                newCard.gameObject.GetComponentInChildren<TMP_Text>().text = cardname;
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
            maxcards();
        }
    }

    public void checksignatures(string character)
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
