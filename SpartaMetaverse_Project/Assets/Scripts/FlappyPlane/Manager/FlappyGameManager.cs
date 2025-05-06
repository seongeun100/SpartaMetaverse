using UnityEngine;
using UnityEngine.SceneManagement;

// FlappyPlane 전용 GameManager
public class FlappyGameManager : MonoBehaviour
{
    public static bool restartGame = false; // 씬 재시작 플래그
    public static FlappyGameManager flappyGameManager;
    public static FlappyGameManager Instance { get { return flappyGameManager; } }

    FlappyUIManager flappyUiManager;

    public FlappyUIManager FlappyUIManager { get { return flappyUiManager; } }

    private void Awake()
    {
        flappyGameManager = this; // 싱글톤 할당
        flappyUiManager = FindObjectOfType<FlappyUIManager>(); // 씬에서 UIManager 찾아서 참조
    }

    private void Start()
    {
        if (restartGame)
        {
            // 재시작 상태이면 UI 없이 게임 바로 시작
            flappyUiManager.ChangeState(FlappyUIState.None);
            StartGame();
            restartGame = false; // 재시작 플래그 초기화
        }
        else
        {
            // 일반 실행 시 게임 멈추고 메인 메뉴 UI 표시
            Time.timeScale = 0;
            FlappyUIManager.instance.ChangeState(FlappyUIState.Main);
        }
        ScoreManager.Instance.ResetScore();  // 점수 초기화
    }

    // 게임 시작 처리 (시간 재개)
    public void StartGame()
    {
        Time.timeScale = 1;
    }

    // 게임 오버 처리
    public void GameOver()
    {
        Time.timeScale = 0; // 게임 정지
        EndGame(); // 게임 종료 처리
    }

    public void RestartGame()
    {
        restartGame = true; // 재시작 상태 표시
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // 현재 씬 다시 로드
    }

    // 점수 증가 처리
    public void AddScore(int score)
    {
        ScoreManager.Instance.AddScore(score); // ScoreManager에 점수 누적
    }

    public void EndGame()
    {
        ScoreManager.Instance.SaveBestScore(); // 최고 점수 저장
        PlayerPrefs.SetInt("LastScore", ScoreManager.Instance.score); // 마지막 점수 저장
        PlayerPrefs.Save();
        flappyUiManager.ChangeState(FlappyUIState.GameOver); // 게임오버 UI 활성화
    }

}
