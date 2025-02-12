using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class GameData
{
    public List<string> hubPurchases;

    public float copRelations;
    public float russianMobRelations;
    public float norwegianMobRelations;
    public float sicilianMobRelations;
    public float prohibitionistsRelations;
    public float drunkardRelations;
    public float civilianRelations;

    public int cash;
    public int paneling;
    public int booze;
    public int tires;

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

        hubPurchases = new List<string>();
    }
}
