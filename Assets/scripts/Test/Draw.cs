using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draw : MonoBehaviour
{
    public int drawNumber = 1;

    [SerializeField]
    HandManager handManager;

    public void ButtonFunction()
    {
        handManager.AttemptDraw(drawNumber);
    }
}
