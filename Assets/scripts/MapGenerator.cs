using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Map;

public class MapGenerator : MonoBehaviour
{
    const float X_DIST = 2f;
    const float Y_DIST = 1f;
    const float PLACEMENT_RANDOMNESS = 0.4f;
    const int MAP_WIDTH = 7;
    const int PATHS = 6;

    [SerializeField] private int floors = 15;

    private Node[][] mapData;

    public void generateMap()
    {
        mapData = generateIntialGrid();
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
        int xPos = -500;
        int yPos = -300;


    }
}
