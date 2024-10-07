using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Map;

public class MapGenerator : MonoBehaviour
{
    const float X_DIST = 100f;
    const float Y_DIST = 100f;
    const float PLACEMENT_RANDOMNESS = 25f;
    const int MAP_WIDTH = 5;
    const int PATHS = 6;

    [SerializeField] 
    private int floors = 15;

    [SerializeField]
    private GameObject[] nodeVariants;

    [SerializeField]
    private GameObject content;

    private Node[][] mapData;

    private void Start()
    {
        generateMap();
    }

    public void generateMap()
    {
        mapData = generateIntialGrid();
        displayMap();
    }

    private Node[][] generateIntialGrid()
    {
        Node[][] tempData = new Node[floors][];

        for(int i = 0; i < floors; i++)
        {
            tempData[i] = new Node[MAP_WIDTH];

            for(int j = 0; j < MAP_WIDTH; j++)
            {
                tempData[i][j] = new Node(i + 1);
            }
        }

        return tempData;
    }

    private void displayMap()
    {
         
        

        for(int y = 0; y < floors; y++)
        {
            float yPos = -675 + (100 * y); //(+ 100y)

            for (int x = 0; x < MAP_WIDTH; x++)
            {
                float xPos = -200 + (100 * x); //(+ 100x)

                GameObject node = nodeVariants[((int)mapData[y][x].getNodeType())];
                Vector3 coords = new Vector3(xPos + Random.Range(PLACEMENT_RANDOMNESS * -1f, PLACEMENT_RANDOMNESS), yPos + Random.Range(PLACEMENT_RANDOMNESS * -1f, PLACEMENT_RANDOMNESS));
                Debug.Log(coords);
                GameObject temp = Instantiate(node, content.transform);
                temp.transform.localPosition = coords;
            }


        }
    }
}
