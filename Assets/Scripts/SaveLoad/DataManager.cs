using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    [SerializeField] private PlayerSettings playerSettings;

    private const string SaveKey = "GameData";

    public static DataManager instance;

    private GameData gameData;

    private List<IDataManager> dataManagerObjects;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("Multiple data managers");
        }
        else
        {
            instance = this;
        }
    }

    private void Start()
    {
        dataManagerObjects = FindAllDataManagerObjects();
        LoadGame();
    }

    public void NewGame()
    {
        gameData = new GameData(playerSettings);
    }

    public void LoadGame()
    {
        if (PlayerPrefs.HasKey(SaveKey))
        {
            string json = PlayerPrefs.GetString(SaveKey);
            gameData = JsonUtility.FromJson<GameData>(json);
        }
        else
        {
            Debug.Log("No data. Loading default values");
            NewGame();
        }

        foreach (IDataManager dataManager in dataManagerObjects)
        {
            dataManager.LoadData(gameData);
        }
    }

    public void SaveGame()
    {
        foreach (IDataManager dataManager in dataManagerObjects)
        {
            dataManager.SaveData(gameData);
        }

        string json = JsonUtility.ToJson(gameData);
        PlayerPrefs.SetString(SaveKey, json);
        PlayerPrefs.Save();
    }


    private List<IDataManager> FindAllDataManagerObjects()
    {
        IEnumerable<IDataManager> dataManagerObjects = FindObjectsByType<MonoBehaviour>(FindObjectsSortMode.None).OfType<IDataManager>();

        return new List<IDataManager>(dataManagerObjects);
    }

    public GameData GetGameData()
    {
        return gameData;
    }

}
