using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance { get; private set; }

    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        } 
    }

    [SerializeField]
    MusicController mController;

    public GameObject car;
    public GameObject inSceneCar;
    public GameObject outSceneCar;
    public GameObject map;
    public GameObject inSceneMap;
    public GameObject outSceneMap;
    ScrollingBackground bg;

    public bool newGame;
    bool wheelsSpinning = false;
    bool carMovingIn = false;
    bool carMovingOut = false;
    bool mapMovingIn = false;
    bool mapMovingOut = false;

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
        TalkDatabase = gameObject.GetComponent<TalkerDatabase>();
        if (GameObject.FindWithTag("Map") != null) //perhaps edit this section to include more Null exceptions
        {
            relations = gameObject.GetComponent<RelationshipsFramework>();

            bg = GameObject.FindWithTag("Background").GetComponent<ScrollingBackground>();

            cash.text = relations.cash.ToString();
            tires.text = relations.tires.ToString();
            paneling.text = relations.paneling.ToString();
            booze.text = relations.booze.ToString();
        }

        MapMoveIn();
        CarMoveIn();
    }

    private void FixedUpdate()
    {
        if (carMovingIn && Vector3.Distance(car.transform.position, inSceneCar.transform.position) > 0.1f)
        {
            if (!wheelsSpinning)
            {
                WheelsSpin();
            }

            Debug.Log("Car is Moving In");

            car.transform.position = Vector3.Lerp(car.transform.position, inSceneCar.transform.position, 2f * Time.deltaTime);
        }
        else
        {
            carMovingIn = false;
        }
        
        if (carMovingOut && Vector3.Distance(car.transform.position, outSceneCar.transform.position) > 0.1f)
        {
            carMovingIn = false;

            if (!wheelsSpinning)
            {
                WheelsSpin();
            }

            Debug.Log("Car is Moving Out");

            car.transform.position = Vector3.Lerp(car.transform.position, outSceneCar.transform.position, 2f * Time.deltaTime);
        }
        else
        { 
            if (carMovingOut)
            {
                WheelsStop();
            }

            carMovingOut = false;
        }

        if (mapMovingIn && Vector3.Distance(map.transform.position, inSceneMap.transform.position) > 0.1f)
        {
            Debug.Log("Map is Moving In");

            map.transform.position = Vector3.Lerp(map.transform.position, inSceneMap.transform.position, 2f * Time.deltaTime);
        }
        else
        {
            mapMovingIn = false;
        }
        
        if (mapMovingOut && Vector3.Distance(map.transform.position, outSceneMap.transform.position) > 0.1f)
        {
            mapMovingIn = false;

            Debug.Log("Map is Moving Out");

            map.transform.position = Vector3.Lerp(map.transform.position, outSceneMap.transform.position, 2f * Time.deltaTime);
        }
        else
        {
            mapMovingOut = false;
        }

        if (wheelsSpinning)
        {

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
        relations.score = (relations.booze * 3) + relations.cash + (relations.paneling * 2) + (relations.tires * 2);
        scoretext.text = "Score: " + relations.score.ToString();
        //scoretext.text = "Cash: " + relations.cash.ToString() + " Booze: " + relations.booze.ToString() + " Tires: " + relations.tires.ToString() + " Paneling: " + relations.paneling.ToString();
    }

    public void mainmenu()
    {
        SceneManager.LoadScene(0);
    }

    public void CarMoveIn()
    {
        WheelsSpin();
        carMovingIn = true;
    }

    public void CarMoveOut()
    {
        carMovingOut = true;
    }

    public void MapMoveIn()
    {
        mapMovingIn = true;
    }

    public void MapMoveOut()
    {
        mapMovingOut = true;
    }

    public void WheelsSpin()
    {
        wheelsSpinning = true;
    }

    public void WheelsStop()
    {
        wheelsSpinning = false;
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
