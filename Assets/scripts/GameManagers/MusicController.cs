using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    [SerializeField]
    AudioSource music;

    public AudioClip[] tracks;

    public void UpdateMusic(string type)
    {
        switch (type)
        {
            case "Combat":
                music.clip = tracks[1];
                break;

            case "Negotiation":
                music.clip = tracks[2];
                break;

            default:
                music.clip = tracks[0];
                break;
        }
    }
}
