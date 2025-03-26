using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeckBuilderFilters : MonoBehaviour
{
    public static DeckBuilderFilters Instance { get; private set; }

    // 0 = No Filter/Show All Cards, 1 = Negotiation Cards, 2 = Combat Cards
    public int CurrentFilter { get; private set; } = 0;

    Button NegotiationFilterButton;
    Button CombatFilterButton;

    [SerializeField] RawImage paper;

    private void Awake()
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

        NegotiationFilterButton = GameObject.Find("NegotiationFilterButton").GetComponent<Button>();
        CombatFilterButton = GameObject.Find("CombatFilterButton").GetComponent<Button>();
    }

    public void SetFilter(int n)
    {
        if (CurrentFilter == n) CurrentFilter = 0;
        else CurrentFilter = n;

        switch (CurrentFilter)
        {
            case 0:
                SetColor(NegotiationFilterButton.image, Color.white);
                SetColor(CombatFilterButton.image, Color.white);
                SetColor(paper, Color.white);
                
                DeckBuilderVer2.Instance.DisplayAllCards();
                break;

            case 1:
                SetColor(NegotiationFilterButton.image, Color.white);
                SetColor(CombatFilterButton.image, new Color32(20, 20, 20, 255));
                SetColor(paper, new Color32(250, 250, 255, 255));
                
                DeckBuilderVer2.Instance.DisplayNegotiationCards();
                break;

            case 2:
                SetColor(NegotiationFilterButton.image, new Color32(20, 20, 20, 255));
                SetColor(CombatFilterButton.image, Color.white);
                SetColor(paper, new Color32(255, 250, 250, 255));
                
                DeckBuilderVer2.Instance.DisplayCombatCards();
                break;
        }
    }

    #region SetColor Function/Overrides
    void SetColor(Image i, Color c)
    {
        i.color = c;
    }

    void SetColor(RawImage i, Color c)
    {
        i.color = c;
    }
    #endregion
}
