using UnityEngine;
using DG.Tweening;

public class TweenFloating : MonoBehaviour
{
    [SerializeField] float floatingScale = 0.2f;
    [SerializeField] float scaleTime = 0.5f;
    [SerializeField] float updownAmount = 50;
    [SerializeField] float moveTime = 1;
    private void OnEnable()
    {
        Vector3 newScale = new Vector3(transform.localScale.x + floatingScale, transform.localScale.y - floatingScale);
        transform.DOScale(newScale, scaleTime).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InOutSine);
        transform.DOLocalMoveY(transform.localPosition.y - updownAmount, moveTime).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InOutSine);
    }

    private void OnDisable()
    {
        transform.DOKill();
    }
}
