using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialMysteryScript : MonoBehaviour
{
    GameManager gamemanager;
    string encounterType = "Mystery";
    // Start is called before the first frame update
    void Start()
    {
        gamemanager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    /*public void loadAssets()
    {
        gamemanager.talkerint = randomnumber.generatedNumber;
        gamemanager.encounter(encounterType);
        if (randomnumber.generatedNumber <= 3)
        {
            gamemanager.Massets1.SetActive(true);
        }
        else if (randomnumber.generatedNumber >= 4)
        {
            gamemanager.Massets2.SetActive(true);
        }
    }*/
}
