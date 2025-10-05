using DG.Tweening;
using UnityEngine;

public class TweenSlideIn : MonoBehaviour
{
    [SerializeField] float first_pos_X;
    Vector2 firstPos, lastPos;
    private void OnEnable()
    {
        lastPos = transform.localPosition;
        firstPos = new Vector2(lastPos.x + first_pos_X, lastPos.y);
        transform.localPosition = firstPos;
        transform.DOLocalMove(lastPos, 1);
    }

    private void OnDestroy()
    {
        transform.DOKill();
    }
}
