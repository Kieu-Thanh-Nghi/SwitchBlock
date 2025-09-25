using TMPro;
using UnityEngine;

public class DiamondUpdate : MonoBehaviour
{
    [SerializeField] Buysell buysell;
    TMP_Text highScoreText;
    private void OnEnable()
    {
        buysell.DoWhenDiamondChange += diamondsUpdate;
        highScoreText = GetComponent<TMP_Text>();
    }

    private void Start()
    {
        diamondsUpdate();
        //Canvas.ForceUpdateCanvases();
    }

    public void diamondsUpdate()
    {
        highScoreText.text = buysell.currentDiamond().ToString();
    }

    private void OnDisable()
    {
        buysell.DoWhenDiamondChange -= diamondsUpdate;
    }
}
