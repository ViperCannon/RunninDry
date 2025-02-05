using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatScript : MonoBehaviour
{
    RandomNumber randomNumber;
    GameManager gamemanager;
    public GameObject combatManager;
    string encounterType = "Combat";

    // Start is called before the first frame update
    void Start()
    {
        randomNumber = this.gameObject.GetComponent<RandomNumber>();
        gamemanager = GameObject.Find("GameManager").GetComponent<GameManager>();
        //combatManager = gamemanager.combatManager;
    }

    public void LoadAssets()
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
            gamemanager.Cassets1.SetActive(true);
        }
        else if (randomNumber.generatedNumber >= 4)
        {
            gamemanager.Cassets2.SetActive(true);
        }
        //commented this out because i have no clue what it does and it was throwing errors for me
        //combatManager.SetActive(true);
    }
}
