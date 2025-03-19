using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckBuilderVer2 : MonoBehaviour
{
    /* THIS ENTIRE IMPLEMENTATION IS TEMPORARY JUST TO ENSURE WE HAVE SOMETHING
     * TO SHOWCASE AT THE PRESENTATION. THIS NEEDS A SERIOUS OVERHAUL.
     */

    DeckSelectionManager selectionManager;

    GameObject pixieCards;
    GameObject baldwinCards;
    GameObject barleyCards;

    // Start is called before the first frame update
    void Start()
    {
        selectionManager = GameObject.Find("DeckSelectionHandler").GetComponent<DeckSelectionManager>();

        pixieCards = GameObject.Find("pixiecards");
        baldwinCards = GameObject.Find("baldwincards");
        barleyCards = GameObject.Find("barleycards");
    }

    public void SetPixieCards()
    {

    }

    public void SetBaldwinCards()
    {

    }

    public void SetBarleyCards()
    {

    }
}
