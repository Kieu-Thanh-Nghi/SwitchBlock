using TMPro;
using UnityEngine;

public class DiamondUpdate : MonoBehaviour
{
    [SerializeField] LoadData data;
    private void OnEnable()
    {
        diamondsUpdate();
    }

    public void diamondsUpdate()
    {
        TMP_Text highScoreText = GetComponent<TMP_Text>();
        highScoreText.text = data.playerData.diamond.ToString();
    }
}
