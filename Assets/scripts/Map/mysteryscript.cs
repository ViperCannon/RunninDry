using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mysteryscript : MonoBehaviour
{
    randomnumber randomnumber;
    GameManager gamemanager;
    string encounterType = "Mystery";
    // Start is called before the first frame update
    void Start()
    {
        randomnumber = this.gameObject.GetComponent<randomnumber>();
        gamemanager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void loadAssets()
    {
        gamemanager.talkerint = randomnumber.generatedNumber;
        gamemanager.encounter(encounterType);
        if (randomnumber.generatedNumber == 1)
        {
            gamemanager.Massets1.SetActive(true);
        }
        else if (randomnumber.generatedNumber == 2)
        {
            gamemanager.Massets2.SetActive(true);
        }
    }
}
