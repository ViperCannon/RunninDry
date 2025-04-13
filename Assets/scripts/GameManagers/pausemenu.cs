using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public int sceneID;

    public DataPersistenceManager datamanager;

    public GameObject mainCanvas;
    public GameObject optionsCanvas;
    // Start is called before the first frame update
    void Start()
    {
        datamanager = GameObject.Find("DataPersistenceManager").GetComponent<DataPersistenceManager>();
        optionsCanvas.SetActive(false);
        mainCanvas.SetActive(false);
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            OnPause();
        }
    }
    void OnPause()
    {
        Time.timeScale = 0.0f;
        mainCanvas.SetActive(true);
    }

    public void OnResume()
    {
        Time.timeScale = 1.0f;
        mainCanvas.SetActive(false);
    }
    public void Onleave()
    {
        datamanager.SaveGame();
        SceneManager.LoadScene(sceneID);
    }
    public void OptionsOpen()
    {
        mainCanvas.SetActive(false);
        optionsCanvas.SetActive(true);
    }
    public void OptionsClose()
    {
        optionsCanvas.SetActive(false);
        mainCanvas.SetActive(true);
    }

}
