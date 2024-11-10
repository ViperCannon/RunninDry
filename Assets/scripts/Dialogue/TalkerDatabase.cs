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

    public GameObject textbox;
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
}
