using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class WatchAdUI : MonoBehaviour
{
    [SerializeField] int timeCountDown;
    [SerializeField] TMP_Text textCount;
    [SerializeField] Button skipButton;
    int countingDownTime;

    private void OnEnable()
    {
        countingDownTime = timeCountDown;
        textCount.text = countingDownTime.ToString();
        InvokeRepeating(nameof(CountingDown), 0.5f, 1);
    }

    void CountingDown()
    {
        countingDownTime--;
        textCount.text = countingDownTime.ToString();
        if(countingDownTime < 0)
        {
            skipButton.onClick.Invoke();
            CancelInvoke();
        }
    }

    private void OnDisable()
    {
        CancelInvoke();
    }
}
