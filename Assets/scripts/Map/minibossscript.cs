using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinibossScript : MonoBehaviour
{
    randomnumber randomnumber;
    GameManager gamemanager;
    // Start is called before the first frame update
    void Start()
    {
        randomnumber = this.gameObject.GetComponent<randomnumber>();
        gamemanager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    public void loadAssets()
    {
        if (randomnumber.generatedNumber == 1)
        {
            gamemanager.MBassets1.SetActive(true);
        }
        else if (randomnumber.generatedNumber == 2)
        {
            gamemanager.MBassets2.SetActive(true);
        }
    }
}
