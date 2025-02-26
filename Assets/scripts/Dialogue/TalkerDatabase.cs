using TMPro;
using UnityEngine;
using UnityEngine.InputSystem.HID;
using UnityEngine.UI;
using static Unity.Burst.Intrinsics.X86;
using static Unity.Burst.Intrinsics.X86.Avx;
using static Unity.Collections.Unicode;

[System.Serializable]
public class TalkerDataEntry
{
    public int TalkerId;
    public string TalkerName;
    public string TalkerText;
    public string TalkerType;
    public int Optioncount;
    public string Option1;
    public string Option2;
    public string Option3;
    public string Option4;
    public string Option1outcome;
    public string Option2outcome;
    public string Option3outcome;
    public string Option4outcome;
}

[System.Serializable]
public class TalkerDataJSON
{
    public TalkerDataEntry[] Talkers;
}
    
public class TalkerDatabase : MonoBehaviour
{
    public TextAsset MyJsonData;
    TalkerDataJSON MyTalkerData;
    int optionCount;
    public int choiceint;
    public GameObject textbox;
    public GameObject optionbuttons;
    public TMP_Text optionstext1;
    public TMP_Text optionstext2;
    public TMP_Text optionstext3;
    public TMP_Text optionstext4;
    public TMP_Text text;
    public TMP_Text talkername;
    public RawImage talkerimage;
    public string responsetext;
    GameManager manager;
    RelationshipsFramework relations;

    public void Encounter(string type)
    {
        textbox.SetActive(true);
        text.text = GetTalkerText(manager.talkerint, type);
        talkername.text = GetTalkerName(manager.talkerint, type);
        talkerimage.texture = Resources.Load<Texture2D>("Dialogueimages/" + type+"/"+manager.talkerint.ToString());

        GetButtonData(manager.talkerint, type);
        for (int i = 0; i < MyTalkerData.Talkers[manager.talkerint].Optioncount; i++)
        {
            optionbuttons.transform.GetChild(i).gameObject.SetActive(true);
        }
        //for button text, if different options are required use the talker strings to include data for what the 4 buttons should be ie public string TalkerOption1, 2, 3, etc
        //have 4 functions for each button and each one could sort with If statements for the talkertype and then talkerID 
    }

    void Start()
    {
        relations = this.gameObject.GetComponent<RelationshipsFramework>();
        manager = this.gameObject.GetComponent<GameManager>();
        string json = MyJsonData.text;
        MyTalkerData = JsonUtility.FromJson<TalkerDataJSON>(json);
        textbox.SetActive(false);
    }

    public void GetButtonData(int talkerId, string type)
    {
        for (int i = 0; i < MyTalkerData.Talkers.Length -1 ; ++i)
        {
            if (MyTalkerData.Talkers[i].TalkerType == type && MyTalkerData.Talkers[i].TalkerId == talkerId)
            {
                optionCount = MyTalkerData.Talkers[i].Optioncount;
                optionstext1.text = MyTalkerData.Talkers[i].Option1;
                optionstext2.text = MyTalkerData.Talkers[i].Option2;
                optionstext3.text = MyTalkerData.Talkers[i].Option3;
                optionstext4.text = MyTalkerData.Talkers[i].Option4;
            }
        }
        for (int i = 0; i < optionCount; i++)
        {
            optionbuttons.transform.GetChild(i).gameObject.SetActive(true);
        }

        if (optionstext1.text == "text") optionbuttons.transform.GetChild(0).gameObject.SetActive(false);
        if (optionstext2.text == "text") optionbuttons.transform.GetChild(1).gameObject.SetActive(false);
        if (optionstext3.text == "text") optionbuttons.transform.GetChild(2).gameObject.SetActive(false);
        if (optionstext4.text == "text") optionbuttons.transform.GetChild(3).gameObject.SetActive(false);
    }

    public string GetResponse(int talkerId, string type, int optionNumber)
    {
        for (int i = 0; i < MyTalkerData.Talkers.Length; ++i)
        {
            if (MyTalkerData.Talkers[i].TalkerType == type && MyTalkerData.Talkers[i].TalkerId == talkerId)
            {
                switch (optionNumber)
                {
                    case 1:
                        return MyTalkerData.Talkers[i].Option1outcome;

                    case 2:
                        return MyTalkerData.Talkers[i].Option2outcome;

                    case 3:
                        return MyTalkerData.Talkers[i].Option3outcome;

                    case 4:
                        return MyTalkerData.Talkers[i].Option4outcome;
                }
            }
        }
        return "[NO_NAME_FOUND]";
    }

    public string GetTalkerName(int talkerId, string type)
    {
        for(int i = 0; i < MyTalkerData.Talkers.Length; ++i)
        {
            if (MyTalkerData.Talkers[i].TalkerType == type && MyTalkerData.Talkers[i].TalkerId == talkerId)
            {
                return MyTalkerData.Talkers[i].TalkerName;
            }
        }
        return "[NO_NAME_FOUND]";
    }

    public string GetTalkerText(int talkerId, string type)
    {
        for (int i = 0; i < MyTalkerData.Talkers.Length; ++i)
        {
            if (MyTalkerData.Talkers[i].TalkerType == type && MyTalkerData.Talkers[i].TalkerId == talkerId)
            {
                return MyTalkerData.Talkers[i].TalkerText;
            }
        }
        return "[NO_TEXT_FOUND]";
    }

    public void GetResponse(int choicenumber)
    {
        text.text = responsetext;
        choiceint = choicenumber;
    }

    public void Option1()
    {
        switch (manager.talkertype)
        {
            case "Event":
                switch (manager.talkerint)
                {
                    case 1:
                        if (relations.copRelations >= 40)
                        {
                            relations.copRelations += 2;
                            relations.civilianRelations += 2;
                        }
                        else
                        {
                            // Initiate a combat encounter with one cop.
                        }
                        break;

                    case 2:
                        relations.civilianRelations -= 5;
                        break;

                    case 3:
                        relations.civilianRelations -= 2;
                        break;

                    case 4:
                        // Full-Party Heal; +5 HP.
                        relations.cash -= 2;
                        relations.civilianRelations += 3;
                        break;

                    case 5:
                        relations.cash += 10;
                        relations.civilianRelations += 5;
                        relations.copRelations -= 5;
                        break;

                    case 6:
                        if (relations.civilianRelations >= 60)
                        {
                            // She smiles, takes your assistance, and presses a bill into your hands. (+2 Civ Rp, +3 Cash)
                            relations.civilianRelations += 2;
                            relations.cash += 3;
                        }
                        else if (relations.civilianRelations >= 25 && relations.civilianRelations < 60)
                        {
                            // She smiles and takes your assistance. (+2 Civ RP)
                            relations.civilianRelations += 2;
                        }
                        else if (relations.civilianRelations < 25)
                        {
                            // She frowns and walks away. (-2 Civ RP)
                            relations.civilianRelations -= 2;
                        }
                        break;

                    default:
                        DebugLogInvalidTalkerint();
                        break;
                }
                break;

            case "Negotiation":
                switch (manager.talkerint)
                {
                    case 1:
                        /* Negotiation P/I/B: 14/8/10
                         * SUCCESS: the man cools off, apologizes, and gets back in his car.
                         * FAIL: your words worsen the situation, and he elbows one of your car windows in. (-1 Paneling) He then hightails it out of there.
                         */
                        break;

                    case 2:
                        /* Negotiation P/I/B: 12/16/25
                         * SUCCESS: The crowd hears your words and begins to chant "Booze! Booze! Booze!" The abolitionists hightail it out of there. (+10 Dru RP, +5 Civ RP. -15 Abo RP)
                         * FAIL: The crowd becomes restless, opinion turning on you. The Abolitionist speaker smiles then yells "Get 'em!" (- 5 Abo RP, -5 Civ RP, +5 Dru RP) Begin combat with 3 abolitionists and 2 civilians.
                         */
                        break;

                    default:
                        DebugLogInvalidTalkerint();
                        break;
                }
                break;

            case "Combat":
                switch (manager.talkerint)
                {
                    case 1:
                        // Initiate a combat encounter with two civilians and two drunks.
                        break;

                    case 2:
                        // Initiate a combat encounter with two civilians and one drunk.
                        break;

                    case 3:
                        // Initiate a combat encounter with two civilians and two drunks.
                        break;

                    default:
                        DebugLogInvalidTalkerint();
                        break;
                }
                break;

            default:
                DebugLogInvalidTalkertype();
                break;
        }

        responsetext = GetResponse(manager.talkerint, manager.talkertype, 1);
    }

    public void Option2()
    {
        switch (manager.talkertype)
        {
            case "Event":
                switch (manager.talkerint)
                {
                    case 1:
                        if (relations.copRelations >= 25)
                        {
                            // End event.
                        }
                        else
                        {
                            // Initiate a combat encounter with one cop.
                        }
                        break;

                    case 2:
                        // End event.
                        break;

                    case 3:
                        // End event.
                        break;

                    case 4:
                        // End event.
                        break;

                    case 5:
                        // Skill check! Results in either +15 Cash/+2 Civ RP or just +1 Civ RP
                        // End event.
                        break;

                    case 6:
                        // End event.
                        break;

                    default:
                        DebugLogInvalidTalkerint();
                        break;
                }
                break;

            case "Negotiation":
                switch (manager.talkerint)
                {
                    case 1:
                        // Initiate a combat encounter with two civilians.
                        break;

                    case 2:
                        /* Negotiation P/I/B: 18/12/25
                         * SUCCESS: The crowd hears your words and begins to chant "Booze! Booze! Booze!" The abolitionists hightail it out of there. (+10 Dru RP, +5 Civ RP. -15 Abo RP)
                         * FAIL: The crowd becomes restless, opinion turning on you. The Abolitionist speaker smiles then yells "Get 'em!" (- 5 Abo RP, -5 Civ RP, +5 Dru RP) Begin combat with 3 abolitionists and 2 civilians.
                         */
                        break;

                    case 3:
                        /* Negotiation P/I/B: 12/16/25
                         * SUCCESS: The young attendant balks and lets you go. (-5 Civ RP, Full-Party Heal; +5 HP, +1 Tire or Paneling)
                         * FAIL: The attendant calls out for help, and three nearby policemen move in to support him. (-5 Civ RP, -5 Cop RP) Initiate a combat encounter with three cops.
                         */
                        break;

                    default:
                        DebugLogInvalidTalkerint();
                        break;
                }
                break;

            case "Combat":
                switch (manager.talkerint)
                {
                    case 1:
                        relations.booze -= 1;
                        relations.drunkardRelations += 10;
                        relations.civilianRelations += 5;
                        break;

                    default:
                        DebugLogInvalidTalkerint();
                        break;
                }
                break;

            default:
                DebugLogInvalidTalkertype();
                break;
        }

        responsetext = GetResponse(manager.talkerint, manager.talkertype, 2);
    }

    public void Option3()
    {
        switch (manager.talkertype)
        {
            case "Event":
                switch (manager.talkerint)
                {
                    case 1:
                        relations.civilianRelations -= 4;
                        relations.copRelations -= 2;
                        break;

                    case 2:
                        relations.cash -= 1;
                        relations.civilianRelations += 3;
                        break;

                    case 3:
                        relations.cash -= 5;
                        relations.civilianRelations -= 5;
                        break;

                    case 4:
                        // Full-Party Heal: +3 HP.
                        relations.civilianRelations -= 5;
                        break;

                    default:
                        DebugLogInvalidTalkerint();
                        break;
                }
                break;

            case "Negotiation":
                switch (manager.talkerint)
                {
                    case 2:
                        relations.cash += 25;
                        relations.prohibitionistsRelations -= 10;
                        relations.copRelations -= 5;
                        relations.norwegianMobRelations += 10;
                        relations.russianMobRelations += 10;
                        relations.sicilianMobRelations += 10;
                        // Initiate a combat encounter with 1 abolitionist, 1 civilian, 1 drunk, and 1 policeman.
                        break;

                    case 3:
                        relations.tires += 1;
                        relations.civilianRelations -= 5;
                        break;

                    default:
                        DebugLogInvalidTalkerint();
                        break;
                }
                break;

            case "Combat":
                Debug.Log("There's no Combat option set!");
                break;

            default:
                DebugLogInvalidTalkertype();
                break;
        }

        responsetext = GetResponse(manager.talkerint, manager.talkertype, 1);
    }

    public void Option4()
    {
        // TODO: THIS METHOD SEEMED LARGELY UNIMPLEMENTED. I'll leave a some skeleton work here, but 
        switch (manager.talkertype)
        {
            case "Event":
                switch (manager.talkerint)
                {
                    case 1:
                        // LOGIC
                        break;

                    case 2:
                        // LOGIC
                        break;

                    case 3:
                        // LOGIC
                        break;

                    default:
                        DebugLogInvalidTalkerint();
                        break;
                }
                break;

            case "Negotiation":
                switch (manager.talkerint)
                {
                    case 1:
                        //LOGIC
                        break;

                    case 2:
                        // LOGIC
                        break;

                    case 3:
                        // LOGIC
                        break;

                    default:
                        DebugLogInvalidTalkerint();
                        break;
                }
                break;

            case "Combat":
                switch (manager.talkerint)
                {
                    case 1:
                        // LOGIC
                        break;

                    case 2:
                        // LOGIC
                        break;

                    case 3:
                        // LOGIC
                        break;

                    default:
                        DebugLogInvalidTalkerint();
                        break;
                }
                break;

            default:
                DebugLogInvalidTalkertype();
                break;
        }

        responsetext = GetResponse(manager.talkerint, manager.talkertype, 1);

        // DAVID, YOUR CODE ENDS HERE DUMBASS - David

        if (manager.talkertype == "")
        {

        }
        responsetext = GetResponse(manager.talkerint, manager.talkertype, 4);
    }

    void DebugLogInvalidTalkertype()
    {
        Debug.Log("Invalid talkertype. Check to make sure the spelling is correct!");
    }
    
    void DebugLogInvalidTalkerint()
    {
        Debug.Log("Invalid talkerint. Check to make sure the number is correct!");
    }

}
