using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;
using UnityEngine.Experimental.Playables;

public class InkExternalFunctions
{
    public void Bind(Story story)
    {
        story.BindExternalFunction("TestBinding", () => TestBinding());
        story.BindExternalFunction("StartCombat", () => StartCombat());
        story.BindExternalFunction("StartNegotiation", () => StartNegotiation());
    }

    public void Unbind(Story story)
    {
        story.UnbindExternalFunction("TestBinding");
        story.UnbindExternalFunction("StartCombat");
        story.UnbindExternalFunction("StartNegotiation");
    }

    private void TestBinding()
    {
        Debug.Log("Hello! This bind was successful!");
    }

    private void StartCombat()
    {
        //TODO: Once the combat initialization system is finished, make it so this function can call upon it!
        Debug.Log("Combat should begin here, but it's not ready yet so this will have to do!");
    }

    private void StartNegotiation()
    {
        //TODO: Once the negotiation system is finished, make it so this function can call upon it!
        Debug.Log("Negotiation should begin here, but it's not ready yet so this will have to do!");
    }
}
