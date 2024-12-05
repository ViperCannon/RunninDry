using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pausemenu : MonoBehaviour
{
    public int sceneID;

    public GameObject mainCanvas;
    public GameObject optionsCanvas;
    // Start is called before the first frame update
    void Start()
    {
        optionsCanvas.SetActive(false);
        mainCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            onPause();
        }
    }
    void onPause()
    {
        Time.timeScale = 0.0f;
        mainCanvas.SetActive(true);
    }

    public void onResume()
    {
        Time.timeScale = 1.0f;
        mainCanvas.SetActive(false);
    }
    public void onleave()
    {
        SceneManager.LoadScene(sceneID);
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

}
