using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class upgrade : MonoBehaviour, IPointerDownHandler
{
    public int cost;

    relationshipframework relationshipframework;
    hub hub;

    // Start is called before the first frame update
    void Start()
    {
        relationshipframework = GameObject.Find("GameManager").GetComponent<relationshipframework>();
        hub = GameObject.Find("Canvas").GetComponent <hub>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (relationshipframework.cash >= cost)
        {
            relationshipframework.cash -= cost;
            hub.purchasedUpgrade(this.name);
            //add to a list of purchased upgrades to remember if this is destroyed
            Destroy(this.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
