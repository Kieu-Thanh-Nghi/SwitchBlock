using TMPro;
using UnityEngine.UI;
using UnityEngine;
using DG.Tweening;

public class WatchAdUI : MonoBehaviour
{
    [SerializeField] int timeCountDown;
    [SerializeField] TMP_Text textCount;
    [SerializeField] Button skipButton;
    [SerializeField] Vector2 firstPos, midPos, lastPos;
    int countingDownTime;

    private void OnEnable()
    {
        countingDownTime = timeCountDown;
        textCount.text = countingDownTime.ToString();
        slideIn();
    }

    void slideIn()
    {
        transform.localPosition = firstPos;
        transform.DOLocalMove(midPos, 0.5f).OnComplete(() => InvokeRepeating(nameof(CountingDown), 0, 1));
    }

    void CountingDown()
    {
        countingDownTime--;
        textCount.text = countingDownTime.ToString();
        if(countingDownTime < 0)
        {
            slideOut();
        }
    }

    void slideOut()
    {
        transform.DOLocalMove(lastPos, 0.5f).OnComplete(() => skipButton.onClick.Invoke());
        CancelInvoke();
    }

    private void OnDisable()
    {
        CancelInvoke();
    }
}
