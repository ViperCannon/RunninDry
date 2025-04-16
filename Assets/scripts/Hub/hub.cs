using System.Collections;
using System.Collections.Generic;
using TMPro;
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

    int chairUpgrades;
    int comfortUpgrades;
    int barUpgrades;
    int wallUpgrades;
    int stockUpgrades;

    int barMoney;

    public int tax;
    int wallupgrade;

    public TMP_Text taxes;

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
        //tax math here if needed
        taxes.text = "You paid $" + tax + " in taxes. Don't forget.";
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
        relationshipframework.booze = 0;
        if (relationshipframework.inRun)
        {
            relationshipframework.cash -= tax;
            relationshipframework.inRun = false;
        }
        else
        {
            GameObject.Find("tax").SetActive(false);
        }

        if (relationshipframework.cash <= 0)
        {
            SceneManager.LoadScene("losescreen");
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        //do the if (this.gameobject.name == "bottles" && relationshipframework.cash >= bottleCost) 
    }

    public void purchasedUpgrade(string item, int upgradecount)
    {
        //this is where any additional effects we want to have happen would happen
        //hubPurchases.Add(item);
        //dataManager.SaveGame();
        if (item == "Wall")
        {
            wall1.SetActive(true);
        }


        switch (item)
        {
            case "Chairs":
                chairUpgrades++;
                break;
            case "Comforts":
                comfortUpgrades++;
                break;
            case "Bar":
                barUpgrades++;
                barMoney += (barMoney + (15 * upgradecount));
                break;
            case "Wall":
                
                break;
            case "Stock":
                stockUpgrades++;
                break;
            case "Entertainment":
                relationshipframework.copRelations += (5 * (1 + upgradecount));
                relationshipframework.russianMobRelations += (5 * (1 + upgradecount));
                relationshipframework.norwegianMobRelations += (5 * (1 + upgradecount));
                relationshipframework.prohibitionistsRelations += (5 * (1 + upgradecount));
                relationshipframework.drunkardRelations += (5 * (1 + upgradecount));
                relationshipframework.civilianRelations += (5 * (1 + upgradecount));
                break;
            default:
                Debug.Log(item);
                break;
        }
    }

    public void LoadData(GameData data)
    {
        wallupgrade = data.wallUpgrades;

        chairUpgrades = data.chairUpgrades;
        comfortUpgrades = data.comfortUpgrades;
        barUpgrades = data.barUpgrades;
        stockUpgrades = data.stockUpgrades;
        barMoney = data.barMoney;
        //hubPurchases = data.hubPurchases;
    }

    public void SaveData(ref GameData data)
    {
        //data.hubPurchases = hubPurchases;
        data.barMoney = barMoney;
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
        relationshipframework.cash += barMoney;
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
