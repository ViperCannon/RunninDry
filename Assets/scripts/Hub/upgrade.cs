using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class Upgrade : MonoBehaviour, IPointerDownHandler
{
    public int cost;
    RelationshipsFramework relationshipframework;
    TMP_Text text;
    Hub hub;

    // Start is called before the first frame update
    void Start()
    {
        relationshipframework = GameObject.Find("GameManager").GetComponent<RelationshipsFramework>();
        hub = GameObject.Find("Canvas").GetComponent<Hub>();
        text = this.gameObject.GetComponentInChildren<TMP_Text>();
        text.text = this.name + " $"+cost;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("Click");
        if (relationshipframework.cash >= cost)
        {
            relationshipframework.cash -= cost;
            hub.purchasedUpgrade(this.name);
            //add to a list of purchased upgrades to remember if this is destroyed
            Destroy(this.gameObject);
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
