using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    MusicController mController;

    public GameObject car;
    public GameObject InSceneCar;
    public GameObject OutSceneCar;
    public GameObject map;
    public GameObject InSceneMap;
    public GameObject OutSceneMap;
    ScrollingBackground bg;

    TalkerDatabase TalkDatabase;
    public RelationshipsFramework relations;
    public TMP_Text scoretext;
    public int talkerint;
    public string talkertype;
    public ScrollingBackground ScrollingBackground;
    public GameObject continuebutton;
    public GameObject scorecanvas;
    public GameObject maincanvas;
    public GameObject combatManager;
    [Header("Stats")]
    public TMP_Text cash;
    public TMP_Text tires;
    public TMP_Text paneling;
    public TMP_Text booze;
    [SerializeField]
    float waitTime;

    // Start is called before the first frame update
    void Start()
    {
        TalkDatabase = this.gameObject.GetComponent<TalkerDatabase>();
        if (GameObject.FindWithTag("Map") != null) //perhaps edit this section to include more Null exceptions
        {
            relations = this.gameObject.GetComponent<RelationshipsFramework>();
            
            bg = GameObject.FindWithTag("Background").GetComponent<ScrollingBackground>();

            cash.text = relations.cash.ToString();
            tires.text = relations.tires.ToString();
            paneling.text = relations.paneling.ToString();
            booze.text = relations.booze.ToString();
        }
    }
    public void Encounter(string type)
    {
        talkertype = type;
        TalkDatabase.Encounter(type);
    }

    public void scorescreen()
    {
        ScrollingBackground.isScrolling = false;
        scorecanvas.SetActive(true);
        maincanvas.SetActive(false);
        relations.score = (float)(relations.booze * (4 * 0.75)) + relations.cash + (relations.paneling * 2) + (relations.tires * 2);
        scoretext.text = "Score: " + relations.score.ToString();
        //scoretext.text = "Cash: " + relations.cash.ToString() + " Booze: " + relations.booze.ToString() + " Tires: " + relations.tires.ToString() + " Paneling: " + relations.paneling.ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void mainmenu()
    {
        SceneManager.LoadScene(0);
    }

    private void CarMoveIn()
    {

    }

    private void CarMoveOut()
    {

    }

    private void MapMoveIn()
    {

    }

    private void MapMoveOut()
    {

    }

    public void endEncounter()
    {
        cash.text = relations.cash.ToString();
        tires.text = relations.tires.ToString();
        paneling.text = relations.paneling.ToString();
        booze.text = relations.booze.ToString();
        //if talkdatabase.choiceint == 1 2 3 or 4 &&
        //do thing. may need to copy and paste the talkdatabase option 1-4 code here.
        //continuebutton.SetActive(false);
        StartCoroutine(endingEncounter());
       /* for (int i = 0; i < TalkDatabase.optionbuttons.transform.childCount; i++)
        {
            TalkDatabase.optionbuttons.transform.GetChild(i).gameObject.SetActive(false);
        }*/
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
        
        //overworld.SetTrigger("fadein");
        //car.SetTrigger("start");

        bg.isScrolling = true;
        //mController.UpdateMusic("");
        yield return new WaitForSeconds(waitTime);

        StopCoroutine(endingEncounter());
        yield return null;
    }
}
