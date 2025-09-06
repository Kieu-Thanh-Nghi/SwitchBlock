using System.IO;
using UnityEngine;
using System;

public class LoadData : MonoBehaviour
{
    string path = Path.Combine(Application.streamingAssetsPath, "Data.json");
    string statisticsPath = Path.Combine(Application.streamingAssetsPath, "Statistics.json");
    [SerializeField] internal PlayerData playerData = new();
    [SerializeField] internal StatisticData statistics = new();

    private void Reset()
    {
        
    }
    [ContextMenu("SetUp")]
    void SaveData()
    {
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
        Config();
    }
}

[Serializable]
public class StatisticData
{
    [SerializeField] internal int HighScore = 0;
    [SerializeField] internal TimeData TotalPlayTime = new TimeData(0, 0);
    [SerializeField] internal TimeData HighestPlayTime = new TimeData(0, 0);
    [SerializeField] internal TimeData AveragePlayTime = new TimeData(0, 0);
    [SerializeField] internal int NumberOfSessions = 0;
}

[Serializable]
public class TimeData
{
    TimeSpan span;
    [SerializeField] int minutes;
    internal int Minutes => minutes;
    [SerializeField] int seconds;
    internal int Seconds => seconds;
    public TimeData(int minute, int second)
    {
        span = new TimeSpan(0, minute, second);
        minutes = (int)span.TotalMinutes;
        seconds = span.Seconds;
    }

    internal void AddTime(TimeSpan timeToAdd)
    {
        span += timeToAdd;
        minutes = (int)span.TotalMinutes;
        seconds = span.Seconds;
    }
}
