using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonCooldown : MonoBehaviour
{
    bool cooldown = false;
    
    [SerializeField]
    GameObject map;

    public void ButtonFunction()
    {
        if (!cooldown)
        {
            map.GetComponent<MapGenerator>().GenerateMap();
            cooldown = true;
            Invoke("ResetCooldown", 3.5f);
        }
    }

    // Update is called once per frame
    void ResetCooldown()
    {
        cooldown = false;
    }
}
