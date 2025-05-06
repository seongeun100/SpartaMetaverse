using UnityEngine;
using TMPro;

// 점수 관리
public class ScoreBoardUI : MonoBehaviour
{
    // 인스펙터에서 연결할 최근 점수 텍스트, 최고 점수 텍스트
    [SerializeField] private TextMeshProUGUI lastScoreText;
    [SerializeField] private TextMeshProUGUI bestScoreText;

    void Start()
    {
        // PlayerPrefs에서 각 점수 가져오기 없으면 0
        int lastScore = PlayerPrefs.GetInt("LastScore", 0);
        int bestScore = PlayerPrefs.GetInt("BestScore", 0);

        // 텍스트 갱신
        lastScoreText.text = $"최근 점수: {lastScore}";
        bestScoreText.text = $"최고 점수: {bestScore}";
    }
}
