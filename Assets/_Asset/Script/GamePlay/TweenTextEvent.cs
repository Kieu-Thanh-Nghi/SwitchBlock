using DG.Tweening;
using UnityEngine;

public class TweenTextEvent : MonoBehaviour
{
    Tweener textTween;
    private void Awake()
    {
        textTween = transform.DOScale(transform.localScale * 1.2f, 0.1f).SetLoops(2, LoopType.Yoyo).SetAutoKill(false);
        textTween.Complete();
    }
    public void DoTextTween()
    {
        textTween.Restart();
    }

    private void OnDestroy()
    {
        textTween.Kill();
    }
}
