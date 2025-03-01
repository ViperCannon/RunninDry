using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Upgrade : MonoBehaviour, IPointerDownHandler
{
    public int cost;
    public GameObject upgradedItem;
    RelationshipsFramework relationshipframework;
    Hub hub;

    // Start is called before the first frame update
    void Start()
    {
        relationshipframework = GameObject.Find("GameManager").GetComponent<RelationshipsFramework>();
        hub = GameObject.Find("Canvas").GetComponent <Hub>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("Click");
        if (relationshipframework.cash >= cost)
        {
            if (upgradedItem != null)
            {
                relationshipframework.cash -= cost;
                hub.purchasedUpgrade(this.name);
                //add to a list of purchased upgrades to remember if this is destroyed
                upgradedItem.SetActive(true);
                Destroy(this.gameObject);
            }
            else
            {
                Debug.Log("There's no upgrade for this item!");
            }
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
