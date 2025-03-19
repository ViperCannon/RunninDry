using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DeckBuilderTab : MonoBehaviour
{

    Image buttonVisual;

    [SerializeField] string characterName;
    TextMeshProUGUI tabLabel;

    void Start()
    {
        buttonVisual = GetComponent<Image>();

        tabLabel = transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>();
        tabLabel.text = characterName;
    }

    public void SelectTab()
    {
        ChangeButtonColor(Color.white);
        DeselectTabs();
    }

    void DeselectTabs()
    {
        DeckBuilderTab[] tabs = FindObjectsOfType<DeckBuilderTab>();

        foreach (DeckBuilderTab tab in tabs)
        {
            if (tab != this)
            {
                tab.ChangeButtonColor(new Color(0.7f, 0.7f, 0.7f));
            }
        }
    }

    void ChangeButtonColor(Color c)
    {
        buttonVisual.color = c;
    }
}
