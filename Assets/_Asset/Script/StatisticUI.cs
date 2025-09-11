using TMPro;
using UnityEngine;
using System;

public class StatisticUI : MonoBehaviour
{
    [SerializeField] LoadData data;
    [SerializeField]
    TMP_Text
        totalPlayTime,
        highestPlayTime,
        highScore,
        averagePlayTime,
        sessions;
    StatisticData statisticData;
    private void OnEnable()
    {
        statisticData = data.statistics;
        string fomat = @"mm\:ss";
        TimeSpan Temp = statisticData.TotalPlayTime.getTimeSpan();
        totalPlayTime.text = Temp.TotalHours < 1 ? Temp.ToString(fomat) : Temp.ToString();

        Temp = statisticData.HighestPlayTime.getTimeSpan();
        highestPlayTime.text = Temp.TotalHours < 1 ? Temp.ToString(fomat) : Temp.ToString();

        Temp = statisticData.AveragePlayTime.getTimeSpan();
        averagePlayTime.text = Temp.TotalHours < 1 ? Temp.ToString(fomat) : Temp.ToString();

        highScore.text = statisticData.HighScore.ToString();
        sessions.text = statisticData.NumberOfSessions.ToString();
    }
}
