using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class negotiationscript : MonoBehaviour
{
    randomnumber randomnumber;
    GameObject assets1;
    GameObject assets2;

    // Start is called before the first frame update
    void Start()
    {
        randomnumber = this.gameObject.GetComponent<randomnumber>();
        assets1 = GameObject.Find("Negotiation1");
        assets2 = GameObject.Find("Negotiation2");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void loadAssets()
    {
        if (randomnumber.generatedNumber == 1)
        {
            assets1.SetActive(true);
        }
        else if (randomnumber.generatedNumber == 2) 
        { 
            assets2.SetActive(true); 
        }
    }
}
