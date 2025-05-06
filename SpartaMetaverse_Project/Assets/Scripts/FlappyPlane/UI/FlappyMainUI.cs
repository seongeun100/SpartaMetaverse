using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// FlappyPlane 게임 메인메뉴 UI 제어
public class FlappyMainUI : BaseUI<FlappyUIState, FlappyUIManager>
{
    // 인스펙터에서 연결할 게임시작, 설명, 종료 버튼
    [SerializeField] private Button startButton;
    [SerializeField] private Button descriptButton;
    [SerializeField] private Button exitButton;

    // UI 초기화 시 호출되는 함수
    public override void Init(FlappyUIManager flappyUIManager)
    {
        // FlappyUImanager 가져옴
        base.Init(flappyUIManager);
        // startButton 클릭 시
        startButton.onClick.AddListener(() =>
        {
            // UI 비활성화
            uiManager.ChangeState(FlappyUIState.None);
            // 게임 시작
            FlappyGameManager.Instance.StartGame();
        });

        // descriptionButton 클릭 시
        descriptButton.onClick.AddListener(() =>
        {
            // UI 비활성화
            uiManager.ChangeState(FlappyUIState.None);
            // 설명 UI 활성화
            uiManager.ChangeState(FlappyUIState.Description);
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
        return FlappyUIState.Main;
    }
}