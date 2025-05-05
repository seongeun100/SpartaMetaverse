using UnityEngine;
using UnityEngine.UI;
using System;

public class EnterUI : BaseUI<UIState, UIManager>
{
    [SerializeField] private Button enterButton;
    [SerializeField] private Button cancelButton;

    private Action onEnter;

    public override void Init(UIManager uiManager)
    {
        base.Init(uiManager);
        enterButton.onClick.AddListener(() =>
        {
            onEnter?.Invoke(); // null이면 실행 안됨
        });
        cancelButton.onClick.AddListener(() =>
        {
            uiManager.ChangeState(UIState.None);
        });
    }

    public void SetEnterAction(Action enterAction)
    {
        onEnter = enterAction;
    }

    protected override UIState GetUIState()
    {
        return UIState.Enter;
    }
}
