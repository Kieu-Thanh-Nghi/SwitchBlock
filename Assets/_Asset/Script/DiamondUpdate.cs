using TMPro;
using UnityEngine;

public class DiamondUpdate : MonoBehaviour
{
    [SerializeField] Buysell buysell;
    private void OnEnable()
    {
        diamondsUpdate();
        buysell.DoWhenDiamondChange += diamondsUpdate;
    }

    public void diamondsUpdate()
    {
        TMP_Text highScoreText = GetComponent<TMP_Text>();
        highScoreText.text = buysell.currentDiamond().ToString();
    }

    private void OnDisable()
    {
        buysell.DoWhenDiamondChange -= diamondsUpdate;
    }
}
