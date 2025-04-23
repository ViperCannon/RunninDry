using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class losescreen : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("DataPersistenceManager").GetComponent<DataPersistenceManager>().DeleteGame();
    }

    public void restart()
    {
        SceneManager.LoadScene(1);
    }

    public void quit()
    {
        SceneManager.LoadScene(0);
    }

    public void titlescreen()
    {
        SceneManager.LoadScene(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
