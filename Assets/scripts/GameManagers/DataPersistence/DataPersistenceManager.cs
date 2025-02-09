using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataPersistenceManager : MonoBehaviour
{
    private GameData gameData;

    public static DataPersistenceManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.Log("Found more than one Data persistence Manager");
        }
        else
        {
            Instance = this;
        }
    }

    public void NewGame()
    {
        this.gameData = new GameData();
    }

    public void LoadGame()
    {
        //TODO - load saved data from GameData
        //if no data can be loaded create new game
        if (this.gameData == null)
        {
            Debug.Log("No data was found.");
            NewGame();
        }
        //pushed load data to other scripts
    }

    public void SaveGame()
    {
        //TODO - get data from other scripts

        //TODO - save to file
    }
}
