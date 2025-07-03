using UnityEngine;
using Newtonsoft.Json;

public static class SaveManager
{
    private const string SAVE_KEY = "GameSaveData";
    private static GameSaveData _current;

    public static GameSaveData Current
    {
        get
        {
            if (_current == null)
                Load();
            return _current;
        }
    }

    public static void InitializeDefault()
    {
        _current = new GameSaveData
        {
            money = 1000,
            foodCount = 20,
            funCount = 20,
            healthCount = 20,
            dropFood = 2,
            dropFun = 2,
            dropHealth = 2,
            foodDrainSpeed = 10f,
            funDrainSpeed = 10f,
            healthDrainSpeed = 10f,
            costFoodSpeedUpgrade = 100,
            costFoodRateUpgrade = 1000,
            gameExists = false
        };
    }

    public static void Save()
    {
        string json = JsonConvert.SerializeObject(_current);
        PlayerPrefs.SetString(SAVE_KEY, json);
        PlayerPrefs.Save();
        Debug.Log("Путь к сохранениям: " + Application.persistentDataPath);
    }

    public static void Load()
    {
        if (PlayerPrefs.HasKey(SAVE_KEY))
        {
            string json = PlayerPrefs.GetString(SAVE_KEY);
            _current = JsonConvert.DeserializeObject<GameSaveData>(json);
        }
        else
        {
            InitializeDefault();
            Save();
        }
    }

    public static void DeleteSave()
    {
        PlayerPrefs.DeleteKey(SAVE_KEY);
        _current = null;
    }
}