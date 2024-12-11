using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialNegotiationScript : MonoBehaviour
{
    GameManager gamemanager;
    [SerializeField]
    GameObject assets1;
    [SerializeField]
    GameObject assets2;
    string encounterType = "Negotiation";

    // Start is called before the first frame update
    void Start()
    {

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

   /* public void loadAssets()
    {
        if (randomnumber.generatedNumber == 1 || randomnumber.generatedNumber == 2)
        {
            gamemanager.talkerint = 1;
        }
        else if (randomnumber.generatedNumber == 3 || randomnumber.generatedNumber == 4)
        {
            gamemanager.talkerint = 2;
        }
        else if (randomnumber.generatedNumber == 5 || randomnumber.generatedNumber == 6)
        {
            gamemanager.talkerint = 3;
        }
        //gamemanager.talkerint = randomnumber.generatedNumber;
        gamemanager.encounter(encounterType);
        if (randomnumber.generatedNumber <= 3)
        {
            gamemanager.Nassets1.SetActive(true);
        }
        else if (randomnumber.generatedNumber >= 4)
        {
            gamemanager.Nassets2.SetActive(true);
        }
    }*/
}
