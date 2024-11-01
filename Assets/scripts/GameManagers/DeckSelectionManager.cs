using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeckSelectionManager : MonoBehaviour
{
    public List<string> cards = new List<string>();
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
        for (int i = 0; cards.Count-1 >= i; i++)
        {
            GameObject newCard = Instantiate(deckCard, negotiationPosition.transform);
            newCard.gameObject.GetComponentInChildren<TMP_Text>().text = cards.ToArray()[i];
            newCard.transform.position = newCard.transform.position + new Vector3(0, 75 * i, 0);
        }
    }

    void maxcards()
    {
        maxcardsbutton.SetActive(true);
    }
    public void negotiationcardSelected(string cardname)
    {
        GameObject newCard = Instantiate(deckCard, negotiationPosition.transform);
        newCard.gameObject.GetComponentInChildren<TMP_Text>().text = cardname;
        newCard.transform.position = newCard.transform.position + new Vector3 (0, 75 * cards.Count, 0);
        cards.Add(cardname);
        Debug.Log("negotiation " + cardname);
        if (cards.Count > 8)
        {
            maxcards();
        }
    }
    public void combatcardSelected(string cardname)
    {
        GameObject newCard = Instantiate(deckCard, negotiationPosition.transform);
        newCard.gameObject.GetComponentInChildren<TMP_Text>().text = cardname;
        newCard.transform.position = newCard.transform.position + new Vector3(0, 75 * cards.Count, 0);
        cards.Add(cardname);
        Debug.Log("combat " + cardname);
        if (cards.Count > 8)
        {
            maxcards();
        }
    }

}
