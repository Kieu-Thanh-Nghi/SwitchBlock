using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SwitchColor : MonoBehaviour
{
    [SerializeField] Image image;
    [SerializeField] TMP_Text text;
    [SerializeField] internal bool isBlack;

    internal void ChangeColor(Color theColor)
    {
        if (text != null) text.color = theColor;
        if (image != null) image.color = theColor;
    }
}
