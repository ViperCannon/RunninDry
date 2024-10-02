using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioSlider : MonoBehaviour
{
    [SerializeField]
    private AudioMixer audioMixer;
    [SerializeField]
    private AudioSource audioSource;
    [SerializeField]
    private AudioMixMode mixMode;

    private void Start()
    {
        audioMixer.SetFloat("Volume", Mathf.Log10(PlayerPrefs.GetFloat("Volume", 1) * 20));
    }

    public void onChangeSlider(float Value)
    {
        switch(mixMode)
        {
            case AudioMixMode.LogarithmicMixerVolume:
                audioMixer.SetFloat("Volume", Mathf.Log10(Value) * 20);
                PlayerPrefs.SetFloat("Volume", Value);
                PlayerPrefs.Save();
                break;
        }
    }

    public enum AudioMixMode
    {
        LogarithmicMixerVolume
    }
}
