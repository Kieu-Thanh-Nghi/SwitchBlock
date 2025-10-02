using System;
using UnityEngine;
using UnityEngine.Events;

public class StatisticCounting : MonoBehaviour
{
    [SerializeField] internal int plusPointEachTime = 1;
    [SerializeField] internal float secondToAddPoint = 0.25f;
    [SerializeField] internal UnityEvent DoEventWhenPointIcrease;
    [SerializeField] LeaderboardManager leaderboard;
    internal Action DoWhenPointIcrease;
    internal StatisticData statisticData;
    internal int PlayerPoint = 0, nextRank, pointToNextRank, pointOfNextRank;
    float timeOfAGame;
    int startPoint = 0;
    float timer;
    int topScoresCount;

    void StartTimer() => timer = Time.time;
    void StopTimer() => timeOfAGame = Time.time - timer;

    internal void SaveStatistic()
    {
        TimeSpan gameTimeSpan = TimeSpan.FromSeconds(timeOfAGame);
        if (PlayerPoint > statisticData.HighScore) { 
            statisticData.HighScore = PlayerPoint;
            leaderboard.ReportScore(PlayerPoint);
        } 
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
        enabled = true;
        StartTimer();
    }

    void CheckNextRank(int score)
    {
        topScoresCount = statisticData.Top3Score.Count;
        if (topScoresCount <= 1)
        {
            nextRank = 1;
            pointToNextRank = 0;
        }
        for(int i = topScoresCount - 1; i >= 0; i--)
        {
            if(score < statisticData.Top3Score[i])
            {
                nextRank = i + 1;
                pointOfNextRank = statisticData.Top3Score[i];
                return;
            }
        }
    }
    internal void BonusPoint(int bonus)
    {
        PlayerPoint += bonus;
        DoEventWhenPointIcrease?.Invoke();
        DoWhenPointIcrease?.Invoke();
    }
    void OnEnable()
    {
        statisticData = GamePlayCtrler.Instance.data.statistics;
        CheckNextRank(statisticData.HighScore);
        InvokeRepeating(nameof(countPoint), 0, secondToAddPoint);
    }

    void countPoint()
    {
        PlayerPoint += plusPointEachTime;
        if(pointToNextRank > 0)
        {
            pointToNextRank = pointOfNextRank - PlayerPoint;
            if (pointToNextRank < 0) pointToNextRank = 0;
        }
        else if(nextRank > 1)
        {
            CheckNextRank(PlayerPoint);
        }
        DoWhenPointIcrease.Invoke();
    }

    private void OnDisable()
    {
        CancelInvoke();
        StopTimer();
    }
}
