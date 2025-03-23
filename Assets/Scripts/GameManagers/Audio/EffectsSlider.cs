using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class EffectsSlider : MonoBehaviour
{
    [SerializeField]
    private AudioMixer audioMixer;
    [SerializeField]
    private Slider volumeSlider;
    PauseMenu pausemenu;

    private void Start()
    {
        pausemenu = GameObject.Find("Pausemenu").GetComponent<PauseMenu>();
        if (!PlayerPrefs.HasKey("effectsVolume"))
        {
            PlayerPrefs.SetFloat("effectsVolume", 1);
        }
        else
        {
            Load();
        }
    }

    private void Load()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("effectsVolume");
    }
    public void changevolume()
    {
        AudioListener.volume = volumeSlider.value;
        Save();
    }

    private void Save()
    {
        PlayerPrefs.SetFloat("effectsVolume", volumeSlider.value);
    }

    public void onChangeSlider()
    {
        audioMixer.SetFloat(transform.name, Mathf.Log10(GetComponent<Slider>().value) * 20);
        PlayerPrefs.SetFloat(transform.name, GetComponent<Slider>().value);
        Save();
    }
}
