using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeckBuilderFilters : MonoBehaviour
{
    public static DeckBuilderFilters Instance { get; private set; }

    // 0 = No Filter, 1 = Negotiation Cards, 2 = Combat Cards
    int currentFilter = 0;

    [SerializeField] RawImage paper;

    private void Start()
    {
        //Initialize Singleton Instance
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.LogWarning("There are multiple instances of the DeckBuilderFilters script in this scene! Removing the second.");
            Destroy(this);
        }
    }

    public void SetFilter(int n)
    {
        if (currentFilter == n) return;
        currentFilter = n;

        switch (currentFilter)
        {
            case 0:
                SetPaperColor(Color.white);
                break;

            case 1:
                SetPaperColor(new Color32(230, 230, 255, 255));
                break;

            case 2:
                SetPaperColor(new Color32(255, 230, 230, 255));
                break;

        }
    }

    void SetPaperColor(Color c)
    {
        paper.color = c;
    }
}
