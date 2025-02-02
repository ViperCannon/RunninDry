using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinibossScript : MonoBehaviour
{
    RandomNumber randomNumber;
    GameManager gamemanager;
    // Start is called before the first frame update
    void Start()
    {
        randomNumber = this.gameObject.GetComponent<RandomNumber>();
        gamemanager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    public void LoadAssets()
    {
        if (randomNumber.generatedNumber == 1)
        {
            gamemanager.MBassets1.SetActive(true);
        }
        else if (randomNumber.generatedNumber == 2)
        {
            gamemanager.MBassets2.SetActive(true);
        }
    }
}
