using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RelationshipsFramework : MonoBehaviour
{
    public float copRelations;
    public float russianMobRelations;
    public float norwegianMobRelations;
    public float sicilianMobRelations;
    public float prohibitionistsRelations;
    public float drunkardRelations;
    public float civilianRelations;

    public int cash = 40;
    public int paneling = 3;
    public int booze = 8; // Each booze sells for $4.
    public int tires = 3;
    public float score;

    private void Start()
    {
        cash = 40;
        paneling = 3;
        booze = 8; // Each booze sells for $4.
        tires = 3;
    }
}
