using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.IO;
using System;

public class DataPersistenceManager : MonoBehaviour
{
    [Header("File Storage Config")]

    [SerializeField] private string fileName;

    private GameData gameData;

    private List<IDataPersistence> dataPersistenceObjects;

    private FileDataHandler dataHandler;

    public TitleScreen title;

    public static DataPersistenceManager Instance { get; private set; }

    
    private void Awake()
    {
        if (Instance != null)
        {
            Debug.Log("Found more than one Data persistence Manager");
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
        this.dataHandler = new FileDataHandler(Application.persistentDataPath, fileName);
        this.dataPersistenceObjects = FindAllDataPersistenceObjects();
        LoadGame();
    }

    private void Start()
    {
        this.dataHandler = new FileDataHandler(Application.persistentDataPath, fileName);
        this.dataPersistenceObjects = FindAllDataPersistenceObjects();
        LoadGame();
    }

    public void NewGame()
    {
        if (System.IO.File.Exists(Application.persistentDataPath + "/" + fileName))
        {
            System.IO.File.Delete(Application.persistentDataPath + "/" + fileName);
        }
        this.gameData = new GameData();
    }

    public void LoadGame()
    {
        //TODO - load saved data from GameData
        this.gameData = dataHandler.Load();

        //if no data can be loaded create new game
        if (this.gameData == null)
        {
            Debug.Log("No data was found.");
            if(title != null)
            {
                title.CanContinue(false);
            }
            
            NewGame();
        }
        //pushed load data to other scripts
        foreach (IDataPersistence dataPersistenceObj in dataPersistenceObjects)
        {
            dataPersistenceObj.LoadData(gameData);
        }

        Debug.Log("game is loaded");
    }

    public void SaveGame()
    {
        //TODO - get data from other scripts
        foreach (IDataPersistence dataPersistenceObj in dataPersistenceObjects)
        {
            dataPersistenceObj.SaveData(ref gameData);
        }

        //TODO - save to file
        dataHandler.Save(gameData);
        Debug.Log("game is saved");
    }

    private void OnApplicationQuit()
    {
        SaveGame();
    }

    private List<IDataPersistence> FindAllDataPersistenceObjects()
    {
        IEnumerable<IDataPersistence> dataPersistenceObjects = FindObjectsOfType<MonoBehaviour>().OfType<IDataPersistence>();

        return new List<IDataPersistence>(dataPersistenceObjects);
    }
}
