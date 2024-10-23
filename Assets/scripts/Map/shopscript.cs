using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shopscript : MonoBehaviour
{
    randomnumber randomnumber;
    GameManager gamemanager;
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
        if (randomnumber.generatedNumber == 1)
        {
            gamemanager.Sassets1.SetActive(true);
        }
        else if (randomnumber.generatedNumber == 2)
        {
            gamemanager.Sassets2.SetActive(true);
        }
    }
}
