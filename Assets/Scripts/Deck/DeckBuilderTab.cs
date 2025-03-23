using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DeckBuilderTab : MonoBehaviour
{

    Image buttonVisual;

    public DeckBuilderCharacter Character { get; private set; }
    TextMeshProUGUI tabLabel;

    void Start()
    {
        buttonVisual = GetComponent<Image>();

        tabLabel = transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>();
        tabLabel.text = Character.CharacterName;
    }

    public void SelectTab()
    {
        // Visual Updates
        ChangeButtonColor(Color.white);
        DeselectOtherTabs();

        // Change the Active Card List
        DeckBuilderVer2.Instance.SetSelectedCharacter(Character);
    }

    void DeselectOtherTabs()
    {
        DeckBuilderTab[] tabs = FindObjectsOfType<DeckBuilderTab>();

        foreach (DeckBuilderTab tab in tabs)
        {
            if (tab != this)
            {
                tab.ChangeButtonColor(new Color32(180, 180, 180, 255));
            }
        }
    }

    void ChangeButtonColor(Color c)
    {
        buttonVisual.color = c;
    }
}
