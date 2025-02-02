using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NegotiationScript : MonoBehaviour
{
    RandomNumber randomNumber;
    GameManager gamemanager;
    [SerializeField]
    GameObject assets1;
    [SerializeField]
    GameObject assets2;
    string encounterType = "Negotiation";

    // Start is called before the first frame update
    void Start()
    {
        randomNumber = this.gameObject.GetComponent<RandomNumber>();
        gamemanager = GameObject.Find("GameManager").GetComponent<GameManager>();
        //GrabAssets();
        if (assets1 != null && assets2 != null)
        {
           // assets1.gameObject.SetActive(false);
           // assets2.gameObject.SetActive(false);
        }
        
    }

    public void GrabAssets()
    {
        if (GameObject.Find("N1") != null && GameObject.Find("N2") != null)
        {
            assets1 = GameObject.Find("N1");
            assets2 = GameObject.Find("N2");
        }
    }
    public void loadAssets()
    {
        if (randomNumber.generatedNumber == 1 || randomNumber.generatedNumber == 2)
        {
            gamemanager.talkerint = 1;
        }
        else if (randomNumber.generatedNumber == 3 || randomNumber.generatedNumber == 4)
        {
            gamemanager.talkerint = 2;
        }
        else if (randomNumber.generatedNumber == 5 || randomNumber.generatedNumber == 6)
        {
            gamemanager.talkerint = 3;
        }
        //gamemanager.talkerint = RandomNumber.generatedNumber;
        gamemanager.Encounter(encounterType);
        if (randomNumber.generatedNumber <= 3)
        {
            gamemanager.Nassets1.SetActive(true);
        }
        else if (randomNumber.generatedNumber >= 4) 
        {
            gamemanager.Nassets2.SetActive(true);
        }
    }
}
