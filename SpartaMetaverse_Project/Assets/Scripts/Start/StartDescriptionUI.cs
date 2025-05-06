using UnityEngine;
using UnityEngine.UI;

public class StartDescriptionUI : BaseUI<StartUIState, StartUIManager>
{
    // 인스펙터에서 연결할 메인메뉴 버튼
    [SerializeField] private Button mainMenuButton;

    // UI 초기화 시 호출되는 함수
    public override void Init(StartUIManager startUIManager)
    {
        // StartUImanager 가져옴
        base.Init(startUIManager);
        // mainMenuButton 클릭 시
        mainMenuButton.onClick.AddListener(() =>
        {
            // 메인메뉴 UI 활성화
            uiManager.ChangeState(StartUIState.Main);
        });
    }

    // UI의 상태를 반환
    protected override StartUIState GetUIState()
    {
        return StartUIState.Description;
    }
}
