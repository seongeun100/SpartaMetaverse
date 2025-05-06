using UnityEngine;

// UI 상태 열거형
public enum FlappyUIState
{
    Main,
    GameOver,
    Description,
    None,
}

// FlappyPlane 전용 UIManager
public class FlappyUIManager : MonoBehaviour
{
    public static FlappyUIManager instance; // 싱글톤
    private FlappyUIState currentState; // 현재 UI 상태

    // UI 참조
    FlappyMainUI mainUI;
    FlappyDescriptionUI descriptionUI;
    FlappyGameOverUI gameOverUI;

    void Awake()
    {
        instance = this; // 싱글톤 초기화

        // 비활성화 상태에서도 UI 컴포넌트 가져오기
        mainUI = GetComponentInChildren<FlappyMainUI>(true);
        descriptionUI = GetComponentInChildren<FlappyDescriptionUI>(true);
        gameOverUI = GetComponentInChildren<FlappyGameOverUI>(true);

        // 각 UI 초기화
        mainUI.Init(this);
        descriptionUI.Init(this);
        gameOverUI.Init(this);
    }

    // UI 상태를 변경하고, 해당 UI 활성화
    public void ChangeState(FlappyUIState state)
    {
        currentState = state;

        mainUI.SetActive(currentState);
        descriptionUI.SetActive(currentState);
        gameOverUI.SetActive(currentState);
    }

    // 어떤 UI라도 켜져있는지 확인하는 함수
    public bool IsPanelOpen()
    {
        return currentState != FlappyUIState.None;
    }

    // 외부에서 UI에 접근가능하게 하는 함수
    public FlappyMainUI GetMenuUI()
    {
        return mainUI;
    }

    public FlappyDescriptionUI GetDescriptionUI()
    {
        return descriptionUI;
    }

    public FlappyGameOverUI GetGameOverUI()
    {
        return gameOverUI;
    }

}
