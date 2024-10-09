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

            while (mapData[0][x].getNextNodes().Count >= 2)
            {
                x = Random.Range(0, MAP_WIDTH);
            }

            Node current = mapData[0][x];
            Node next = current;

            current.addPrevNode(start);
            start.addNextNode(current);

            if(current.getNodeType() == NodeType.Blank)
            {
                if(Random.Range(0, 3) > 0)
                {
                    current.setNodeType(NodeType.Negotiation);
                }
                else
                {
                    current.setNodeType(NodeType.Combat);
                }
            }

            for (int j = 1; j < FLOORS; j++)
            {
                switch (x)
                {
                    case 0:
                             
                        if (mapData[j - 1][x + 1].getNextNodes().Contains(mapData[j][x]))
                        {
                            break;
                        }

                        x += Random.Range(0, 2);

                        break;

                    case 4:
                        
                        if (mapData[j - 1][x - 1].getNextNodes().Contains(mapData[j][x]))
                        {
                            break;
                        }
                        
                        x += Random.Range(-1, 1);

                        break;

                    default:
                        
                        if (mapData[j - 1][x + 1].getNextNodes().Contains(mapData[j][x]) && mapData[j - 1][x - 1].getNextNodes().Contains(mapData[j][x]))
                        {
                            break;
                        }
                        else if(mapData[j - 1][x + 1].getNextNodes().Contains(mapData[j][x]))
                        {
                            x += Random.Range(-1, 1);
                        }
                        else if(mapData[j - 1][x - 1].getNextNodes().Contains(mapData[j][x]))
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

                current.addNextNode(next);
                next.addPrevNode(current);

                if(next.getNodeType() == NodeType.Blank || next.getNodeType() == current.getNodeType())
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
                                    next.setNodeType(NodeType.Combat);
                                }
                                else if (chance < 65)
                                {
                                    next.setNodeType(NodeType.Negotiation);
                                }
                                else
                                {
                                    next.setNodeType(NodeType.Event);
                                }

                                break;

                            case 2:
                            case 3:

                                if (chance < 20)
                                {
                                    next.setNodeType(NodeType.Combat);
                                }
                                else if (chance < 65)
                                {
                                    next.setNodeType(NodeType.Negotiation);
                                }
                                else if (chance < 85)
                                {
                                    next.setNodeType(NodeType.Event);
                                }
                                else
                                {
                                    next.setNodeType(NodeType.Shop);
                                }

                                break;

                            case 10:

                                if (chance < 17)
                                {
                                    next.setNodeType(NodeType.Combat);
                                }
                                else if (chance < 44)
                                {
                                    next.setNodeType(NodeType.Negotiation);
                                }
                                else if (chance < 56)
                                {
                                    next.setNodeType(NodeType.Event);
                                }
                                else if (chance < 83)
                                {
                                    next.setNodeType(NodeType.Miniboss);
                                }
                                else if (chance < 88)
                                {
                                    next.setNodeType(NodeType.Mystery);
                                }
                                else
                                {
                                    next.setNodeType(NodeType.Shop);
                                }

                                break;

                            case 11:

                                next.setNodeType(NodeType.Pitstop);

                                break;

                            default:

                                if (chance < 15)
                                {
                                    next.setNodeType(NodeType.Combat);
                                }
                                else if (chance < 40)
                                {
                                    next.setNodeType(NodeType.Negotiation);
                                }
                                else if (chance < 50)
                                {
                                    next.setNodeType(NodeType.Event);
                                }
                                else if (chance < 65)
                                {
                                    next.setNodeType(NodeType.Miniboss);
                                }
                                else if (chance < 70)
                                {
                                    next.setNodeType(NodeType.Mystery);
                                }
                                else if (chance < 80)
                                {
                                    next.setNodeType(NodeType.Shop);
                                }
                                else
                                {
                                    next.setNodeType(NodeType.Pitstop);
                                }

                                break;
                        }

                        repeat = false;

                        foreach (Node n in next.getPrevNodes())
                        {
                            if (n.getNodeType() == next.getNodeType())
                            {
                                repeat = true;
                                break;
                            }
                        }

                        if (!repeat)
                        {
                            foreach (Node n in next.getNextNodes())
                            {
                                if (n.getNodeType() == next.getNodeType())
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
                if (mapData[y][x].getNextNodes().Count == 0  && mapData[y][x].getPrevNodes().Count == 0)
                {
                    mapData[y][x] = null;
                }
            }
        }
    }

    private void displayMap()
    {
        start.setGameNode(Instantiate(nodeVariants[1], new Vector3(0f, -675f, 0f), Quaternion.identity));
        start.getGameNode().transform.SetParent(content.transform, false);

        for (int y = 0; y < FLOORS; y++)
        {
            float yPos = Y_START + (Y_DIST * y);

            for (int x = 0; x < MAP_WIDTH; x++)
            {
                float xPos = X_START + (X_DIST * x);

                if(mapData[y][x] != null)
                {
                    GameObject node = nodeVariants[((int)mapData[y][x].getNodeType())];
                    Vector3 coords = new Vector3(xPos + Random.Range(PLACEMENT_RANDOMNESS * -1f, PLACEMENT_RANDOMNESS), 
                        yPos + (Random.Range(PLACEMENT_RANDOMNESS * -1f, PLACEMENT_RANDOMNESS) / 2f));

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

        crew.activate();
        crew.complete();
    }

    private void clearMap()
    {
        if(mapData != null)
        {
            start.delete();

            for (int y = 0; y < FLOORS; y++)
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

    public void selectNode(GameObject next)
    {
        next.GetComponentInChildren<Button>().enabled = false;

        foreach (Node n in crew.getNextNodes())
        {
            if (n.getGameNode() != next)
            {
                n.deactivate();
            }
            else
            {
                crew = n;
            }
        }

        //go into encounter

        crew.complete();
    }
}
