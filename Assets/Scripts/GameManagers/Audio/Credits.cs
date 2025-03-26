using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Credits : MonoBehaviour
{
    [SerializeField]
    AudioSource musicPlayer;
    [SerializeField]
    AudioClip creditsMusic;
    AudioClip titlemusic;
    float musicTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        musicPlayer.time = musicTime;
        titlemusic = musicPlayer.clip;
    }


    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            SwapMusic("Morning", "FirstLevel_Negotiation_Updated");
        }
        if (Input.GetKeyDown(KeyCode.Keypad0))
        {
            SwapMusic("Morning", "FirstLevel_Normal_Updated");
        }*/
    }
    
    public void titleMusic()
    {
        musicPlayer.clip = titlemusic;
        musicPlayer.time = musicTime;
        musicPlayer.Play();
    }

    public void SwapMusic()
    {
        musicTime = musicPlayer.time;
        musicPlayer.clip = creditsMusic;
        //musicPlayer.time = musicTime;
        musicPlayer.Play();
    }
}
