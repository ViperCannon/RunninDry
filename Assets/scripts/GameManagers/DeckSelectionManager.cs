using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeckSelectionManager : MonoBehaviour
{
    public List<string> cards = new List<string>();
    public List<string> Ncards = new List<string>();
    public List<string> Ccards = new List<string>();
    public GameObject maxcardsbutton;
    public GameObject deckCard;
    public GameObject negotiationPosition;
    public GameObject combatPosition;
    
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

    public void removeCard(string cardname)
    {
        //cards.Clear();
        GameObject[] gos = GameObject.FindGameObjectsWithTag("cardlist");
        foreach (GameObject go in gos)
        {
            Destroy(go);
        }
        cards.Remove(cardname);
        if (Ccards.Contains(cardname))
        {
            Ccards.Remove(cardname);
        }
        else if (Ncards.Contains(cardname))
        {
            Ncards.Remove(cardname);
        }
        for (int i = 0; Ccards.Count - 1 >= i; i++)
        {
            GameObject newCard = Instantiate(deckCard, combatPosition.transform);
            newCard.gameObject.GetComponentInChildren<TMP_Text>().text = Ccards.ToArray()[i];
            newCard.transform.position = newCard.transform.position - new Vector3(0, 75 * i, 0);
        }
        
        for (int i = 0; Ncards.Count - 1 >= i; i++)
        {
            GameObject newCard = Instantiate(deckCard, negotiationPosition.transform);
            newCard.gameObject.GetComponentInChildren<TMP_Text>().text = Ncards.ToArray()[i];
            newCard.transform.position = newCard.transform.position + new Vector3(0, 75 * i, 0);
        }
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
        maxcardsbutton.SetActive(true);
    }
    public void negotiationcardSelected(string cardname)
    {
        if (cards.Count <= 8)
        {
            GameObject newCard = Instantiate(deckCard, negotiationPosition.transform);
            newCard.gameObject.GetComponentInChildren<TMP_Text>().text = cardname;
            newCard.transform.position = newCard.transform.position + new Vector3(0, 75 * Ncards.Count, 0);
            cards.Add(cardname);
            Ncards.Add(cardname);
            Debug.Log("negotiation " + cardname);
        }
        if (cards.Count >= 8)
        {
            maxcards();
        }
    }
    public void combatcardSelected(string cardname)
    {
        if (cards.Count <= 8)
        {
            GameObject newCard = Instantiate(deckCard, combatPosition.transform);
            newCard.gameObject.GetComponentInChildren<TMP_Text>().text = cardname;
            newCard.transform.position = newCard.transform.position - new Vector3(0, 75 * Ccards.Count, 0);
            cards.Add(cardname);
            Ccards.Add(cardname);
            Debug.Log("combat " + cardname);
        }
        if (cards.Count >= 8)
        {
            maxcards();
        }
    }
}
