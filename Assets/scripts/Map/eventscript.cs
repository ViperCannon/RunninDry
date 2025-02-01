using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eventscript : MonoBehaviour
{
    randomnumber randomnumber;
    GameManager gamemanager;
    string encounterType = "Event";
    // Start is called before the first frame update
    void Start()
    {
        randomnumber = this.gameObject.GetComponent<randomnumber>();
        gamemanager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    public void loadAssets()
    {
        gamemanager.talkerint = randomnumber.generatedNumber;
        gamemanager.Encounter(encounterType);
        if (randomnumber.generatedNumber <= 3)
        {
            gamemanager.Eassets1.SetActive(true);
        }
        else if (randomnumber.generatedNumber >= 4)
        {
            gamemanager.Eassets2.SetActive(true);
        }
    }
}
