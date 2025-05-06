using UnityEngine;
using TMPro;

public class ScoreBoardUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI lastScoreText;
    [SerializeField] private TextMeshProUGUI bestScoreText;

    void Start()
    {
        int lastScore = PlayerPrefs.GetInt("LastScore", 0);
        int bestScore = PlayerPrefs.GetInt("BestScore", 0);

        lastScoreText.text = $"최근 점수: {lastScore}";
        bestScoreText.text = $"최고 점수: {bestScore}";
    }
}
