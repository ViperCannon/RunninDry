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

    public GameObject car;
    public GameObject inSceneCar;
    public GameObject outSceneCar;
    public GameObject map;
    public GameObject inSceneMap;
    public GameObject outSceneMap;

    public bool newGame;
    bool wheelsSpinning = false;
    bool carMovingIn = false;
    bool carMovingOut = false;
    bool mapMovingIn = false;
    bool mapMovingOut = false;

    RelationshipsFramework relations;
    public TMP_Text scoretext;
    public ScrollingBackground ScrollingBackground;
    public GameObject scorecanvas;
    public GameObject maincanvas;

    [Header("Player Stats")]
    public TMP_Text cash;
    public TMP_Text tires;
    public TMP_Text paneling;
    public TMP_Text booze;

    [SerializeField] float waitTime;

    [Header("OUTDATED - REMOVE ALL REFERENCES SO WE CAN DELETE THEM")]
    public int talkerint;
    public string talkertype;

    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.FindWithTag("Map") != null) //perhaps edit this section to include more Null exceptions
        {
            relations = RelationshipsFramework.Instance;
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
            map.transform.position = Vector3.Lerp(map.transform.position, inSceneMap.transform.position, 2f * Time.deltaTime);
        }
        else
        {
            mapMovingIn = false;
        }
        
        if (mapMovingOut && Vector3.Distance(map.transform.position, outSceneMap.transform.position) > 0.1f)
        {
            mapMovingIn = false;
            map.transform.position = Vector3.Lerp(map.transform.position, outSceneMap.transform.position, 2f * Time.deltaTime);
        }
        else
        {
            mapMovingOut = false;
        }
    }

    public void DisplayScoreScreen()
    {
        ScrollingBackground.isScrolling = false;
        scorecanvas.SetActive(true);
        maincanvas.SetActive(false);
        relations.score = (relations.booze * 3) + relations.cash + (relations.paneling * 2) + (relations.tires * 2);
        scoretext.text = "Score: " + relations.score.ToString();
        //scoretext.text = "Cash: " + relations.cash.ToString() + " Booze: " + relations.booze.ToString() + " Tires: " + relations.tires.ToString() + " Paneling: " + relations.paneling.ToString();
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    #region Car Move In/Out Functions
    public void CarMoveIn()
    {
        WheelsSpin();
        carMovingIn = true;
    }

    public void CarMoveOut()
    {
        WheelsStop();
        carMovingOut = true;
    }
    #endregion

    #region Map Move In/Out Functions
    public void MapMoveIn()
    {
        mapMovingIn = true;
    }

    public void MapMoveOut()
    {
        mapMovingOut = true;
    }
    #endregion

    #region Wheel Spinning Enabled/Disabled Functions
    public void WheelsSpin()
    {
        wheelsSpinning = true;
    }

    public void WheelsStop()
    {
        wheelsSpinning = false;
    }
    #endregion

    public void EndEncounter()
    {
        MapMoveIn();
        CarMoveIn();
        ScrollingBackground.isScrolling = true;

        print(relations.copRelations);
        print(relations.civilianRelations);
        print(relations.drunkardRelations);
        print(relations.prohibitionistsRelations);
        print(relations.russianMobRelations);
        print(relations.norwegianMobRelations);
        print(relations.sicilianMobRelations);
    }
}
