using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RelationshipsFramework : MonoBehaviour, IDataPersistence
{
    public float copRelations;
    public float russianMobRelations;
    public float norwegianMobRelations;
    public float sicilianMobRelations;
    public float prohibitionistsRelations;
    public float drunkardRelations;
    public float civilianRelations;

    public int cash;
    public int paneling;
    public int booze; // Each booze sells for $4.
    public int tires;
    public float score;

    public void LoadData(GameData data)
    {
        this.cash = data.cash;
        this.paneling = data.paneling;
        this.booze = data.booze;
        this.tires = data.tires;
        
        this.copRelations = data.copRelations;
        this.russianMobRelations = data.russianMobRelations;
        this.norwegianMobRelations = data.norwegianMobRelations;
        this.sicilianMobRelations = data.sicilianMobRelations;
        this.prohibitionistsRelations = data.prohibitionistsRelations;
        this.drunkardRelations = data.drunkardRelations;
        this.civilianRelations = data.civilianRelations;
    }

    public void SaveData(ref GameData data)
    {
        data.cash = this.cash;
        data.paneling = this.paneling;
        data.booze = this.booze;
        data.tires = this.tires;

        data.copRelations = this.copRelations;
        data.russianMobRelations = this.russianMobRelations;
        data.norwegianMobRelations = this.norwegianMobRelations;
        data.sicilianMobRelations = this.sicilianMobRelations;
        data.prohibitionistsRelations = this.prohibitionistsRelations;
        data.drunkardRelations = this.drunkardRelations;
        data.civilianRelations = this.civilianRelations;
    }

    private void Start()
    {
        //cash = 40;
        //paneling = 3;
        //booze = 8; // Each booze sells for $4.
        //tires = 3;
    }
}
