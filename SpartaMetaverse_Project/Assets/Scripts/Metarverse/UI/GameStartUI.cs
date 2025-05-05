using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class GameStartUI : BaseUI<UIState, UIManager>
{
    [SerializeField] private Button enterButton;
    [SerializeField] private Button cancelButton;
    [SerializeField] private string miniGameSceneName;


    public override void Init(UIManager uiManager)
    {
        base.Init(uiManager);
        enterButton.onClick.AddListener(() =>
        {
            GameManager.instance.SetReturnPosition();
            SceneManager.LoadScene(miniGameSceneName);
        });
        cancelButton.onClick.AddListener(() =>
        {
            uiManager.ChangeState(UIState.None);
        });
    }

    protected override UIState GetUIState()
    {
        return UIState.GameStart;
    }
}
