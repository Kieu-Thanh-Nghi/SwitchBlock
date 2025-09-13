using TMPro;
using System.Collections;
using UnityEngine;

public class GamePlayUICtrler : MonoBehaviour
{
    [SerializeField] float secondToAddPoint = 0.5f;
    [SerializeField] TMP_Text magnetQuantity, rocketQuantity, x2Quantity,
        point, rank, pointToHighRank;
    int startPoint = 0;
    int playerPoint = 0;
    WaitForSeconds wait;
    // Start is called before the first frame update
    void OnEnable()
    {
        playerPoint = startPoint;
        point.text = startPoint.ToString();
        wait = new WaitForSeconds(secondToAddPoint);
        StartCoroutine(countPoint());
    }

    IEnumerator countPoint()
    {
        while (true)
        {
            playerPoint++;
            point.text = playerPoint.ToString();
            yield return wait;
        }
    }
}
