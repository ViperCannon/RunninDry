using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Map;
using JetBrains.Annotations;

[System.Serializable]

public class GameData
{
    public List<string> TotalNegotiationCards;
    public List<string> TotalCombatCards;
    public List<string> Pixiecards;
    public List<string> Baldwincards;
    public List<string> Barleycards;
    public List<string> NPixiecards;
    public List<string> CPixiecards;
    public List<string> NBaldwincards;
    public List<string> CBaldwincards;
    public List<string> NBarleycards;
    public List<string> CBarleycards;

    public bool inRun;
    //public List<string> hubPurchases;
    public int chairUpgrades;
    public int comfortUpgrades;
    public int barUpgrades;
    public int wallUpgrades;
    public int stockUpgrades;
    public int entertainmentUpgrades;

    public int totalUpgrades;

    public int barMoney;

    public List<Buff> activeBuffs;
    public List<Debuff> activeDebuffs;

    public int copRelations;
    public int russianMobRelations;
    public int norwegianMobRelations;
    public int sicilianMobRelations;
    public int prohibitionistsRelations;
    public int drunkardRelations;
    public int civilianRelations;

    public int cash;
    public int paneling;
    public int booze;
    public int tires;

    public int sceneInt;

    /*public bool savedMap;
    public Node[][] mapData;
    public Node crew;
    public Node bossNode;*/

    public GameData()
    {
        this.cash = 40;
        this.booze = 8;
        this.paneling = 3;
        this.tires = 3;

        this.copRelations = 50;
        this.russianMobRelations = 50;
        this.norwegianMobRelations = 50;
        this.sicilianMobRelations = 50;
        this.prohibitionistsRelations = 50;
        this.drunkardRelations = 50;
        this.civilianRelations = 50;

        activeBuffs = new List<Buff>();
        activeDebuffs = new List<Debuff>();

        inRun = false;
        //hubPurchases = new List<string>();
        chairUpgrades = 0;
        comfortUpgrades = 0;
        barUpgrades = 0;
        wallUpgrades = 0;
        stockUpgrades = 0;
        entertainmentUpgrades = 0;

        totalUpgrades = 0;

        barMoney = 5;

        this.sceneInt = 0;

        TotalNegotiationCards = new List<string>();
        TotalCombatCards = new List<string>();
        Pixiecards = new List<string>();
        Baldwincards = new List<string>();
        Barleycards = new List<string>();
        NPixiecards = new List<string>();
        CPixiecards = new List<string>();
        NBaldwincards = new List<string>();
        CBaldwincards = new List<string>();
        NBarleycards = new List<string>();
        CBarleycards = new List<string>();
    }
}
