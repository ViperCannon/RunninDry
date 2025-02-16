using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;
using UnityEngine.Experimental.Playables;

public class InkExternalFunctions
{
    public void Bind(Story story)
    {
        story.BindExternalFunction("StartCombat", () => StartCombat());
        story.BindExternalFunction("StartNegotiation", () => StartNegotiation());

        // Resource Functions
        story.BindExternalFunction("AddCash", (int amount) => AddCash(amount));
        story.BindExternalFunction("AddBooze", (int amount) => AddBooze(amount));
        story.BindExternalFunction("AddScore", (int amount) => AddScore(amount));
        story.BindExternalFunction("AddTires", (int amount) => AddTires(amount));
        story.BindExternalFunction("AddPaneling", (int amount) => AddPaneling(amount));

        // Reputation Functions
        story.BindExternalFunction("AlterCopRelations", (int amount) => AlterCopRelations(amount));
        story.BindExternalFunction("AlterRussianMobRelations", (int amount) => AlterRussianMobRelations(amount));
        story.BindExternalFunction("AlterNorwegianMobRelations", (int amount) => AlterNorwegianMobRelations(amount));
        story.BindExternalFunction("AlterSicilianMobRelations", (int amount) => AlterSicilianMobRelations(amount));
        story.BindExternalFunction("AlterProhibitionistRelations", (int amount) => AlterProhibitionistRelations(amount));
        story.BindExternalFunction("AlterDrunkardRelations", (int amount) => AlterDrunkardRelations(amount));
        story.BindExternalFunction("AlterCivilianRelations", (int amount) => AlterCivilianRelations(amount));
    }

    public void Unbind(Story story)
    {
        story.UnbindExternalFunction("StartCombat");
        story.UnbindExternalFunction("StartNegotiation");

        story.UnbindExternalFunction("AddCash");
        story.UnbindExternalFunction("AddBooze");
        story.UnbindExternalFunction("AddScore");
        story.UnbindExternalFunction("AddTires");
        story.UnbindExternalFunction("AddPaneling");

        story.UnbindExternalFunction("AlterCopRelations");
        story.UnbindExternalFunction("AlterRussianMobRelations");
        story.UnbindExternalFunction("AlterNorwegianMobRelations");
        story.UnbindExternalFunction("AlterSicilianMobRelations");
        story.UnbindExternalFunction("AlterProhibitionistRelations");
        story.UnbindExternalFunction("AlterDrunkardRelations");
        story.UnbindExternalFunction("AlterCivilianRelations");
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

    #region Functions that Add or Subtract from Player Resources
    private void AddCash(int amount)
    {
        //TODO: Attach to the relationship framework!

        if (amount > 0) Debug.Log("The player should have their Cash increased by " + amount + "!");
        else Debug.Log("The player should have their Cash decreased by " + amount + "!");
    }

    private void AddBooze(int amount)
    {
        //TODO: Attach to the relationship framework!

        if (amount > 0) Debug.Log("The player should have their Booze increased by " + amount + "!");
        else Debug.Log("The player should have their Booze decreased by " + amount + "!");
    }

    private void AddScore(int amount)
    {
        //TODO: Attach to the relationship framework!

        if (amount > 0) Debug.Log("The player should have their Score increased by " + amount + "!");
        else Debug.Log("The player should have their Score decreased by " + amount + "!");
    }

    private void AddTires(int amount)
    {
        //TODO: Attach to the relationship framework!

        if (amount > 0) Debug.Log("The player should have their Tires increased by " + amount + "!");
        else Debug.Log("The player should have their Tires decreased by " + amount + "!");
    }

    private void AddPaneling(int amount)
    {
        //TODO: Attach to the relationship framework!
        
        if (amount > 0) Debug.Log("The player should have their Paneling increased by " + amount + "!");
        else Debug.Log("The player should have their Paneling decreased by " + amount + "!");
    }
    #endregion

    #region Functions that Increase or Decrease Faction Relations
    private void AlterCopRelations(int amount)
    {
        //TODO: Attach to the relationship framework!

        if (amount > 0) Debug.Log("The player should have their reputation with the cops increased by " + amount + "!");
        else Debug.Log("The player should have their reputation with the cops decreased by " + amount + "!");
    }

    private void AlterRussianMobRelations(int amount)
    {
        //TODO: Attach to the relationship framework!

        if (amount > 0) Debug.Log("The player should have their reputation with the Russian mob increased by " + amount + "!");
        else Debug.Log("The player should have their reputation with the Russian mob decreased by " + amount + "!");
    }

    private void AlterNorwegianMobRelations(int amount)
    {
        //TODO: Attach to the relationship framework!

        if (amount > 0) Debug.Log("The player should have their reputation with the Norwegian mob increased by " + amount + "!");
        else Debug.Log("The player should have their reputation with the Norwegian mob decreased by " + amount + "!");
    }

    private void AlterSicilianMobRelations(int amount)
    {
        //TODO: Attach to the relationship framework!

        if (amount > 0) Debug.Log("The player should have their reputation with the Sicilian mob increased by " + amount + "!");
        else Debug.Log("The player should have their reputation with the Sicilian mob decreased by " + amount + "!");
    }

    private void AlterProhibitionistRelations(int amount)
    {
        //TODO: Attach to the relationship framework!

        if (amount > 0) Debug.Log("The player should have their reputation with the prohibitionists increased by " + amount + "!");
        else Debug.Log("The player should have their reputation with the prohibitionists decreased by " + amount + "!");
    }

    private void AlterDrunkardRelations(int amount)
    {
        //TODO: Attach to the relationship framework!

        if (amount > 0) Debug.Log("The player should have their reputation with the drunkards increased by " + amount + "!");
        else Debug.Log("The player should have their reputation with the drunkards decreased by " + amount + "!");
    }

    private void AlterCivilianRelations(int amount)
    {
        //TODO: Attach to the relationship framework!

        if (amount > 0) Debug.Log("The player should have their reputation with civilians increased by " + amount + "!");
        else Debug.Log("The player should have their reputation with civilians decreased by " + amount + "!");
    }
    #endregion
}