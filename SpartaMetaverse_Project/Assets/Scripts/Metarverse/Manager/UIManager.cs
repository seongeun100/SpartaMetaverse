using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

// UI 상태를 나타내는 열거형
public enum UIState
{
    Talk,
    Enter,
    GameStart,
    Exit,
    None,
}

public class UIManager : MonoBehaviour
{
    public static UIManager instance; // 싱글톤

    private UIState currentState; // 현재 활성화된 UI 상태

    // 각각 UI 컴포넌트 참조
    TalkUI talkUI;
    EnterUI enterUI;
    GameStartUI gameStartUI;
    ExitUI exitUI;

    void Awake()
    {
        instance = this; // 싱글톤 인스턴스 할당

        // 씬 안에서 비활성화된 상태여도 자식에서 컴포넌트 가져옴
        talkUI = GetComponentInChildren<TalkUI>(true);
        enterUI = GetComponentInChildren<EnterUI>(true);
        gameStartUI = GetComponentInChildren<GameStartUI>(true);
        exitUI = GetComponentInChildren<ExitUI>(true);

        // 각각의 UI에 UImanager 전달
        talkUI.Init(this);
        enterUI.Init(this);
        gameStartUI.Init(this);
        exitUI.Init(this);

        ChangeState(UIState.None); // 시작할 때 모든 UI 비활성화
    }

    // UI 상태를 변경하고, 해당 UI 활성화
    public void ChangeState(UIState state)
    {
        currentState = state;

        if (talkUI != null)
            talkUI.SetActive(currentState);

        if (enterUI != null)
            enterUI.SetActive(currentState);

        if (gameStartUI != null)
            gameStartUI.SetActive(currentState);

        if (exitUI != null)
            exitUI.SetActive(currentState);
    }

    // 어떤 UI라도 켜져있는지 확인하는 함수
    public bool IsPanelOpen()
    {
        return currentState != UIState.None;
    }

    // 외부에서 UI에 접근가능하게 하는 함수
    public TalkUI GetTalkUI()
    {
        return talkUI;
    }

    public EnterUI GetEnterUI()
    {
        return enterUI;
    }

    public GameStartUI GetGameStartUI()
    {
        return gameStartUI;
    }
    public ExitUI GetExitUI()
    {
        return exitUI;
    }
}
