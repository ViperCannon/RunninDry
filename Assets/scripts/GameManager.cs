using System.Collections;
using System.Collections.Generic;
using UnityEditor.VersionControl;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    Animator overworld;
    Animator car;
    GameObject AssetHolder;
    TalkerDatabase TalkDatabase;
    relationshipframework relations;
    public int talkerint;
    public string talkertype;
    [SerializeField]
    float waitTime;
    [Header("Negotiation")]
    public GameObject Nassets1;
    public GameObject Nassets2;
    [Header("Combat")]
    public GameObject Cassets1;
    public GameObject Cassets2;
    [Header("Events")]
    public GameObject Eassets1;
    public GameObject Eassets2;
    [Header("MiniBoss")]
    public GameObject MBassets1;
    public GameObject MBassets2;
    [Header("Mystery")]
    public GameObject Massets1;
    public GameObject Massets2;
    [Header("Pitstop")]
    public GameObject Passets1;
    public GameObject Passets2;
    [Header("Shop")]
    public GameObject Sassets1;
    public GameObject Sassets2;

    // Start is called before the first frame update
    void Start()
    {
        relations = this.gameObject.GetComponent<relationshipframework>();
        TalkDatabase = this.gameObject.GetComponent<TalkerDatabase>();
        overworld = GameObject.FindWithTag("Map").GetComponent<Animator>();
        car = GameObject.FindWithTag("car").gameObject.GetComponent<Animator>();
        AssetHolder = GameObject.Find("NodeSpawnAssets");
        GrabAssets();
        for (int i = 0; i < AssetHolder.transform.childCount; i++)
        {
            AssetHolder.transform.GetChild(i).gameObject.SetActive(false);
        }
    }
    public void encounter(string type)
    {
        talkertype = type;
        TalkDatabase.encounter(type);
    }
    public void GrabAssets()
    {
        if (GameObject.Find("N1") != null && GameObject.Find("N2") != null)
        {
            Nassets1 = GameObject.Find("N1");
            Nassets2 = GameObject.Find("N2");

            Cassets1 = GameObject.Find("C1");
            Cassets2 = GameObject.Find("C2");

            Eassets1 = GameObject.Find("E1");
            Eassets2 = GameObject.Find("E2");

            MBassets1 = GameObject.Find("MB1");
            MBassets2 = GameObject.Find("MB2");

            Massets1 = GameObject.Find("M1");
            Massets2 = GameObject.Find("M2");

            Passets1 = GameObject.Find("P1");
            Passets2 = GameObject.Find("P2");

            Sassets1 = GameObject.Find("S1");
            Sassets2 = GameObject.Find("S2");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void endEncounter()
    {
        StartCoroutine(endingEncounter());
        for (int i = 0; i < TalkDatabase.optionbuttons.transform.childCount; i++)
        {
            TalkDatabase.optionbuttons.transform.GetChild(i).gameObject.SetActive(false);
        }
        //TalkDatabase.textbox.SetActive(false);
        print(relations.copRelations);
        print(relations.civilianRelations);
        print(relations.drunkardRelations);
        print(relations.prohibitionistsRelations);
        print(relations.russianMobRelations);
        print(relations.norwegianMobRelations);
        print(relations.sicilianMobRelations);
    }

    IEnumerator endingEncounter()
    {
        //TalkDatabase.text.text = TalkDatabase.responsetext;
        //yield return new WaitForSeconds(5);
        TalkDatabase.textbox.SetActive(false);
        //TalkDatabase.text = TalkDatabase.Getresponse();
        overworld.SetTrigger("fadein");
        car.SetTrigger("start");
        yield return new WaitForSeconds(waitTime);
        for (int i = 0; i < AssetHolder.transform.childCount; i++)
        {
            AssetHolder.transform.GetChild(i).gameObject.SetActive(false);
        }
        StopCoroutine(endingEncounter());
        yield return null;
    }
}
