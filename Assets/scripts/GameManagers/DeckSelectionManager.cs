using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckSelectionManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void negotiationcardSelected(string cardname)
    {
        Debug.Log("negotiation " + cardname);
    }
    public void combatcardSelected(string cardname)
    {
        Debug.Log("combat " + cardname);
    }

}
