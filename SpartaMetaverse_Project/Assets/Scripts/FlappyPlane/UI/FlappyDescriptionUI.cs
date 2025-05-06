using UnityEngine;
using UnityEngine.UI;

public class FlappyDescriptionUI : BaseUI<FlappyUIState, FlappyUIManager>
{
    // 인스펙터에서 연결할 메인메뉴 버튼
    [SerializeField] private Button mainMenuButton;

    // UI 초기화 시 호출되는 함수
    public override void Init(FlappyUIManager flappyUIManager)
    {
        // FlappyUImanager 가져옴
        base.Init(flappyUIManager);
        // mainMenuButton 클릭 시
        mainMenuButton.onClick.AddListener(() =>
        {
            // 메인메뉴 UI 활성화
            uiManager.ChangeState(FlappyUIState.Main);
        });
    }

    // UI의 상태를 반환
    protected override FlappyUIState GetUIState()
    {
        return FlappyUIState.Description;
    }
}
