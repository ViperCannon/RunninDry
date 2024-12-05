using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class titlescreen : MonoBehaviour
{
    public int sceneID;

    public GameObject mainCanvas;
    public GameObject creditsCanvas;
    public GameObject optionsCanvas;
    // Start is called before the first frame update
    void Start()
    {
        creditsCanvas.SetActive(false);
        optionsCanvas.SetActive(false);
        mainCanvas.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onStart()
    {
        SceneManager.LoadScene(sceneID);
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
}
