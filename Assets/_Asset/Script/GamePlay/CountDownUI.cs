using UnityEngine.UI;
using UnityEngine;
using System.Collections;

public class CountDownUI : MonoBehaviour
{
    [SerializeField] Image BigIcon;
    [SerializeField] CountDownEff[] effs;

    void DoBeforeCountDown(int index, float seconds)
    {
        CancelInvoke();
        BigIcon.gameObject.SetActive(true);
        BigIcon.sprite = effs[index].BigIcon;
        Invoke(nameof(turnOffBigIcon), 2);
        effs[index].gameObject.SetActive(true);
        effs[index].CountDownDuration = seconds;
    }

    internal bool is2XCounting(float seconds) => checkIsCounting(0, seconds);

    internal bool checkIsCounting(int index, float seconds)
    {
        effs[index].CountDownDuration = seconds;
        return effs[index].gameObject.activeSelf;
    }

    void DoAfterCountDown(int index)
    {
        effs[index].gameObject.SetActive(false);
    }
    void turnOffBigIcon() => BigIcon.gameObject.SetActive(false);
    bool CountingDown(int index)
    {
        effs[index].CountDownDuration -= Time.deltaTime;
        if (effs[index].CountDownDuration < 0) return true;
        return false;
    }
    internal IEnumerator doWhenGot2X(float seconds)
    {
        int index = 0;
        DoBeforeCountDown(index, seconds);
        yield return new WaitUntil(() => CountingDown(index));
        DoAfterCountDown(index);
    }

    internal IEnumerator doWhenGotMagnet(float seconds)
    {
        int index = 1;
        DoBeforeCountDown(index, seconds);
        yield return new WaitUntil(() => CountingDown(index));
        DoAfterCountDown(index);
    }

    internal IEnumerator doWhenGotRocket(float seconds)
    {
        int index = 2;
        DoBeforeCountDown(index, seconds);
        yield return new WaitUntil(() => CountingDown(index));
        DoAfterCountDown(index);
    }
}
