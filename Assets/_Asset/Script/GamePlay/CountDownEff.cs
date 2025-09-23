using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountDownEff : MonoBehaviour
{
    [SerializeField] internal Sprite BigIcon;
    [SerializeField] RectTransform CountDownBar;
    [SerializeField] internal Color color;
    float CountDownDuration, staticDuration;
    float barWidth;
    float minusWidthEachFrame;

    private void Awake()
    {
        barWidth = CountDownBar.rect.width;
    }

    internal void SetDuration(float seconds)
    {
        CountDownBar.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, barWidth);
        CountDownDuration = seconds;
        staticDuration = seconds;
    }
    internal bool CountingDown()
    {
        minusWidthEachFrame = barWidth * Time.deltaTime / staticDuration;
        CountDownBar.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 
            CountDownBar.rect.width - minusWidthEachFrame);
        CountDownDuration -= Time.deltaTime;
        if (CountDownDuration < 0) return true;
        return false;
    }
}
