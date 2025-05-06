using UnityEngine;
using UnityEngine.UI;
using System;

public class EnterUI : BaseUI<UIState, UIManager>
{
    // 인스펙터에 연결할 버튼들
    [SerializeField] private Button enterButton;
    [SerializeField] private Button cancelButton;

    // 입장 동작을 저장하는 델리게이트
    private Action onEnter;

    // UIManager에서 UI를 초기화할 때  호출
    public override void Init(UIManager uiManager)
    {
        base.Init(uiManager);
        // 입장버튼 클릭 시
        enterButton.onClick.AddListener(() =>
        {
            onEnter?.Invoke(); // 등록된 입장 액션이 있으면 실행
        });
        // 취소버튼 클릭 시
        cancelButton.onClick.AddListener(() =>
        {
            uiManager.ChangeState(UIState.None); // UI 상태를 비활성화로 변경
        });
    }

    // 입장 버튼을 눌렀을 때 실행할 액션에 넣을 함수
    public void SetEnterAction(Action enterAction)
    {
        onEnter = enterAction; // 전달받은 액션을 변수에 저장
    }

    // UI의 상태를 반환
    protected override UIState GetUIState()
    {
        return UIState.Enter;
    }
}
