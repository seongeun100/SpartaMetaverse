using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FlappyGameManager : MonoBehaviour
{
    public static bool restartGame = false;
    public static FlappyGameManager flappyGameManager;

    public static FlappyGameManager Instance { get { return flappyGameManager; } }

    // private int currentScore = 0;


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
        ScoreManager.Instance.ResetScore();
    }

    public void StartGame()
    {
        Time.timeScale = 1;
    }

    public void GameOver()
    {
        Time.timeScale = 0;
        EndGame();
    }

    public void RestartGame()
    {
        restartGame = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void AddScore(int score)
    {
        ScoreManager.Instance.AddScore(score); // 점수 누적
    }

    public void EndGame()
    {
        ScoreManager.Instance.SaveBestScore(); // 최고 점수 저장
        PlayerPrefs.SetInt("LastScore", ScoreManager.Instance.score); // 마지막 점수 저장
        PlayerPrefs.Save();
        flappyUiManager.ChangeState(FlappyUIState.GameOver);
    }

}
