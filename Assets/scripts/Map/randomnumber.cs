using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomnumber : MonoBehaviour
{
    public int generatedNumber;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void generateNumber()
    {
        generatedNumber = Random.Range(1, 6);
        print(generatedNumber);
    }

}
