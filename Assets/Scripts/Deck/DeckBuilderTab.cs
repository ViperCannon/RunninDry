using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DeckBuilderTab : MonoBehaviour
{
    Image buttonVisual;

    public DeckBuilderCharacter Character;
    TextMeshProUGUI tabLabel;

    public AudioSource audioSource;
    public AudioClip[] hoverSounds;
    public AudioClip[] switchTabSounds;

    void Awake()
    {
        buttonVisual = GetComponent<Image>();

        tabLabel = transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>();
        tabLabel.text = Character.CharacterName;
    }

    public void SelectTab()
    {
        // Visual Updates; Brightens this tab and darkens all others.
        ChangeButtonColor(Color.white);
        DeselectOtherTabs();

        // Change the active character to this tabs assigned character.
        if (DeckBuilderVer2.Instance != null) DeckBuilderVer2.Instance.SetSelectedCharacter(Character);
        else Debug.LogWarning("The DeckBuilder instance is NULL! Is there one in the scene?");
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
        audioSource.PlayOneShot(hoverSounds[Random.Range(0, hoverSounds.Length)]);
        buttonVisual.color = c;
    }
}
