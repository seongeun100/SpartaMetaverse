using UnityEngine;
using UnityEngine.UI;
using System;

public class ExitUI : BaseUI<UIState, UIManager>
{
    // 인스펙터에 연결할 버튼들
    [SerializeField] private Button exitButton;
    [SerializeField] private Button cancelButton;

    // UIManager에서 UI를 초기화할 때  호출
    public override void Init(UIManager uiManager)
    {
        base.Init(uiManager);
        // 종료버튼 클릭 시
        exitButton.onClick.AddListener(() =>
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false; // 에디터 실행 중지
#else
    Application.Quit();
#endif
        });
        // 취소버튼 클릭 시
        cancelButton.onClick.AddListener(() =>
        {
            uiManager.ChangeState(UIState.None); // UI 상태를 비활성화로 변경
        });
    }

    // UI의 상태를 반환
    protected override UIState GetUIState()
    {
        return UIState.Exit;
    }
}
