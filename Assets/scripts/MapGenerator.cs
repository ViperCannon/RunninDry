using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Map;

public class MapGenerator : MonoBehaviour
{
    const int X_DIST = 30;
    const int Y_DIST = 25;
    const int PLACEMENT_RANDOMNESS = 5;
    const int MAP_WIDTH = 7;
    const int PATHS = 6;

    [SerializeField] private int floors = 15;

    private Node[][] mapData;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
