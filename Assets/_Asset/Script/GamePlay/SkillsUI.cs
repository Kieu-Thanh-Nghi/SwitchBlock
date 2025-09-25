using DG.Tweening;
using UnityEngine;

public class SkillsUI : MonoBehaviour
{
    [SerializeField] float posXIn, PosXOut;
    [SerializeField] float timeBeforeSlideOut;
    Tweener slideInTween, slideOutTween;
    bool isAvailable;
    // Start is called before the first frame update
    void Start()
    {
        transform.localPosition = new Vector2(PosXOut, transform.localPosition.y);
        slideInTween = transform.DOLocalMoveX(posXIn, 0.5f).SetAutoKill(false).OnComplete(() => slideOut());
        slideInTween.Complete();
        slideOutTween = transform.DOLocalMoveX(PosXOut, 0.5f).SetDelay(timeBeforeSlideOut).SetAutoKill(false);
    }

    public void SlideIn()
    {
        if (slideInTween.IsComplete()) 
        { 
            slideInTween.Restart();
        } 
    }

    void slideOut()
    {
        if(slideOutTween != null)
        {
            slideOutTween.Restart();
        }
    }

    private void OnDestroy()
    {
        transform.DOKill();
    }
}
