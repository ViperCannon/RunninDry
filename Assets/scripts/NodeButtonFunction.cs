using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NodeButtonFunction : MonoBehaviour
{
    GameObject mapGenerator;

    // Start is called before the first frame update
    void Start()
    {
        mapGenerator = GameObject.FindWithTag("Map");
    }

    public void click()
    {
        mapGenerator.GetComponent<MapGenerator>().selectNode(this.gameObject);
    }
}
