using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialCombatScript : MonoBehaviour
{
    GameManager gamemanager;
    public GameObject combatManager;
    string encounterType = "Combat";

    // Start is called before the first frame update
    void Start()
    {
        gamemanager = GameObject.Find("GameManager").GetComponent<GameManager>();
        combatManager = CombatManager.GetInstance().gameObject;
    }

    public void loadAssets()
    {
        /*if (RandomNumber.generatedNumber == 1 || RandomNumber.generatedNumber == 2)
        {
            gamemanager.talkerint = 1;
        }
        else if (RandomNumber.generatedNumber == 3 || RandomNumber.generatedNumber == 4)
        {
            gamemanager.talkerint = 2;
        }
        else if (RandomNumber.generatedNumber == 5 || RandomNumber.generatedNumber == 6)
        {
            gamemanager.talkerint = 3;
        }
        //gamemanager.talkerint = RandomNumber.generatedNumber;
        gamemanager.encounter(encounterType);
        if (RandomNumber.generatedNumber <= 3)
        {
            gamemanager.Cassets1.SetActive(true);
        }
        else if (RandomNumber.generatedNumber >= 4)
        {
            gamemanager.Cassets2.SetActive(true);
        }*/

        combatManager.SetActive(true);
    }
}
