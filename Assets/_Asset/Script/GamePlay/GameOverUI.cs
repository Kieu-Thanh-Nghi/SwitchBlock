using TMPro;
using UnityEngine;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] Buysell buysell;
    [SerializeField] StatisticCounting statisticCounting;
    [SerializeField] int diamondForRevive = 100;
    [SerializeField]
    TMP_Text pointLastGame,
        highestPoint, 
        timeToUseRivive, currentDiamond;
    [SerializeField] int reviveTime = 5;

    private void OnEnable()
    {
        pointLastGame.text = statisticCounting.PlayerPoint.ToString();
        highestPoint.text = statisticCounting.PlayerPoint > statisticCounting.statisticData.HighScore ?
            statisticCounting.PlayerPoint.ToString() : statisticCounting.statisticData.HighScore.ToString();
        currentDiamond.text = buysell.currentDiamond().ToString();
        timeToUseRivive.text = reviveTime.ToString();
    }
    public void PayDiamondToRevive()
    {
        if (reviveTime <= 0) return;
        if (buysell.PayWithDiamonds(diamondForRevive))
        {
            GamePlayCtrler.Instance.RePlay(true);
            reviveTime--;
        }
    }
}
