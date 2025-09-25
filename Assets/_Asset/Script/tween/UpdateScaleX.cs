using UnityEngine;

public class UpdateScaleX : MonoBehaviour
{
    [SerializeField] float padding = 55;
    RectTransform thisRectTransform;

    private void Awake()
    {
        thisRectTransform = (RectTransform)transform;
    }
    internal void ChangeToChildSize(float childSizeX)
    {
        thisRectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, childSizeX + padding);
    }
}
