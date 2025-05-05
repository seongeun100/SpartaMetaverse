using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FlappyGameManager : MonoBehaviour
{
    public static bool restartGame = false;
    public static FlappyGameManager flappyGameManager;

    public static FlappyGameManager Instance { get { return flappyGameManager; } }

    private int currentScore = 0;


    FlappyUIManager flappyUiManager;

    public FlappyUIManager FlappyUIManager { get { return flappyUiManager; } }

    private void Awake()
    {
        flappyGameManager = this;
        flappyUiManager = FindObjectOfType<FlappyUIManager>();
    }

    private void Start()
    {
        if (restartGame)
        {
            flappyUiManager.ChangeState(FlappyUIState.None);
            StartGame();
            restartGame = false;
        }
        else
        {
            Time.timeScale = 0;
            FlappyUIManager.instance.ChangeState(FlappyUIState.Main);
        }
        flappyUiManager.UpdateScore(0);
    }

    public void StartGame()
    {
        Time.timeScale = 1;
    }

    public void GameOver()
    {
        Time.timeScale = 0;
        flappyUiManager.ChangeState(FlappyUIState.GameOver);
    }

    public void RestartGame()
    {
        restartGame = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void AddScore(int score)
    {
        currentScore += score;
        Debug.Log("Score: " + currentScore);
        flappyUiManager.UpdateScore(currentScore);
    }
}
