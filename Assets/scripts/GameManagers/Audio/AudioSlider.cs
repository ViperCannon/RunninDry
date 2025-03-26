using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class AudioSlider : MonoBehaviour
{
    [SerializeField]
    private AudioMixer audioMixer;
    [SerializeField]
    private Slider volumeSlider;
    PauseMenu pausemenu;

    private void Start()
    {
        if (GameObject.Find("PauseMenu") != null)
        {
            pausemenu = GameObject.Find("Pausemenu").GetComponent<PauseMenu>();
        }
        if (!PlayerPrefs.HasKey("masterVolume"))
        {
            PlayerPrefs.SetFloat("masterVolume", 1);
        }
        else
        {
            Load();
        }
    }

    private void Load()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("masterVolume");
    }
    public void changevolume()
    {
        AudioListener.volume = volumeSlider.value;
        Save();
    }

    private void Save()
    {
        PlayerPrefs.SetFloat("masterVolume", volumeSlider.value);
    }

    public void onChangeSlider()
    {
        audioMixer.SetFloat(transform.name, Mathf.Log10(GetComponent<Slider>().value) * 20);
        PlayerPrefs.SetFloat(transform.name, GetComponent<Slider>().value);
        Save();
    }
}
