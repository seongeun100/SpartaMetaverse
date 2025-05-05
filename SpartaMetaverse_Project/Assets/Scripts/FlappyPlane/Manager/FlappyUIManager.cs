using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public enum FlappyUIState
{
    Main,
    GameOver,
    Description,
    None,
}

public class FlappyUIManager : MonoBehaviour
{
    public static FlappyUIManager instance;
    private FlappyUIState currentState;
    FlappyMainUI mainUI;
    FlappyDescriptionUI descriptionUI;
    FlappyGameOverUI gameOverUI;

    public TextMeshProUGUI scoreText;


    [SerializeField] private GameObject MainMenu;
    [SerializeField] private GameObject canvas;
    [SerializeField] private GameObject Descript;
    [SerializeField] private GameObject GameOver;


    void Awake()
    {
        instance = this;

        mainUI = GetComponentInChildren<FlappyMainUI>(true);
        descriptionUI = GetComponentInChildren<FlappyDescriptionUI>(true);
        gameOverUI = GetComponentInChildren<FlappyGameOverUI>(true);

        mainUI.Init(this);
        descriptionUI.Init(this);
        gameOverUI.Init(this);
    }

    public void ChangeState(FlappyUIState state)
    {
        currentState = state;
        Debug.Log("현재:" + state);


        mainUI.SetActive(currentState);
        descriptionUI.SetActive(currentState);
        gameOverUI.SetActive(currentState);
    }



    public bool IsPanelOpen()
    {
        return currentState != FlappyUIState.None;
    }

    public FlappyMainUI GetMenuUI()
    {
        return mainUI;
    }

    public FlappyDescriptionUI GetDescriptionUI()
    {
        return descriptionUI;
    }

    public FlappyGameOverUI GetGameOverUI()
    {
        return gameOverUI;
    }

    public void UpdateScore(int score)
    {
        scoreText.text = score.ToString();
    }
}
