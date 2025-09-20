using System.Collections;
using System;
using UnityEngine;

public class StatisticCounting : MonoBehaviour
{
    [SerializeField] internal int plusPointEachTime = 1;
    [SerializeField] internal float secondToAddPoint = 0.25f;
    internal Action DoWhenPointIcrease;
    internal int PlayerPoint = 0;
    int startPoint = 0;

    private void Awake()
    {
        PlayerPoint = startPoint;
    }

    internal void RestartPoint()
    {
        PlayerPoint = startPoint;
    }
    internal void BonusPoint(int bonus)
    {
        PlayerPoint += bonus;
        DoWhenPointIcrease.Invoke();
    }
    void OnEnable()
    {
        InvokeRepeating(nameof(countPoint), 0, secondToAddPoint);
    }

    void countPoint()
    {
        PlayerPoint += plusPointEachTime;
        DoWhenPointIcrease.Invoke();
    }

    private void OnDisable()
    {
        CancelInvoke();
    }
}
