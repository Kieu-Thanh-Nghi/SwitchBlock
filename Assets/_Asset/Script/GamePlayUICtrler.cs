using TMPro;
using System.Collections;
using UnityEngine;

public class GamePlayUICtrler : MonoBehaviour
{
    [SerializeField] internal int plusPointEachTime = 1;
    [SerializeField] TMP_Text magnetQuantity, rocketQuantity, x2Quantity,
        point, rank, pointToHighRank;
    GamePlayCtrler gamePlayCtrler;
    int startPoint = 0;
    WaitForSeconds wait;
    // Start is called before the first frame update
    void OnEnable()
    {
        gamePlayCtrler = GamePlayCtrler.Instance;
        gamePlayCtrler.PlayerPoint = startPoint;
        point.text = startPoint.ToString();
        wait = new WaitForSeconds(gamePlayCtrler.secondToAddPoint);
        StartCoroutine(countPoint());
    }


    IEnumerator countPoint()
    {
        while (true)
        {
            gamePlayCtrler.PlayerPoint += plusPointEachTime;
            point.text = gamePlayCtrler.PlayerPoint.ToString();
            yield return wait;
        }
    }

    internal void DisableCounting()
    {
        StopAllCoroutines();
    }
}
