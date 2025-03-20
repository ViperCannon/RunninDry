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
        EncounterGenerator.GetInstance().SetNewBossDialogue();
        StartCoroutine(StopCar());
    }
    IEnumerator StopCar()
    {
        GameManager.Instance.CarMoveOut();
        bg.isScrolling = false;
        GameManager.Instance.MapMoveOut();
        yield return null;
    }
}
