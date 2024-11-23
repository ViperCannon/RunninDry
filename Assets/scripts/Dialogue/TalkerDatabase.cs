using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Collections.LowLevel.Unsafe;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEditor.Presets;
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
    relationshipframework relations;
    public void encounter(string type)
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
        relations = this.gameObject.GetComponent<relationshipframework>();
        manager = this.gameObject.GetComponent<GameManager>();
        string json = MyJsonData.text;
        MyTalkerData = JsonUtility.FromJson<TalkerDataJSON>(json);
        textbox.SetActive(false);
    }

    public void GetButtonData(int talkerId, string type)
    {
        for (int i = 0; i < MyTalkerData.Talkers.Length -1 ; ++i)
        {
            if (MyTalkerData.Talkers[i].TalkerType == type)
            {
                if (MyTalkerData.Talkers[i].TalkerId == talkerId)
                {
                    optionCount = MyTalkerData.Talkers[i].Optioncount;
                    optionstext1.text = MyTalkerData.Talkers[i].Option1;
                    optionstext2.text = MyTalkerData.Talkers[i].Option2;
                    optionstext3.text = MyTalkerData.Talkers[i].Option3;
                    optionstext4.text = MyTalkerData.Talkers[i].Option4;
                }
            }
        }
        for (int i = 0; i < optionCount; i++)
        {
            optionbuttons.transform.GetChild(i).gameObject.SetActive(true);
        }
    }

    public string Getresponse(int talkerId, string type, int optionnumber)
    {
        for (int i = 0; i < MyTalkerData.Talkers.Length; ++i)
        {
            if (MyTalkerData.Talkers[i].TalkerType == type)
            {
                if (MyTalkerData.Talkers[i].TalkerId == talkerId)
                {
                    if (optionnumber == 1)
                    {
                        return MyTalkerData.Talkers[i].Option1outcome;
                    }
                    else if (optionnumber == 2)
                    {
                        return MyTalkerData.Talkers[i].Option2outcome;
                    }
                    else if (optionnumber == 3)
                    {
                        return MyTalkerData.Talkers[i].Option3outcome;
                    }
                    else if(optionnumber == 4)
                    {
                        return MyTalkerData.Talkers[i].Option4outcome;
                    }
                }
            }
        }
        return "[NO_NAME_FOUND]";
    }

    public string GetTalkerName(int talkerId, string type)
    {
        for(int i = 0; i < MyTalkerData.Talkers.Length; ++i)
        {
            if (MyTalkerData.Talkers[i].TalkerType == type)
            {
                if (MyTalkerData.Talkers[i].TalkerId == talkerId)
                {
                    return MyTalkerData.Talkers[i].TalkerName;
                }
            }
        }
        return "[NO_NAME_FOUND]";
    }

    public string GetTalkerText(int talkerId, string type)
    {
        for (int i = 0; i < MyTalkerData.Talkers.Length; ++i)
        {
            if (MyTalkerData.Talkers[i].TalkerType == type)
            {
                if (MyTalkerData.Talkers[i].TalkerId == talkerId)
                {
                    return MyTalkerData.Talkers[i].TalkerText;
                }
            }
        }
        return "[NO_TEXT_FOUND]";
    }

    public void getResponse(int choicenumber)
    {
        text.text = responsetext;
        manager.continuebutton.SetActive(true);
        choiceint = choicenumber;
    }

    public void option1()
    {
        if (manager.talkertype == "Event")
        {
            if (manager.talkerint == 1)
            {
                if (relations.copRelations >= 40)
                {
                    relations.copRelations += 2;
                    relations.civilianRelations += 2;
                }
                else
                {
                    //start combat with 1 cop
                }
            }
            else if (manager.talkerint == 2)
            {
                relations.civilianRelations -= 5;
            }
            else if (manager.talkerint == 3)
            {
                relations.civilianRelations -= 2;
            }
            else if (manager.talkerint == 4)
            {
                //hp + 5
                //cash -2
                relations.civilianRelations += 3;
            }
            else if (manager.talkerint == 5)
            {
                //cash + 10
                relations.civilianRelations += 5;
                relations.copRelations -= 5;
            }
            else if (manager.talkerint == 6)
            {
                if (relations.civilianRelations >= 60)
                {
                    //she smiles, takes your assistance, and presses a bill into your hands(+2 Civ Rp, +3 Cash)
                    relations.civilianRelations += 2;
                }
                else if (relations.civilianRelations >=25 && relations.civilianRelations < 60)
                {
                    //If between 25 and 60, she smiles and takes your assistance (+2 Civ RP)
                    relations.civilianRelations += 2;
                }
                else if (relations.civilianRelations < 25)
                {
                    //she frowns and walks away(-2 Civ RP)
                    relations.civilianRelations -= 2;
                }
            }
        }
        else if (manager.talkertype == "Negotiation")
        {
            if (manager.talkerint == 1)
            {
                //Negotiation P/I/B: 14/8/10  On success, the man cools off, apologizes, and gets back in his car. On fail, your words worsen the situation, and he elbows one of your car windows in (-1 Paneling). He then hightails it out of there
                //manager.endEncounter();
            }
            else if (manager.talkerint == 2)
            {
                //Negotiation P/I/B: 12, 16, 25
                //On success: The crowd hears your words and begins to chant "Booze! Booze! Booze!" The abolitionists hightail it out of there. +10 Dru RP, +5 Civ RP. -15 Abo RP.
                //On fail: The crowd becomes restless, opinion turning on you.The Abolitionist speaker smiles then yells "Get 'em!" - 5 Abo RP, -5 Civ RP, +5 Dru RP. Begin combat with 3 abolitionists and 2 civilians.
            }
            else if (manager.talkerint == 3)
            {
                //-15 Cash, +5 HP to all party members, +1 tire or paneling
                relations.civilianRelations += 2;
            }
        }
        else if (manager.talkertype == "Combat")
        {
            if (manager.talkerint == 1)
            {
                //begin combat with 2 civs and 2 drunks
            }
            else if (manager.talkerint == 2)
            {
                //begin combat with 2 civs 1 drunk
            }
            else if (manager.talkerint == 3)
            {
                //combat with 4 abolitionists
            }
        }
        responsetext = Getresponse(manager.talkerint, manager.talkertype, 1);
    }
    public void option2()
    {
        if (manager.talkertype == "Event")
        {
            if (manager.talkerint == 1)
            {
                if (relations.copRelations >= 25)
                {
                    //manager.endEncounter();
                }
                else
                {
                    //start combat with 1 cop
                }
            }
            else if (manager.talkerint == 2)
            {
                //manager.endEncounter();
            }
            else if (manager.talkerint == 3)
            {
               //manager.endEncounter();
            }
            else if (manager.talkerint == 4)
            {
                //manager.endEncounter();
            }
            else if (manager.talkerint == 5)
            {
                //skill check to add either +15 cash and 2 civ rp or just + 1 civ rp
                //manager.endEncounter();
            }
            else if (manager.talkerint == 6)
            {
                //manager.endEncounter();
            }
        }
        else if (manager.talkertype == "Negotiation")
        {
            if (manager.talkerint == 1)
            {
                //Begin combat with 2 civilians.
            }
            else if (manager.talkerint == 2)
            {
                //Negotiation P/I/B: 18, 12, 25
                //On success: The crowd hears your words and begins to chant "Booze! Booze! Booze!" The abolitionists hightail it out of there. +10 Dru RP, +5 Civ RP. -15 Abo RP.
                //On fail: The crowd becomes restless, opinion turning on you.The Abolitionist speaker smiles then yells "Get 'em!" - 5 Abo RP, -5 Civ RP, +5 Dru RP. Begin combat with 3 abolitionists and 2 civilians.
            }
            else if (manager.talkerint == 3)
            {
                //Negotiation P/I/B: 11/8/13
                //On success: The young attendant balks and lets you go. -5 Civ RP, +5 HP to all party members, +1 tire or paneling
                //On fail: The attendant calls out for help, and three nearby policemen move in to support him. - 5 Civ and Cop RP, begin combat with 3 cops
            }
        }
        else if (manager.talkertype == "Combat")
        {
            if (manager.talkerint == 1)
            {
                //-1 booze, +10 Drunks RP, +5 Civ RP
                relations.drunkardRelations += 10;
                relations.civilianRelations += 5;
            }
            else if (manager.talkerint == 3)
            {
                relations.prohibitionistsRelations -= 15;
                relations.civilianRelations -= 5;
                //-1 paneling
            }
        }
        responsetext = Getresponse(manager.talkerint, manager.talkertype, 2);
    }
    public void option3()
    {
        if (manager.talkertype == "Event")
        {
            if (manager.talkerint == 1)
            {
                relations.civilianRelations -= 4;
                relations.copRelations -= 2;
            }
            else if (manager.talkerint == 2)
            {
                //cash -1
                relations.civilianRelations += 3;
            }
            else if (manager.talkerint == 3)
            {
                //cash -5
                relations.civilianRelations -= 5;
            }
            else if (manager.talkerint == 4)
            {
                //hp +3
                relations.civilianRelations -= 5;
            }
        }
        else if (manager.talkertype == "Negotiation")
        {
            if (manager.talkerint == 2)
            {
                //(+25 Cash).
                //Begin combat with 1 abolitionist, 1 civilian, 1 drunk, and 1 policeman.
                relations.prohibitionistsRelations -= 10;
                relations.copRelations -= 5;
                relations.norwegianMobRelations += 10;
                relations.russianMobRelations += 10;
                relations.sicilianMobRelations += 10;
            }
            else if (manager.talkerint == 3)
            {
                //+1 tire or paneling
                relations.civilianRelations -= 5;
            }
        }
        responsetext = Getresponse(manager.talkerint, manager.talkertype, 3);
    }
    public void option4()
    {
        if (manager.talkertype == "")
        {

        }
        responsetext = Getresponse(manager.talkerint, manager.talkertype, 4);
    }

}
