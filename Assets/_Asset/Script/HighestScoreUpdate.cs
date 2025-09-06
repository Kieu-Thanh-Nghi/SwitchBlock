using TMPro;
using UnityEngine;

public class HighestScoreUpdate : MonoBehaviour
{
    [SerializeField] LoadData data;
    private void OnEnable()
    {
        TMP_Text highScoreText = GetComponent<TMP_Text>();
        highScoreText.text = data.statistics.HighScore.ToString();
    }
}
