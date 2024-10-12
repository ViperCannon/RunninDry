using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    Animator map;
    Animator carParent;

    // Start is called before the first frame update
    void Start()
    {
        map = GameObject.FindWithTag("Map").GetComponent<Animator>();
        carParent = GameObject.FindWithTag("car").gameObject.GetComponent<Animator>();
        carParent.SetTrigger("stop");
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
        map.SetTrigger("fadein");
        carParent.SetTrigger("start");
        yield return null;
    }
}
