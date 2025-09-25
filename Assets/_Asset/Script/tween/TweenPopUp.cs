using DG.Tweening;
using UnityEngine;

public class TweenPopUp : MonoBehaviour
{
    [SerializeField] float popUpTime = 0.5f;
    Vector2 currentScale;
    private void OnEnable()
    {
        PopUp();
    }

    public void PopUp()
    {
        currentScale = transform.localScale;
        transform.localScale = Vector2.zero;
        transform.DOScale(currentScale, popUpTime).SetEase(Ease.OutBack);
    }

    private void OnDestroy()
    {
        transform.DOKill();
    }
}
