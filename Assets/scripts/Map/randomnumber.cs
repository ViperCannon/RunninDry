using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomNumber : MonoBehaviour
{
    public int generatedNumber;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void GenerateNumber()
    {
        generatedNumber = Random.Range(1, 6);
        print(generatedNumber);
    }

}
