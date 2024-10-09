using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Map;

public class MapGenerator : MonoBehaviour
{
    const float X_START = -200f;
    const float Y_START = -575f;
    const float X_DIST = 100f;
    const float Y_DIST = 100f;
    const float PLACEMENT_RANDOMNESS = 20f; //reccommend to keep between 10 and 30
    const int MAP_WIDTH = 5;
    const int PATHS = 5; 
    const int FLOORS = 12; //13th node is boss

    [SerializeField]
    GameObject[] nodeVariants;

    [SerializeField]
    GameObject content;

    [SerializeField]
    GameObject line;

    Node[][] mapData;
    Node start;
    Node boss;
    Node crew;

    public void generateMap()
    {
        clearMap();
        start = new Node();
        crew = start;
        mapData = generateInitialGrid();
        createPaths();
        displayMap();
    }

    private Node[][] generateInitialGrid()
    { 
        Node[][] tempData = new Node[FLOORS][];

        for(int i = 0; i < FLOORS; i++)
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
        for (int i = 0; i < PATHS; i++)
        {
            int x = Random.Range(0, MAP_WIDTH);

            while (mapData[0][x].GetNextNodes().Count >= 2)
            {
                x = Random.Range(0, MAP_WIDTH);
            }

            Node current = mapData[0][x];
            Node next = current;

            current.AddPrevNode(start);
            start.AddNextNode(current);

            if(current.GetNodeType() == NodeType.Blank)
            {
                if(Random.Range(0, 3) > 0)
                {
                    current.SetNodeType(NodeType.Negotiation);
                }
                else
                {
                    current.SetNodeType(NodeType.Combat);
                }
            }

            for (int j = 1; j < FLOORS; j++)
            {
                switch (x)
                {
                    case 0:
                             
                        if (mapData[j - 1][x + 1].GetNextNodes().Contains(mapData[j][x]))
                        {
                            break;
                        }

                        x += Random.Range(0, 2);

                        break;

                    case 4:
                        
                        if (mapData[j - 1][x - 1].GetNextNodes().Contains(mapData[j][x]))
                        {
                            break;
                        }
                        
                        x += Random.Range(-1, 1);

                        break;

                    default:
                        
                        if (mapData[j - 1][x + 1].GetNextNodes().Contains(mapData[j][x]) && mapData[j - 1][x - 1].GetNextNodes().Contains(mapData[j][x]))
                        {
                            break;
                        }
                        else if(mapData[j - 1][x + 1].GetNextNodes().Contains(mapData[j][x]))
                        {
                            x += Random.Range(-1, 1);
                        }
                        else if(mapData[j - 1][x - 1].GetNextNodes().Contains(mapData[j][x]))
                        {
                            x += Random.Range(0, 2);
                        }
                        else
                        {
                            x += Random.Range(-1, 2);
                        }

                        break;
                }

                next = mapData[j][x];

                current.AddNextNode(next);
                next.AddPrevNode(current);

                if(next.GetNodeType() == NodeType.Blank || next.GetNodeType() == current.GetNodeType())
                { 
                    bool repeat = true;

                    while (repeat)
                    {
                        int chance = Random.Range(0, 100);

                        switch (j)
                        {
                            case 1:

                                if (chance < 15)
                                {
                                    next.SetNodeType(NodeType.Combat);
                                }
                                else if (chance < 65)
                                {
                                    next.SetNodeType(NodeType.Negotiation);
                                }
                                else
                                {
                                    next.SetNodeType(NodeType.Event);
                                }

                                break;

                            case 2:
                            case 3:

                                if (chance < 20)
                                {
                                    next.SetNodeType(NodeType.Combat);
                                }
                                else if (chance < 65)
                                {
                                    next.SetNodeType(NodeType.Negotiation);
                                }
                                else if (chance < 85)
                                {
                                    next.SetNodeType(NodeType.Event);
                                }
                                else
                                {
                                    next.SetNodeType(NodeType.Shop);
                                }

                                break;

                            case 10:

                                if (chance < 17)
                                {
                                    next.SetNodeType(NodeType.Combat);
                                }
                                else if (chance < 44)
                                {
                                    next.SetNodeType(NodeType.Negotiation);
                                }
                                else if (chance < 56)
                                {
                                    next.SetNodeType(NodeType.Event);
                                }
                                else if (chance < 83)
                                {
                                    next.SetNodeType(NodeType.Miniboss);
                                }
                                else if (chance < 88)
                                {
                                    next.SetNodeType(NodeType.Mystery);
                                }
                                else
                                {
                                    next.SetNodeType(NodeType.Shop);
                                }

                                break;

                            case 11:

                                next.SetNodeType(NodeType.Pitstop);

                                break;

                            default:

                                if (chance < 15)
                                {
                                    next.SetNodeType(NodeType.Combat);
                                }
                                else if (chance < 40)
                                {
                                    next.SetNodeType(NodeType.Negotiation);
                                }
                                else if (chance < 50)
                                {
                                    next.SetNodeType(NodeType.Event);
                                }
                                else if (chance < 65)
                                {
                                    next.SetNodeType(NodeType.Miniboss);
                                }
                                else if (chance < 70)
                                {
                                    next.SetNodeType(NodeType.Mystery);
                                }
                                else if (chance < 80)
                                {
                                    next.SetNodeType(NodeType.Shop);
                                }
                                else
                                {
                                    next.SetNodeType(NodeType.Pitstop);
                                }

                                break;
                        }

                        repeat = false;

                        foreach (Node n in next.GetPrevNodes())
                        {
                            if (n.GetNodeType() == next.GetNodeType())
                            {
                                repeat = true;
                                break;
                            }
                        }

                        if (!repeat)
                        {
                            foreach (Node n in next.GetNextNodes())
                            {
                                if (n.GetNodeType() == next.GetNodeType())
                                {
                                    repeat = true;
                                    break;
                                }
                            }
                        }
                    }
                }

                current = next;
            }
        }

        removeNodes();
    }

    private void removeNodes()
    {
        for (int y = 0; y < FLOORS; y++)
        {
            for (int x = 0; x < MAP_WIDTH; x++)
            {
                if (mapData[y][x].GetNextNodes().Count == 0  && mapData[y][x].GetPrevNodes().Count == 0)
                {
                    mapData[y][x] = null;
                }
            }
        }
    }

    private void displayMap()
    {
        start.SetGameNode(Instantiate(nodeVariants[1], new Vector3(0f, -675f, 0f), Quaternion.identity));
        start.GetGameNode().transform.SetParent(content.transform, false);

        for (int y = 0; y < FLOORS; y++)
        {
            float yPos = Y_START + (Y_DIST * y);

            for (int x = 0; x < MAP_WIDTH; x++)
            {
                float xPos = X_START + (X_DIST * x);

                if(mapData[y][x] != null)
                {
                    GameObject node = nodeVariants[((int)mapData[y][x].GetNodeType())];
                    Vector3 coords = new Vector3(xPos + Random.Range(PLACEMENT_RANDOMNESS * -1f, PLACEMENT_RANDOMNESS), 
                        yPos + (Random.Range(PLACEMENT_RANDOMNESS * -1f, PLACEMENT_RANDOMNESS) / 2f));

                    mapData[y][x].SetGameNode(Instantiate(node, coords, Quaternion.identity));
                    mapData[y][x].GetGameNode().transform.SetParent(content.transform, false);

                    foreach(Node n in mapData[y][x].GetPrevNodes())
                    {
                        GameObject temp = Instantiate(line, coords, Quaternion.identity);
                        temp.transform.SetParent(content.transform, false);
                        temp.transform.SetAsFirstSibling();
                        Vector3 rotCoords = mapData[y][x].GetGameNode().transform.localPosition - n.GetGameNode().transform.localPosition;
                        float angle = 90f + Mathf.Atan2(rotCoords.y, rotCoords.x) * 180 / Mathf.PI;
                        temp.transform.rotation = Quaternion.Euler(0, 0, angle);
                        float height = Mathf.Sqrt((rotCoords.x * rotCoords.x) + (rotCoords.y * rotCoords.y));
                        temp.GetComponent<RectTransform>().sizeDelta = new Vector2(10, height);
                    }
                }
            }
        }

        crew.Activate();
        crew.Complete();
    }

    private void clearMap()
    {
        if(mapData != null)
        {
            start.Delete();

            for (int y = 0; y < FLOORS; y++)
            {
                for (int x = 0; x < MAP_WIDTH; x++)
                {
                    if (mapData[y][x] != null)
                    {
                        mapData[y][x].Delete();
                    }
                }
            }

            foreach (GameObject l in GameObject.FindGameObjectsWithTag("Line"))
            {
                GameObject.Destroy(l);
            }
        } 
    }

    public void selectNode(GameObject next)
    {
        next.GetComponentInChildren<Button>().enabled = false;

        foreach (Node n in crew.GetNextNodes())
        {
            if (n.GetGameNode() != next)
            {
                n.Deactivate();
            }
            else
            {
                crew = n;
            }
        }

        //go into encounter

        crew.Complete();
    }
}
