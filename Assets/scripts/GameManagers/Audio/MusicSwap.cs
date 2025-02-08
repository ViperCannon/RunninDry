using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicSwap : MonoBehaviour
{
    [SerializeField]
    AudioSource musicPlayer;

    float musicTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            SwapMusic("Morning","FirstLevel_Negotiation_Updated");
        }
        if (Input.GetKeyDown(KeyCode.Keypad0))
        {
            SwapMusic("Morning", "FirstLevel_Normal_Updated");
        }
    }

    public void SwapMusic(string file, string clipName)
    {
        musicTime = musicPlayer.time;
        musicPlayer.clip = Resources.Load<AudioClip>("Music/"+ file + "/" + clipName);
        musicPlayer.time = musicTime;
        musicPlayer.Play();
    }

}
