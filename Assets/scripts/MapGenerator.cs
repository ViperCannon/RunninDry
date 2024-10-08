using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Map;

public class MapGenerator : MonoBehaviour
{
    const float X_DIST = 100f;
    const float Y_DIST = 100f;
    const float PLACEMENT_RANDOMNESS = 20f;
    const int MAP_WIDTH = 5;
    const int PATHS = 5;

    [SerializeField] 
    int floors = 15;

    [SerializeField]
    GameObject[] nodeVariants;

    [SerializeField]
    GameObject content;

    [SerializeField]
    GameObject line;

    Node[][] mapData;
    Node start;
    Node boss;

    public void generateMap()
    {
        clearMap();
        mapData = generateIntialGrid();
        createPaths();
        displayMap();
    }

    private Node[][] generateIntialGrid()
    {
        start = new Node();

        Node[][] tempData = new Node[floors - 1][];

        for(int i = 0; i < floors - 1; i++)
        {
            tempData[i] = new Node[MAP_WIDTH];

            for(int j = 0; j < MAP_WIDTH; j++)
            {
                tempData[i][j] = new Node();
            }
        }

        return tempData;
    }

    private void createPaths()
    {
        for(int i = 0; i < PATHS; i++)
        {
            int x = Random.Range(0, MAP_WIDTH);

            while (mapData[0][x].getNextNodes().Count >= 2)
            {
                x = Random.Range(0, MAP_WIDTH);
            }

            Node current = mapData[0][x];
            Node next = current;

            current.addPrevNode(start);
            start.addNextNode(current);

            for (int j = 1; j < floors - 1; j++)
            {
                switch (x)
                {
                    case 0:
                        if (mapData[j - 1][x + 1].getNextNodes().Contains(mapData[j][x]))
                        {
                            break;
                        }

                        x = x + Random.Range(0, 2);

                        break;

                    case 4:
                        if (mapData[j - 1][x - 1].getNextNodes().Contains(mapData[j][x]))
                        {
                            break;
                        }
                        
                        x = x + Random.Range(-1, 1);

                        break;

                    default:
                        if (mapData[j - 1][x + 1].getNextNodes().Contains(mapData[j][x]) && mapData[j - 1][x - 1].getNextNodes().Contains(mapData[j][x]))
                        {
                            break;
                        }
                        else if(mapData[j - 1][x + 1].getNextNodes().Contains(mapData[j][x]))
                        {
                            x = x + Random.Range(-1, 1);
                        }
                        else if(mapData[j - 1][x - 1].getNextNodes().Contains(mapData[j][x]))
                        {
                            x = x + Random.Range(0, 2);
                        }
                        else
                        {
                            x = x + Random.Range(-1, 2);
                        }

                        break;
                }

                next = mapData[j][x];

                current.addNextNode(next);
                next.addPrevNode(current);

                current = next;
            }
        }

        removeNodes();
    }

    private void removeNodes()
    {
        for (int y = 0; y < floors - 1; y++)
        {
            for (int x = 0; x < MAP_WIDTH; x++)
            {
                if (mapData[y][x].getNextNodes().Count == 0  && mapData[y][x].getPrevNodes().Count == 0)
                {
                    mapData[y][x] = null;
                }
            }
        }
    }

    private void displayMap()
    {
        start.setGameNode(Instantiate(nodeVariants[1], new Vector3(0f, -775f, 0f), Quaternion.identity));
        start.getGameNode().transform.SetParent(content.transform, false);

        for (int y = 0; y < floors - 1; y++)
        {
            float yPos = -675 + (100 * y); //(+ 100y)

            for (int x = 0; x < MAP_WIDTH; x++)
            {
                float xPos = -200 + (100 * x); //(+ 100x)

                if(mapData[y][x] != null)
                {
                    GameObject node = nodeVariants[((int)mapData[y][x].getNodeType())];
                    Vector3 coords = new Vector3(xPos + Random.Range(PLACEMENT_RANDOMNESS * -1f, PLACEMENT_RANDOMNESS), yPos + Random.Range(PLACEMENT_RANDOMNESS * -1f, PLACEMENT_RANDOMNESS));

                    mapData[y][x].setGameNode(Instantiate(node, coords, Quaternion.identity));
                    mapData[y][x].getGameNode().transform.SetParent(content.transform, false);

                    foreach(Node n in mapData[y][x].getPrevNodes())
                    {
                        GameObject temp = Instantiate(line, coords, Quaternion.identity);
                        temp.transform.SetParent(content.transform, false);
                        temp.transform.SetAsFirstSibling();
                        Vector3 rotCoords = mapData[y][x].getGameNode().transform.localPosition - n.getGameNode().transform.localPosition;
                        float angle = 90f + Mathf.Atan2(rotCoords.y, rotCoords.x) * 180 / Mathf.PI;
                        temp.transform.rotation = Quaternion.Euler(0, 0, angle);
                        float height = Mathf.Sqrt((rotCoords.x * rotCoords.x) + (rotCoords.y * rotCoords.y));
                        temp.GetComponent<RectTransform>().sizeDelta = new Vector2(10, height);
                    }
                }
            }
        }
    }

    private void clearMap()
    {
        if(mapData != null)
        {
            start.delete();

            for (int y = 0; y < floors - 1; y++)
            {
                for (int x = 0; x < MAP_WIDTH; x++)
                {
                    if (mapData[y][x] != null)
                    {
                        mapData[y][x].delete();
                    }
                }
            }

            foreach (GameObject l in GameObject.FindGameObjectsWithTag("Line"))
            {
                GameObject.Destroy(l);
            }
        } 
    }
}
