using UnityEngine;

// UI 상태를 나타내는 열거형
public enum StartUIState
{
    Main,
    Description,
    None,
}

public class StartUIManager : MonoBehaviour
{
    public static StartUIManager instance; // 싱글톤

    private StartUIState currentState; // 현재 활성화된 UI 상태

    // 각각 UI 컴포넌트 참조
    StartMainUI startMainUI;
    StartDescriptionUI startDescriptionUI;

    void Awake()
    {
        instance = this; // 싱글톤 인스턴스 할당

        // 씬 안에서 비활성화된 상태여도 자식에서 컴포넌트 가져옴
        startMainUI = GetComponentInChildren<StartMainUI>(true);
        startDescriptionUI = GetComponentInChildren<StartDescriptionUI>(true);

        // 각각의 UI에 StartUImanager 전달
        startMainUI.Init(this);
        startDescriptionUI.Init(this);
        
        ChangeState(StartUIState.Main);
    }

    // UI 상태를 변경하고, 해당 UI 활성화
    public void ChangeState(StartUIState state)
    {
        currentState = state;

        if (startMainUI != null)
            startMainUI.SetActive(currentState);

        if (startDescriptionUI != null)
            startDescriptionUI.SetActive(currentState);
    }
}
