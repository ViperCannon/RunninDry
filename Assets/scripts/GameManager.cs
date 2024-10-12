using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    Animator overworld;
    Animator car;

    // Start is called before the first frame update
    void Start()
    {
        overworld = GameObject.FindWithTag("Map").GetComponent<Animator>();
        car = GameObject.FindWithTag("car").gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void endEncounter()
    {
        StartCoroutine(endingEncounter());
    }

    IEnumerator endingEncounter()
    {
        overworld.SetTrigger("fadein");
        car.SetTrigger("start");
        yield return null;
    }
}
