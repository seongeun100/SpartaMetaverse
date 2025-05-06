using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// FlappyPlane 게임종료 시 나오는 UI 제어
public class FlappyGameOverUI : BaseUI<FlappyUIState, FlappyUIManager>
{
    // 인스펙터에서 연결할 재시작, 종료 버튼
    [SerializeField] private Button restartButton;
    [SerializeField] private Button exitButton;

    // UI 초기화 시 호출되는 함수
    public override void Init(FlappyUIManager flappyUIManager)
    {
        // FlappyUImanager 가져옴
        base.Init(flappyUIManager);

        // restartButton 클릭 시
        restartButton.onClick.AddListener(() =>
        {
            // 재시작
            FlappyGameManager.Instance.RestartGame();
        });
        // exitButton 클릭 시
        exitButton.onClick.AddListener(() =>
        {
            // 메인 씬으로 전환
            SceneManager.LoadScene("MainScene");
        });
    }

    // UI의 상태를 반환
    protected override FlappyUIState GetUIState()
    {
        return FlappyUIState.GameOver;
    }
}
