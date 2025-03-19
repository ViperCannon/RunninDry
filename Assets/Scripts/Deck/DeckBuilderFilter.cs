using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeckBuilderFilter : MonoBehaviour
{

    // 0 = No Filter, 1 = Negotiation, 2 = Combat
    int currentFilter = 0;

    [SerializeField] RawImage paper;

    public void SetFilter(int n)
    {
        if (currentFilter == n) return;
        currentFilter = n;

        switch (currentFilter)
        {
            case 0:
                setPaperColor(Color.white);
                break;

            case 1:
                setPaperColor(new Color32(230, 230, 255, 255));
                break;

            case 2:
                setPaperColor(new Color32(255, 230, 230, 255));
                break;

        }
    }

    void setPaperColor(Color c)
    {
        paper.color = c;
    }
}
