using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class FlappyMainUI : BaseUI<FlappyUIState, FlappyUIManager>
{
    [SerializeField] private Button startButton;
    [SerializeField] private Button descriptButton;
    [SerializeField] private Button exitButton;

    public override void Init(FlappyUIManager flappyUIManager)
    {
        base.Init(flappyUIManager);
        startButton.onClick.AddListener(OnClickStart);

        descriptButton.onClick.AddListener(OnClickDescription);

        exitButton.onClick.AddListener(OnClickExit);
    }

    void OnClickStart()
    {
        uiManager.ChangeState(FlappyUIState.None);
        FlappyGameManager.Instance.StartGame();
    }

    void OnClickDescription()
    {
        uiManager.ChangeState(FlappyUIState.None);
        uiManager.ChangeState(FlappyUIState.Description);
    }

    void OnClickExit()
    {
        SceneManager.LoadScene("MainScene");
    }

    protected override FlappyUIState GetUIState()
    {
        return FlappyUIState.Main;
    }
}