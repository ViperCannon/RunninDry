using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HUBcurrency : MonoBehaviour
{
    [Header("Player Stats")]
    public TMP_Text cash;
    public TMP_Text tires;
    public TMP_Text paneling;
    public TMP_Text booze;

    public RelationshipsFramework relations;
    // Start is called before the first frame update
    void Start()
    {
        relations = GameObject.Find("GameManager").GetComponent<RelationshipsFramework>();
    }

    // Update is called once per frame
    void Update()
    {
        cash.text = relations.cash.ToString();
        tires.text = relations.tires.ToString();
        paneling.text = relations.paneling.ToString();
        booze.text = relations.booze.ToString();
    }
}
