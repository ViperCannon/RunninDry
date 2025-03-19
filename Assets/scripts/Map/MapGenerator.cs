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
    Node crew;

    public static bool tutorial = false;

    private void Start()
    {
        if (!tutorial)
        {
            GenerateMap();
        }
        else
        {
            GenerateTutorial();
        }
    }

    public void GenerateMap()
    {
        ClearMap();
        start = new Node();
        crew = start;
        mapData = GenerateInitialGrid();
        CreatePaths();
        DisplayMap();
    }

    public void GenerateTutorial()
    {
        ClearMap();
        start = new Node();
        crew = start;
        mapData = GenerateTutorialGrid();
        CreateTutorial();
        DisplayMap();
    }

    private Node[][] GenerateInitialGrid()
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

    private Node[][] GenerateTutorialGrid()
    {
        Node[][] tempData = new Node[FLOORS][];

        for (int i = 0; i < FLOORS; i++)
        {
            tempData[i] = new Node[MAP_WIDTH];

            for (int j = 0; j < MAP_WIDTH; j++)
            {
                if (j == 2)
                {
                    tempData[i][j] = new Node();
                }
                else
                {
                    tempData[i][j] = null;
                }
            }
        }

        return tempData;
    }

    private void CreatePaths()
    {
        for (int i = 0; i < PATHS; i++)
        {
            int x = Random.Range(0, MAP_WIDTH);

            while (mapData[0][x].GetNextNodes().Count >= 2)
            {
                x++;

                if(x == MAP_WIDTH)
                {
                    x = 0;
                }
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
                            int temp = Random.Range(-1, 2);
                            int tries = 0;

                            while (mapData[j][x + temp].GetPrevNodes().Count >= 2 && tries < 3)
                            {
                                temp++;

                                if(temp == 2)
                                {
                                    temp = -1;
                                }

                                tries++;
                            }

                            x += temp;
                        }

                        break;
                }

                next = mapData[j][x];

                current.AddNextNode(next);
                next.AddPrevNode(current);

                if(next.GetNodeType() == NodeType.Blank || next.GetNodeType() == current.GetNodeType())
                {
                    AssignNodeType(next, j);
                }

                current = next;
            }
        }

        RemoveNodes();
    }

    private void CreateTutorial()
    {
        for (int i = 0; i < FLOORS; i++)
        {
            switch (i)
            {
                case 0:
                    mapData[i][2].AddPrevNode(start);
                    start.AddNextNode(mapData[i][2]);

                    mapData[i][2].SetNodeType(NodeType.Negotiation);


                    break;

                case 1:
                case 8:
                case 10:

                    mapData[i][2].AddPrevNode(mapData[i - 1][2]);
                    mapData[i - 1][2].AddNextNode(mapData[i][2]);

                    mapData[i][2].SetNodeType(NodeType.Negotiation);

                    break;
                
                case 2:
                case 4:

                    mapData[i][2].AddPrevNode(mapData[i - 1][2]);
                    mapData[i - 1][2].AddNextNode(mapData[i][2]);

                    mapData[i][2].SetNodeType(NodeType.Combat);

                    break;

                case 3:

                    mapData[i][2].AddPrevNode(mapData[i - 1][2]);
                    mapData[i - 1][2].AddNextNode(mapData[i][2]);

                    mapData[i][2].SetNodeType(NodeType.Blank);

                    break;

                case 5:
                case 11:

                    mapData[i][2].AddPrevNode(mapData[i - 1][2]);
                    mapData[i - 1][2].AddNextNode(mapData[i][2]);

                    mapData[i][2].SetNodeType(NodeType.Pitstop);

                    break;

                case 6:

                    mapData[i][2].AddPrevNode(mapData[i - 1][2]);
                    mapData[i - 1][2].AddNextNode(mapData[i][2]);

                    mapData[i][2].SetNodeType(NodeType.Event);

                    break;

                case 7:

                    mapData[i][2].AddPrevNode(mapData[i - 1][2]);
                    mapData[i - 1][2].AddNextNode(mapData[i][2]);

                    mapData[i][2].SetNodeType(NodeType.Shop);

                    break;

                case 9:

                    mapData[i][2].AddPrevNode(mapData[i - 1][2]);
                    mapData[i - 1][2].AddNextNode(mapData[i][2]);

                    mapData[i][2].SetNodeType(NodeType.Mystery);

                    break;
            }
        }
    }

    private void AssignNodeType(Node node, int height)
    {
        bool repeat = true;

        while (repeat)
        {
            int chance = Random.Range(0, 100);

            switch (height)
            {
                case 1:

                    if (chance < 15)
                    {
                        node.SetNodeType(NodeType.Combat);
                    }
                    else if (chance < 65)
                    {
                        node.SetNodeType(NodeType.Negotiation);
                    }
                    else
                    {
                        node.SetNodeType(NodeType.Event);
                    }

                    break;

                case 2:
                case 3:

                    if (chance < 20)
                    {
                        node.SetNodeType(NodeType.Combat);
                    }
                    else if (chance < 65)
                    {
                        node.SetNodeType(NodeType.Negotiation);
                    }
                    else if (chance < 85)
                    {
                        node.SetNodeType(NodeType.Event);
                    }
                    else
                    {
                        node.SetNodeType(NodeType.Shop);
                    }

                    break;

                case 10:

                    if (chance < 17)
                    {
                        node.SetNodeType(NodeType.Combat);
                    }
                    else if (chance < 44)
                    {
                        node.SetNodeType(NodeType.Negotiation);
                    }
                    else if (chance < 56)
                    {
                        node.SetNodeType(NodeType.Event);
                    }
                    else if (chance < 83)
                    {
                        node.SetNodeType(NodeType.Miniboss);
                    }
                    else if (chance < 88)
                    {
                        node.SetNodeType(NodeType.Mystery);
                    }
                    else
                    {
                        node.SetNodeType(NodeType.Shop);
                    }

                    break;

                case 11:

                    node.SetNodeType(NodeType.Pitstop);

                    break;

                default:

                    if (chance < 15)
                    {
                        node.SetNodeType(NodeType.Combat);
                    }
                    else if (chance < 40)
                    {
                        node.SetNodeType(NodeType.Negotiation);
                    }
                    else if (chance < 50)
                    {
                        node.SetNodeType(NodeType.Event);
                    }
                    else if (chance < 65)
                    {
                        node.SetNodeType(NodeType.Miniboss);
                    }
                    else if (chance < 70)
                    {
                        node.SetNodeType(NodeType.Mystery);
                    }
                    else if (chance < 80)
                    {
                        node.SetNodeType(NodeType.Shop);
                    }
                    else
                    {
                        node.SetNodeType(NodeType.Pitstop);
                    }

                    break;
            }

            repeat = false;

            if(height == 11 || node.GetNodeType() == NodeType.Combat || node.GetNodeType() == NodeType.Negotiation)
            {
                break;
            }

            foreach (Node p in node.GetPrevNodes())
            {
                if (p.GetNodeType() == node.GetNodeType())
                {
                    repeat = true;
                    break;
                }
            }

            if (!repeat)
            {
                foreach (Node n in node.GetNextNodes())
                {
                    if (n.GetNodeType() == node.GetNodeType())
                    {
                        repeat = true;
                        break;
                    }
                }
            }
        }
    }

    private void RemoveNodes()
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

    private void DisplayMap()
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
                        temp.transform.SetSiblingIndex(1);
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

    private void ClearMap()
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

    public void SelectNode(GameObject next)
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
                //gameManager.GetComponent<MusicController>().UpdateMusic(n.GetNodeType().ToString());
            }
        }

        //go into encounter
        switch (crew.GetNodeType())
        {
            case NodeType.Combat:
                EncounterGenerator.GetInstance().SetNewCombatDialogue();
                break;

            case NodeType.Negotiation:
                EncounterGenerator.GetInstance().SetNewNegotiationDialogue();
                break;

            case NodeType.Event:
                EncounterGenerator.GetInstance().SetNewEventDialogue();
                break;

            case NodeType.Pitstop:
                EncounterGenerator.GetInstance().SetNewPitStopDialogue();
                break;

            case NodeType.Shop:
                EncounterGenerator.GetInstance().SetNewShopDialogue();
                break;

            case NodeType.Miniboss:
                EncounterGenerator.GetInstance().SetNewEliteDialogue();
                break;

            case NodeType.Boss:
                EncounterGenerator.GetInstance().SetNewBossDialogue();
                break;

            default:
                EncounterGenerator.GetInstance().SetBlankDialogue();
                Debug.Log("This Node Type doesn't have implemented functionality yet!");
                break;
        }

        crew.Complete();
    }
}
