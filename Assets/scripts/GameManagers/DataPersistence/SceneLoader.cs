using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour, IDataPersistence
{
    public int sceneInt;

    public void LoadData(GameData data)
    {
        sceneInt = data.sceneInt;
    }

    public void LoadScene (int sceneID)
    {
        SceneManager.LoadScene(sceneID);
    }

    public void SceneSave()
    {
        sceneInt = SceneManager.GetActiveScene().buildIndex + 1;
    }

    public void SaveData(ref GameData data)
    {
        data.sceneInt = sceneInt;
    }
}
