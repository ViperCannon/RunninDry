using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Hub : MonoBehaviour, IPointerDownHandler, IDataPersistence
{
    DataPersistenceManager dataManager;

    RelationshipsFramework relationshipframework;
    //add more objects as items get added
    public List<string> hubPurchases = new List<string>();


    void Start()
    {
        AddPhysics2DRaycaster();
        //may need to change GameManager to something else depending what holds the money variable
        dataManager = GameObject.Find("DataPersistenceManager").GetComponent<DataPersistenceManager>();
        relationshipframework = GameObject.Find("GameManager").GetComponent<RelationshipsFramework>();
        for (int i = 0; i < hubPurchases.Count; i++)
        {
            GameObject.Find(hubPurchases[i]).SetActive(false);
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        //do the if (this.gameobject.name == "bottles" && relationshipframework.cash >= bottleCost) 
    }

    public void purchasedUpgrade(string item)
    {
        //this is where any additional effects we want to have happen would happen
        hubPurchases.Add(item);
        dataManager.SaveGame();
    }

    public void LoadData(GameData data)
    {
        hubPurchases = data.hubPurchases;
    }

    public void SaveData(ref GameData data)
    {
        data.hubPurchases = hubPurchases;
    }

    private void AddPhysics2DRaycaster()
    {
        Physics2DRaycaster physicsRaycaster = FindObjectOfType<Physics2DRaycaster>();
        if (physicsRaycaster == null)
        {
            Camera.main.gameObject.AddComponent<Physics2DRaycaster>();
        }
    }

    void Update()
    {
        
    }
}
