using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialMinibossScript : MonoBehaviour
{
    GameManager gamemanager;
    // Start is called before the first frame update
    void Start()
    {
        gamemanager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    /*public void loadAssets()
    {
        if (RandomNumber.generatedNumber == 1)
        {
            gamemanager.MBassets1.SetActive(true);
        }
        else if (RandomNumber.generatedNumber == 2)
        {
            gamemanager.MBassets2.SetActive(true);
        }
    }*/
}
