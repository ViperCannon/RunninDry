using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeckSelectionManager : MonoBehaviour
{
    public List<string> cards = new List<string>();
    public GameObject maxcardsbutton;
    
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
    void maxcards()
    {
        maxcardsbutton.SetActive(true);
    }
    public void negotiationcardSelected(string cardname)
    {
        cards.Add(cardname);
        Debug.Log("negotiation " + cardname);
        if (cards.Count > 8)
        {
            maxcards();
        }
    }
    public void combatcardSelected(string cardname)
    {
        cards.Add(cardname);
        Debug.Log("combat " + cardname);
        if (cards.Count > 8)
        {
            maxcards();
        }
    }

}
