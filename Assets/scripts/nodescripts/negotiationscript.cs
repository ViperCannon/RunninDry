using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class negotiationscript : MonoBehaviour
{
    randomnumber randomnumber;
    GameManager gamemanager;
    [SerializeField]
    GameObject assets1;
    [SerializeField]
    GameObject assets2;

    // Start is called before the first frame update
    void Start()
    {
        randomnumber = this.gameObject.GetComponent<randomnumber>();
        gamemanager = GameObject.Find("GameManager").GetComponent<GameManager>();
        //GrabAssets();
        if (assets1 != null && assets2 != null)
        {
           // assets1.gameObject.SetActive(false);
           // assets2.gameObject.SetActive(false);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GrabAssets()
    {
        if (GameObject.Find("N1") != null && GameObject.Find("N2") != null)
        {
            assets1 = GameObject.Find("N1");
            assets2 = GameObject.Find("N2");
        }
    }
    public void loadAssets()
    {
        if (randomnumber.generatedNumber == 1)
        {
            gamemanager.Nassets1.SetActive(true);
        }
        else if (randomnumber.generatedNumber == 2) 
        {
            gamemanager.Nassets2.SetActive(true);
        }
    }
}
