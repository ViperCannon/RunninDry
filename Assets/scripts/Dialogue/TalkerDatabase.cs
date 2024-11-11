using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

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
    public GameObject textbox;
    public GameObject optionbuttons;
    public TMP_Text optionstext1;
    public TMP_Text optionstext2;
    public TMP_Text optionstext3;
    public TMP_Text optionstext4;
    public TMP_Text text;
    public TMP_Text talkername;
    public RawImage talkerimage;
    GameManager manager;
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

    public void option1()
    {
        if (manager.talkertype == "")
        {

        }
    }
    public void option2()
    {
        if (manager.talkertype == "")
        {

        }
    }
    public void option3()
    {
        if (manager.talkertype == "")
        {

        }
    }
    public void option4()
    {
        if (manager.talkertype == "")
        {

        }
    }

}
