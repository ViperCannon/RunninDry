using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleScreen : MonoBehaviour
{
    public GameObject mainCanvas;
    public GameObject creditsCanvas;
    public GameObject optionsCanvas;
    public Button continueButton;

    public AudioSource audioSource;
    public AudioClip[] transferSounds;

    // Start is called before the first frame update
    void Start()
    {
        creditsCanvas.SetActive(false);
        optionsCanvas.SetActive(false);
        mainCanvas.SetActive(true);
        audioSource = GetComponent<AudioSource>();
    }

    public void onStart()
    {
        MapGenerator.tutorial = true;
        MapGenerator.firstNegotiation = true;
        MapGenerator.firstCombat = true;
        MapGenerator.firstEvent = true;
        MapGenerator.firstPitStop = true;
        MapGenerator.firstShop = true;

    SceneManager.LoadScene(3);
    }
    public void OnQuit()
    {
        Application.Quit();
    }
    public void optionsOpen()
    {
        audioSource.PlayOneShot(transferSounds[Random.Range(0, transferSounds.Length)]);
        mainCanvas.SetActive(false);
        optionsCanvas.SetActive(true);
        
    }
    public void optionsClose()
    {
        audioSource.PlayOneShot(transferSounds[Random.Range(0, transferSounds.Length)]);
        optionsCanvas.SetActive(false);
        mainCanvas.SetActive(true);
        
    }

    public void creditsOpen()
    {
        audioSource.PlayOneShot(transferSounds[Random.Range(0, transferSounds.Length)]);
        mainCanvas.SetActive(false);
        creditsCanvas.SetActive(true);

    }
    public void creditsClose()
    {
        audioSource.PlayOneShot(transferSounds[Random.Range(0, transferSounds.Length)]);
        creditsCanvas.SetActive(false);
        mainCanvas.SetActive(true);
    }

    public void CanContinue(bool hasData)
    {
        continueButton.interactable = hasData;
    }
}
