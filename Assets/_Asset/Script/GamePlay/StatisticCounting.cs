using System;
using UnityEngine;
using UnityEngine.Events;

public class StatisticCounting : MonoBehaviour
{
    [SerializeField] internal int plusPointEachTime = 1;
    [SerializeField] internal float secondToAddPoint = 0.25f;
    [SerializeField] internal UnityEvent DoEventWhenPointIcrease;
    internal Action DoWhenPointIcrease;
    internal StatisticData statisticData;
    internal int PlayerPoint = 0;
    float timeOfAGame;
    int startPoint = 0;
    float timer;

    void StartTimer() => timer = Time.time;
    void StopTimer() => timeOfAGame = Time.time - timer;

    internal void SaveStatistic()
    {
        TimeSpan gameTimeSpan = TimeSpan.FromSeconds(timeOfAGame);
        if (PlayerPoint > statisticData.HighScore) statisticData.HighScore = PlayerPoint;
        statisticData.TotalPlayTime.AddTime(gameTimeSpan);
        if(gameTimeSpan > statisticData.HighestPlayTime.getTimeSpan())
        {
            statisticData.HighestPlayTime.SetTime(gameTimeSpan);
        }
        statisticData.NumberOfSessions++;
        if(statisticData.NumberOfSessions > 0)
        {
            statisticData.AveragePlayTime.SetTime
                (statisticData.TotalPlayTime.getTimeSpan() / statisticData.NumberOfSessions);
        }
        GamePlayCtrler.Instance.data.statistics = statisticData;
        GamePlayCtrler.Instance.data.SaveStatisticsData();
    }
    internal void RestartPoint()
    {
        PlayerPoint = startPoint;
        StartTimer();
    }
    internal void BonusPoint(int bonus)
    {
        PlayerPoint += bonus;
        DoEventWhenPointIcrease?.Invoke();
        DoWhenPointIcrease?.Invoke();
    }
    void OnEnable()
    {
        InvokeRepeating(nameof(countPoint), 0, secondToAddPoint);
    }

    void countPoint()
    {
        statisticData = GamePlayCtrler.Instance.data.statistics;
        PlayerPoint += plusPointEachTime;
        DoWhenPointIcrease.Invoke();
    }

    private void OnDisable()
    {
        CancelInvoke();
        StopTimer();
    }
}
