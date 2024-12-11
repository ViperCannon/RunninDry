using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class AudioSlider : MonoBehaviour
{
    [SerializeField]
    private AudioMixer audioMixer;


    private void Start()
    {
        audioMixer.SetFloat(transform.name, Mathf.Log10(PlayerPrefs.GetFloat("Volume", 1) * 20));
    }

    public void onChangeSlider()
    {
        audioMixer.SetFloat(transform.name, Mathf.Log10(GetComponent<Slider>().value) * 20);
        PlayerPrefs.SetFloat(transform.name, GetComponent<Slider>().value);
        PlayerPrefs.Save();
    }
}
