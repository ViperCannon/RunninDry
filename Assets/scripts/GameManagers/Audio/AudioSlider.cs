using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class AudioSlider : MonoBehaviour
{
    [SerializeField]
    private AudioMixer audioMixer;
    [SerializeField]
    private Slider volumeSlider;


    private void Start()
    {
        if (!PlayerPrefs.HasKey("musicVolume"))
        {
            PlayerPrefs.SetFloat("musicVolume", 1);
        }
        else
        {
            Load();
        }
    }

    private void Load()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("musicVolume");
    }
    public void changevolume()
    {
        AudioListener.volume = volumeSlider.value;
        Save();
    }

    private void Save()
    {
        PlayerPrefs.SetFloat("musicVolume", volumeSlider.value);
    }

    public void onChangeSlider()
    {
        audioMixer.SetFloat(transform.name, Mathf.Log10(GetComponent<Slider>().value) * 20);
        PlayerPrefs.SetFloat(transform.name, GetComponent<Slider>().value);
        PlayerPrefs.Save();
    }
}
