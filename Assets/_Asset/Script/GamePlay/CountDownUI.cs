using UnityEngine.UI;
using UnityEngine;
using System.Collections;
using TMPro;
using DG.Tweening;

public class CountDownUI : MonoBehaviour
{
    [SerializeField] Image BigIcon;
    [SerializeField] CountDownEff[] effs;
    [SerializeField] TMP_Text pointCountingText;
    Color pointCountingColor;
    Sequence Seq;

    private void Start()
    {
        Seq = DOTween.Sequence();
        pointCountingColor = pointCountingText.color;
        turnOnBigIcon();
        Seq.Append(BigIcon.transform.DOShakeScale(1, 0.25f, randomness: 0, randomnessMode: ShakeRandomnessMode.Harmonic))
            .Append(BigIcon.DOFade(0, 2).SetEase(Ease.InOutFlash)).SetAutoKill(false);
        Seq.Complete();
    }

    void DoBeforeCountDown(int index, float seconds)
    {
        pointCountingText.color = effs[index].color;
        runBigIconEff(index);
        effs[index].gameObject.SetActive(true);
        effs[index].SetDuration(seconds);
    }
    void turnOnBigIcon()
    {
        Color temp = BigIcon.color;
        temp.a = 1;
        BigIcon.color = temp;
    }

    void runBigIconEff(int index)
    {
        BigIcon.sprite = effs[index].BigIcon;
        Seq.Restart();
    }

    internal bool is2XCounting(float seconds) => checkIsCounting(0, seconds);

    internal bool isRocketCounting(float seconds) => checkIsCounting(2, seconds);

    internal bool isMagnetCounting(float seconds) => checkIsCounting(1, seconds);


    internal bool checkIsCounting(int index, float seconds)
    {
        if (effs[index].gameObject.activeSelf)
        {
            runBigIconEff(index);
            effs[index].SetDuration(seconds);
            return true;
        }
        return false;
    }

    void DoAfterCountDown(int index)
    {
        effs[index].gameObject.SetActive(false);
        pointCountingText.color = pointCountingColor;
    }
    internal IEnumerator doWhenGot2X(float seconds)
    {
        int index = 0;
        DoBeforeCountDown(index, seconds);
        yield return new WaitUntil(() => effs[index].CountingDown());
        DoAfterCountDown(index); 
    }

    internal IEnumerator doWhenGotMagnet(float seconds)
    {
        int index = 1;
        DoBeforeCountDown(index, seconds);
        yield return new WaitUntil(() => effs[index].CountingDown());
        DoAfterCountDown(index);
    }

    internal IEnumerator doWhenGotRocket(float seconds)
    {
        int index = 2;
        DoBeforeCountDown(index, seconds);
        yield return new WaitUntil(() => effs[index].CountingDown());
        DoAfterCountDown(index);
    }
}
