using DG.Tweening;
using UnityEngine;

public class TweenSlideIn : MonoBehaviour
{
    [SerializeField] Vector2 firstPos, lastPos;
    private void OnEnable()
    {
        transform.localPosition = firstPos;
        transform.DOLocalMove(lastPos, 1);
    }

    private void OnDestroy()
    {
        transform.DOKill();
    }
}
