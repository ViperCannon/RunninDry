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

        story.BindExternalFunction("FullPartyHeal", (int amount) => FullPartyHeal(amount));
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

        story.UnbindExternalFunction("FullPartyHeal");
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
        RelationshipsFramework.GetInstance().cash += amount;

        if (amount > 0) Debug.Log("The player's Cash stash increased by " + amount + "!");
        else Debug.Log("The player's Cash stash decreased by " + amount + "!");
    }

    private void AddBooze(int amount)
    {
        RelationshipsFramework.GetInstance().booze += amount;

        if (amount > 0) Debug.Log("The player's stockpile of Booze increased by " + amount + "!");
        else Debug.Log("The player's stockpile of Booze decreased by " + amount + "!");
    }

    private void AddScore(int amount)
    {
        RelationshipsFramework.GetInstance().score += amount;

        if (amount > 0) Debug.Log("The player's Score increased by " + amount + "!");
        else Debug.Log("The player's Score decreased by " + amount + "!");
    }

    private void AddTires(int amount)
    {
        RelationshipsFramework.GetInstance().tires += amount;

        if (amount > 0) Debug.Log("The player's number of Tires increased by " + amount + "!");
        else Debug.Log("The player's number of Tires decreased by " + amount + "!");
    }

    private void AddPaneling(int amount)
    {
        RelationshipsFramework.GetInstance().paneling += amount;
        
        if (amount > 0) Debug.Log("The player's number of Paneling increased by " + amount + "!");
        else Debug.Log("The player's'Paneling number of decreased by " + amount + "!");
    }
    #endregion

    #region Functions that Increase or Decrease Faction Relations
    private void AlterCopRelations(int amount)
    {
        RelationshipsFramework.GetInstance().copRelations += amount;

        if (amount > 0) Debug.Log("The player's reputation with the cops increased by " + amount + "!");
        else Debug.Log("The player's reputation with the cops decreased by " + amount + "!");
    }

    private void AlterRussianMobRelations(int amount)
    {
        RelationshipsFramework.GetInstance().russianMobRelations += amount;

        if (amount > 0) Debug.Log("The player's reputation with the Russian mob increased by " + amount + "!");
        else Debug.Log("The player's reputation with the Russian mob decreased by " + amount + "!");
    }

    private void AlterNorwegianMobRelations(int amount)
    {
        RelationshipsFramework.GetInstance().norwegianMobRelations += amount;

        if (amount > 0) Debug.Log("The player's reputation with the Norwegian mob increased by " + amount + "!");
        else Debug.Log("The player's reputation with the Norwegian mob decreased by " + amount + "!");
    }

    private void AlterSicilianMobRelations(int amount)
    {
        RelationshipsFramework.GetInstance().sicilianMobRelations += amount;

        if (amount > 0) Debug.Log("The player's reputation with the Sicilian mob increased by " + amount + "!");
        else Debug.Log("The player's reputation with the Sicilian mob decreased by " + amount + "!");
    }

    private void AlterProhibitionistRelations(int amount)
    {
        RelationshipsFramework.GetInstance().prohibitionistsRelations += amount;

        if (amount > 0) Debug.Log("The player's reputation with the prohibitionists increased by " + amount + "!");
        else Debug.Log("The player's reputation with the prohibitionists decreased by " + amount + "!");
    }

    private void AlterDrunkardRelations(int amount)
    {
        RelationshipsFramework.GetInstance().drunkardRelations += amount;

        if (amount > 0) Debug.Log("The player's reputation with the drunkards increased by " + amount + "!");
        else Debug.Log("The player's reputation withthe drunkards decreased by " + amount + "!");
    }

    private void AlterCivilianRelations(int amount)
    {
        RelationshipsFramework.GetInstance().civilianRelations += amount;

        if (amount > 0) Debug.Log("The player's reputation with civilians increased by " + amount + "!");
        else Debug.Log("The player's reputation with civilians decreased by " + amount + "!");
    }
    #endregion

    private void FullPartyHeal(int amount)
    {
        Debug.Log("All player characters healed by " + amount + " HP!");
    }
}