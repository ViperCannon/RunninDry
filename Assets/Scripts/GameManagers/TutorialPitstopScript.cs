using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialPitstopScript : MonoBehaviour
{
    GameManager gamemanager;
    string encounterType = "Pitstop";
    // Start is called before the first frame update
    void Start()
    {
        gamemanager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    /*public void loadAssets()
    {
        gamemanager.talkerint = RandomNumber.generatedNumber;
        gamemanager.encounter(encounterType);
        if (RandomNumber.generatedNumber <= 3)
        {
            gamemanager.Passets1.SetActive(true);
        }
        else if (RandomNumber.generatedNumber >= 4)
        {
            gamemanager.Passets2.SetActive(true);
        }
    }*/
}
