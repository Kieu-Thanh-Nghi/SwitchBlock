using System.IO;
using UnityEngine;
using System;

public class LoadData : MonoBehaviour
{
    [SerializeField] string path;
    [SerializeField] string statisticsPath;
    [SerializeField] SkinStore store;
    [SerializeField] GameObject currentPlayer;
    [SerializeField] GameObject currentSkin;
    [SerializeField] internal PlayerData playerData;
    [SerializeField] internal StatisticData statistics;

    public static LoadData Instance { get; private set; }

    private void Reset()
    {
        
    }

    internal void SetUpNewPlayerSkin(SkinToPlay skinToPlay)
    {
        GameObject newSkin = Instantiate(skinToPlay.gameObject, currentPlayer.transform);
        newSkin.transform.localScale = currentSkin.transform.localScale;
        Destroy(currentSkin);
        currentSkin = newSkin;
        currentPlayer.GetComponent<Player>().SetSkin(currentSkin.GetComponent<SkinToPlay>());
    }

    [ContextMenu("SetUp")]
    void SaveData()
    {
        path = Path.Combine(Application.persistentDataPath, "Data.json");
        statisticsPath = Path.Combine(Application.persistentDataPath, "Statistics.json");
        SavePlayerData();
        SaveStatisticsData();
    }

    public void SavePlayerData()
    {
        string dataJson = JsonUtility.ToJson(playerData);
        File.WriteAllText(path, dataJson);
    }

    public void SaveStatisticsData()
    {
        string statisticsJson = JsonUtility.ToJson(statistics);
        File.WriteAllText(statisticsPath, statisticsJson);
    }

    [ContextMenu("Config")]
    public virtual void Config()
    {
        string dataJson = File.ReadAllText(path);
        PlayerData pd = JsonUtility.FromJson<PlayerData>(dataJson);
        playerData = pd;

        string statisticsJson = File.ReadAllText(statisticsPath);
        StatisticData sd = JsonUtility.FromJson<StatisticData>(statisticsJson);
        statistics = sd;
    }

    private void Awake()
    {
        if (!File.Exists(store.path))
        {
            store.Setup();
        }
        path = Path.Combine(Application.persistentDataPath, "Data.json");
        if (!File.Exists(path))
        {
            SavePlayerData();
        }
        statisticsPath = Path.Combine(Application.persistentDataPath, "Statistics.json");
        if (!File.Exists(statisticsPath))
        {
            SaveStatisticsData();
        }
        Config();
        store?.config();
        if (Instance != null && Instance != this)
        {
            Destroy(Instance.gameObject);
        }
        Instance = this;
    }
}

[Serializable]
public class StatisticData
{
    [SerializeField] internal int HighScore = 0;
    [SerializeField] internal TimeData TotalPlayTime = new();
    [SerializeField] internal TimeData HighestPlayTime = new();
    [SerializeField] internal TimeData AveragePlayTime = new();
    [SerializeField] internal int NumberOfSessions = 0;
}

[Serializable]
public class TimeData
{
    [SerializeField] int minutes;
    internal int Minutes => minutes;
    [SerializeField] int seconds;
    internal int Seconds => seconds;

    internal void AddTime(TimeSpan timeToAdd)
    {
        TimeSpan temp = new(0, minutes, seconds);
        temp = temp + timeToAdd;
        minutes = (int)temp.TotalMinutes;
        seconds = temp.Seconds;
    }

    internal TimeSpan getTimeSpan()
    {
        return new TimeSpan(0, minutes, seconds);
    }
}
