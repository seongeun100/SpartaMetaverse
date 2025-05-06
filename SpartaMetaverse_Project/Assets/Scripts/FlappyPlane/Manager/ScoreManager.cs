using TMPro;
using UnityEngine;

// 점수관리 매니저
public class ScoreManager : MonoBehaviour
{
    // 외부에서 접근 가능한 싱글톤 (읽기 전용)
    public static ScoreManager Instance { get; private set; } // 전역 접근용 인스턴스
    public int score = 0; // 현재 점수
    public TextMeshProUGUI currentScore; // 점수 표시할 UI 텍스트

    void Awake()
    {
        // 인스턴스가 없으면 자신을 할당
        if (Instance == null)
        {
            Instance = this;
            // DontDestroyOnLoad(gameObject); // 씬 전환 시 파괴되지 않도록 설정
        }
        else
        {
            Destroy(gameObject); // 중복 방지
        }
    }

    void Start()
    {
        UpdateScoreUI(); // 시작 시 점수 UI 초기화
    }

    public void AddScore(int value)
    {
        score += value;
        UpdateScoreUI(); // UI 갱신
    }

    private void UpdateScoreUI()
    {
        if (currentScore != null)
        {
            currentScore.text = $"{score}"; // 현재 점수를 문자열로 표시
        }
    }

    // 점수 초기화 함수
    public void ResetScore()
    {
        score = 0;
        UpdateScoreUI();
    }

    // 최고 점수 저장
    public void SaveBestScore()
    {
        // 저장된 최고 점수 불러오기
        int bestScore = PlayerPrefs.GetInt("BestScore", 0);

        // 현재 점수가 최고점보다 높으면 갱신
        if (score > bestScore)
        {
            PlayerPrefs.SetInt("BestScore", score);
            PlayerPrefs.Save();
        }
    }

}