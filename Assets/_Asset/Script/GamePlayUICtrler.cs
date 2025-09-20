using TMPro;
using System.Collections;
using UnityEngine;

public class GamePlayUICtrler : MonoBehaviour
{
    [SerializeField] StatisticCounting statisticCounting;
    [SerializeField] internal int plusPointEachTime = 1;
    [SerializeField] TMP_Text magnetQuantity, rocketQuantity, x2Quantity,
        point, rank, pointToHighRank;
    GamePlayCtrler gamePlayCtrler;
    // Start is called before the first frame update

    private void Awake()
    {
        pointUpdate();
        statisticCounting.DoWhenPointIcrease += pointUpdate;
    }

    void pointUpdate()
    {
        point.text = statisticCounting.PlayerPoint.ToString();
    }
}
