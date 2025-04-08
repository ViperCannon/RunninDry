using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossNodeButtonFunction : MonoBehaviour
{
    ScrollingBackground bg;

    void Start()
    {
        bg = GameObject.FindWithTag("Background").GetComponent<ScrollingBackground>();
    }

    public void OnClick()
    {
        if (!MapGenerator.tutorial)
        {
            EncounterGenerator.GetInstance().SetNewBossDialogue();
            StartCoroutine(StopCar());
            GameManager.Instance.atBoss = true;
        }
        else
        {

            StartCoroutine(StopCar());
            MapGenerator.tutorial = false;
        }
        
    }
    IEnumerator StopCar()
    {
        GameManager.Instance.CarMoveOut();
        bg.isScrolling = false;
        GameManager.Instance.MapMoveOut();
        yield return null;
    }
}
