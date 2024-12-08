using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class combatscript : MonoBehaviour
{
    randomnumber randomnumber;
    GameManager gamemanager;
    public GameObject combatManager;
    string encounterType = "Combat";

    // Start is called before the first frame update
    void Start()
    {
        randomnumber = this.gameObject.GetComponent<randomnumber>();
        gamemanager = GameObject.Find("GameManager").GetComponent<GameManager>();
        combatManager = gamemanager.combatManager;
    }

    public void loadAssets()
    {
        /*if (randomnumber.generatedNumber == 1 || randomnumber.generatedNumber == 2)
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
            gamemanager.Cassets1.SetActive(true);
        }
        else if (randomnumber.generatedNumber >= 4)
        {
            gamemanager.Cassets2.SetActive(true);
        }*/

        combatManager.SetActive(true);
    }
}
