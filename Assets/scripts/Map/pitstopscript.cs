using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pitstopscript : MonoBehaviour
{
    randomnumber randomnumber;
    GameManager gamemanager;
    string encounterType = "Pitstop";
    // Start is called before the first frame update
    void Start()
    {
        randomnumber = this.gameObject.GetComponent<randomnumber>();
        gamemanager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    public void loadAssets()
    {
        gamemanager.talkerint = randomnumber.generatedNumber;
        gamemanager.encounter(encounterType);
        if (randomnumber.generatedNumber <= 3)
        {
            gamemanager.Passets1.SetActive(true);
        }
        else if (randomnumber.generatedNumber >= 4)
        {
            gamemanager.Passets2.SetActive(true);
        }
    }
}
