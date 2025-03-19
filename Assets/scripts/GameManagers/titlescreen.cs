using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleScreen : MonoBehaviour
{
    public GameObject mainCanvas;
    public GameObject creditsCanvas;
    public GameObject optionsCanvas;
    public Button continueButton;

    // Start is called before the first frame update
    void Start()
    {
        creditsCanvas.SetActive(false);
        optionsCanvas.SetActive(false);
        mainCanvas.SetActive(true);
    }

    public void onStart()
    {
        MapGenerator.tutorial = true;

        SceneManager.LoadScene(3);
    }
    public void OnQuit()
    {
        Application.Quit();
    }
    public void optionsOpen()
    {
        mainCanvas.SetActive(false);
        optionsCanvas.SetActive(true);
    }
    public void optionsClose()
    {
        optionsCanvas.SetActive(false);
        mainCanvas.SetActive(true);
    }

    public void creditsOpen()
    {
        mainCanvas.SetActive(false);
        creditsCanvas.SetActive(true);
    }
    public void creditsClose()
    {
        creditsCanvas.SetActive(false);
        mainCanvas.SetActive(true);
    }

    public void CanContinue(bool hasData)
    {
        continueButton.interactable = hasData;
    }
}
