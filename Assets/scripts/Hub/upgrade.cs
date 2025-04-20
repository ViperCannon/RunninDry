using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
//using static UnityEditor.Progress;

public class Upgrade : MonoBehaviour, IPointerDownHandler, IDataPersistence
{
    public int cost;
    public int initialCost;
    RelationshipsFramework relationshipframework;
    TMP_Text text;
    Hub hub;
    int upgradecount = 0;
    public int maxUpgrades;
    // Start is called before the first frame update
    void Start()
    {
        cost = initialCost * (1+upgradecount);
        updateCost();
        checkMaxUpgrades();
        if (upgradecount > 0 && this.name != "Wall")
        {
            GameObject.Find("Upgrades").transform.Find(this.name + upgradecount).gameObject.SetActive(true);
        }
        else if (upgradecount > 0 && this.name == "Wall")
        {
            GameObject.Find("WallUpgrades").transform.Find(this.name + upgradecount).gameObject.SetActive(true);
        }
    }

    void Awake()
    {
        relationshipframework = GameObject.Find("GameManager").GetComponent<RelationshipsFramework>();
        hub = GameObject.Find("Canvas").GetComponent<Hub>();
        text = this.gameObject.GetComponentInChildren<TMP_Text>();
    }

    public void updateCost()
    {
        text.text = this.name + " $" + cost;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("Click");
        if (relationshipframework.cash >= cost)
        {
            relationshipframework.cash -= cost;
            if (upgradecount > 0)
            {
                GameObject.Find("Upgrades").transform.Find(this.name + upgradecount).gameObject.SetActive(false);
            }
            hub.purchasedUpgrade(this.name, upgradecount);
            upgradecount++;
            hub.GameSave();
            //add to a list of purchased upgrades to remember if this is destroyed
            //Destroy(this.gameObject);
            if (this.name != "Wall")
            {
                GameObject.Find("Upgrades").transform.Find(this.name + upgradecount).gameObject.SetActive(true);
            }
            else if (this.name == "Wall")
            {
                GameObject.Find("WallUpgrades").transform.Find(this.name + upgradecount).gameObject.SetActive(true);
            }
                cost += initialCost;
            updateCost();
            checkMaxUpgrades();
        }
    }

    public void checkMaxUpgrades()
    {
        if (upgradecount >= maxUpgrades)
        {
            this.gameObject.SetActive(false);
        }
    }

    public void LoadData(GameData data)
    {
        switch (this.name)
        {
            case "Chairs":
                upgradecount = data.chairUpgrades;
                break;
            case "Comforts":
                upgradecount = data.comfortUpgrades;
                break;
            case "Bar":
                upgradecount = data.barUpgrades;
                break;
            case "Wall":
                upgradecount = data.wallUpgrades;
                break;
            case "Stock":
                upgradecount = data.stockUpgrades;
                break;
            case "Entertainment":
                upgradecount = data.entertainmentUpgrades;
                break;
            default:

                break;
        }
    }

    public void SaveData(ref GameData data)
    {
        switch (this.name)
        {
            case "Chairs":
                data.chairUpgrades = upgradecount;
                break;
            case "Comforts":
                data.comfortUpgrades = upgradecount;
                break;
            case "Bar":
                data.barUpgrades = upgradecount;
                break;
            case "Wall":
                data.wallUpgrades = upgradecount;
                break;
            case "Stock":
                data.stockUpgrades = upgradecount;
                break;
            case "Entertainment":
                data.entertainmentUpgrades = upgradecount;
                break;
            default:
                
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        /*relationshipframework = GameObject.Find("GameManager").GetComponent<RelationshipsFramework>();
        hub = GameObject.Find("Canvas").GetComponent<Hub>();
        text = this.gameObject.GetComponentInChildren<TMP_Text>();
        cost = initialCost * (1 + upgradecount);
        updateCost();
        checkMaxUpgrades();
        if (upgradecount > 0 && this.name != "Wall")
        {
            GameObject.Find("Upgrades").transform.Find(this.name + upgradecount).gameObject.SetActive(true);
        }*/
    }
}
