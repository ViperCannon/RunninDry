using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Hub : MonoBehaviour, IPointerDownHandler, IDataPersistence
{
    DataPersistenceManager dataManager;

    RelationshipsFramework relationshipframework;
    //add more objects as items get added
    public List<string> hubPurchases = new List<string>();
    public GameObject chairs1;
    public GameObject rug1;
    public GameObject bar1;
    public GameObject wall1;
    public GameObject stock1;

    public GameObject upgradeBoxes;
    bool hideBoxes = false;

    int wallupgrade;

    Ray ray;
    RaycastHit hit;
    

    void Start()
    {
        AddPhysics2DRaycaster();
        //may need to change GameManager to something else depending what holds the money variable
        dataManager = GameObject.Find("DataPersistenceManager").GetComponent<DataPersistenceManager>();
        relationshipframework = GameObject.Find("GameManager").GetComponent<RelationshipsFramework>();
        if (wallupgrade > 0)
        {
            wall1.SetActive(true);
        }
        /*for (int i = 0; i < hubPurchases.Count; i++)
        {
            GameObject.Find(hubPurchases[i]).SetActive(false);

            switch (hubPurchases[i]+"1")
            {
                case "Chairs1":
                    chairs1.SetActive(true);
                    break;
                case "Comforts1":
                    rug1.SetActive(true);
                    break;
                case "Bar1":
                    bar1.SetActive(true);
                    break;
                case "Wall1":
                    wall1.SetActive(true);
                    break;
                case "Stock1":
                    stock1.SetActive(true);
                    break;
                default:
                    Debug.Log(hubPurchases[i]+"1");
                    break;
            }
        }*/
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        //do the if (this.gameobject.name == "bottles" && relationshipframework.cash >= bottleCost) 
    }

    public void purchasedUpgrade(string item)
    {
        //this is where any additional effects we want to have happen would happen
        //hubPurchases.Add(item);
        //dataManager.SaveGame();
        if (item == "Wall")
        {
            wall1.SetActive(true);
        }


        /*switch (item)
        {
            case "Chairs":
                chairs1.SetActive(true);
                break;
            case "Comforts":
                rug1.SetActive(true);
                break;
            case "Bar":
                bar1.SetActive(true);
                break;
            case "Wall":
                wall1.SetActive(true);
                break;
            case "Stock":
                stock1.SetActive(true);
                break;
            default:
                Debug.Log(item);
                break;
        }*/
    }

    public void LoadData(GameData data)
    {
        wallupgrade = data.wallUpgrades;
        //hubPurchases = data.hubPurchases;
    }

    public void SaveData(ref GameData data)
    {
        //data.hubPurchases = hubPurchases;
    }

    private void AddPhysics2DRaycaster()
    {
        Physics2DRaycaster physicsRaycaster = FindObjectOfType<Physics2DRaycaster>();
        if (physicsRaycaster == null)
        {
            Camera.main.gameObject.AddComponent<Physics2DRaycaster>();
        }
    }

    public void GameSave()
    {
        GameObject.Find("DataPersistenceManager").GetComponent<DataPersistenceManager>().SaveGame();
    }

    public void continuebutton()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        GameSave();
        SceneManager.LoadScene(2);
    }

    public void hideboxes()
    {
        if (!hideBoxes)
        {
            upgradeBoxes.SetActive(false);
            hideBoxes = true;
        }
        else if (hideBoxes)
        {
            upgradeBoxes.SetActive(true);
            hideBoxes = false;
        }
    }

    void Update()
    {
        /*ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray, out hit))
        {
            print (hit.collider.name);
        }*/
    }
}
