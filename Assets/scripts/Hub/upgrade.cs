using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using static UnityEditor.Progress;

public class Upgrade : MonoBehaviour, IPointerDownHandler, IDataPersistence
{
    public int cost;
    RelationshipsFramework relationshipframework;
    TMP_Text text;
    Hub hub;
    int upgradecount = 0;
    // Start is called before the first frame update
    void Start()
    {
        relationshipframework = GameObject.Find("GameManager").GetComponent<RelationshipsFramework>();
        hub = GameObject.Find("Canvas").GetComponent<Hub>();
        text = this.gameObject.GetComponentInChildren<TMP_Text>();
        cost = cost * (1 + upgradecount);
        updateCost();
        if (upgradecount > 0)
        {
            GameObject.Find("Upgrades").transform.Find(this.name + upgradecount).gameObject.SetActive(true);
        }
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
            upgradecount++;
            hub.GameSave();
            //hub.purchasedUpgrade(this.name);
            //add to a list of purchased upgrades to remember if this is destroyed
            //Destroy(this.gameObject);
            GameObject.Find("Upgrades").transform.Find(this.name + upgradecount).gameObject.SetActive(true);
            cost = cost * (1 + upgradecount);
            updateCost();
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
            default:
                
                break;
        }
    }

    public void OnMouseOver()
    {
        Debug.Log(this.name);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
