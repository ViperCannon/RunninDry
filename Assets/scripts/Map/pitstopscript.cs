using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PitstopScript : MonoBehaviour
{
    RandomNumber randomNumber;
    GameManager gamemanager;
    string encounterType = "Pitstop";
    // Start is called before the first frame update
    void Start()
    {
        randomNumber = this.gameObject.GetComponent<RandomNumber>();
        gamemanager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    public void loadAssets()
    {
        gamemanager.talkerint = randomNumber.generatedNumber;
        gamemanager.Encounter(encounterType);
        if (randomNumber.generatedNumber <= 3)
        {
            gamemanager.Passets1.SetActive(true);
        }
        else if (randomNumber.generatedNumber >= 4)
        {
            gamemanager.Passets2.SetActive(true);
        }
    }
}
