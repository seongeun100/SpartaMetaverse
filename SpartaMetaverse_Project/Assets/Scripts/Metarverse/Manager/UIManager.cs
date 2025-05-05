using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public enum UIState
{
    Talk,
    Enter,
    GameStart,
    None,
}

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    private UIState currentState;
    TalkUI talkUI;
    EnterUI enterUI;
    GameStartUI gameStartUI;


    [SerializeField] private GameObject talkPanel;
    [SerializeField] private GameObject canvas;
    [SerializeField] private TextMeshProUGUI talkText;

    void Awake()
    {
        instance = this;
        talkUI = GetComponentInChildren<TalkUI>(true);
        enterUI = GetComponentInChildren<EnterUI>(true);
        gameStartUI = GetComponentInChildren<GameStartUI>(true);

        talkUI.Init(this);
        enterUI.Init(this);
        gameStartUI.Init(this);

        ChangeState(UIState.None); // 시작할 때 아무 UI도 안 보이게
    }

    public void ChangeState(UIState state)
    {
        currentState = state;

        talkUI.SetActive(currentState);
        enterUI.SetActive(currentState);
        gameStartUI.SetActive(currentState);
    }

    public bool IsPanelOpen()
    {
        return currentState != UIState.None;
    }

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
}
