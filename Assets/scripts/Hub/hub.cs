using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class hub : MonoBehaviour, IPointerDownHandler
{
    

    relationshipframework relationshipframework;
    //add more objects as items get added

    void Start()
    {
        AddPhysics2DRaycaster();
        //may need to change GameManager to something else depending what holds the money variable
        relationshipframework = GameObject.Find("GameManager").GetComponent<relationshipframework>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        //do the if (this.gameobject.name == "bottles" && relationshipframework.cash >= bottleCost) 
    }

    public void purchasedUpgrade(string item)
    {
        //this is where any additional effects we want to have happen would happen
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
