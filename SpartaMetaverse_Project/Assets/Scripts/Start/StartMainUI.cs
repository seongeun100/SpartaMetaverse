using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// Start 메인메뉴 UI 제어
public class StartMainUI : BaseUI<StartUIState, StartUIManager>
{
    // 인스펙터에서 연결할 게임시작, 설명, 종료 버튼
    [SerializeField] private Button startButton;
    [SerializeField] private Button descriptButton;
    [SerializeField] private Button exitButton;

    // UI 초기화 시 호출되는 함수
    public override void Init(StartUIManager startUIManager)
    {
        // StartUImanager 가져옴
        base.Init(startUIManager);
        // startButton 클릭 시
        startButton.onClick.AddListener(() =>
        {
            // UI 비활성화
            uiManager.ChangeState(StartUIState.None);
            // 게임 시작
            SceneManager.LoadScene("MainScene");
        });

        // descriptionButton 클릭 시
        descriptButton.onClick.AddListener(() =>
        {
            // 설명 UI 활성화
            uiManager.ChangeState(StartUIState.Description);
        });

        // exitButton 클릭 시
        exitButton.onClick.AddListener(() =>
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false; // 에디터 실행 중지
#else
    Application.Quit();
#endif
        });
    }

    // UI의 상태를 반환
    protected override StartUIState GetUIState()
    {
        return StartUIState.Main;
    }
}