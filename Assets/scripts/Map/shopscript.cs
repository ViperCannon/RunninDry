using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopScript : MonoBehaviour
{
    RandomNumber randomNumber;
    GameManager gamemanager;
    // Start is called before the first frame update
    void Start()
    {
        randomNumber = this.gameObject.GetComponent<RandomNumber>();
        gamemanager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    public void loadAssets()
    {
        if (randomNumber.generatedNumber == 1)
        {
            gamemanager.Sassets1.SetActive(true);
        }
        else if (randomNumber.generatedNumber == 2)
        {
            gamemanager.Sassets2.SetActive(true);
        }
    }
}
