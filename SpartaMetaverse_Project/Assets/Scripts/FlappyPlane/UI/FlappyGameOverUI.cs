using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FlappyGameOverUI : BaseUI<FlappyUIState, FlappyUIManager>
{
    [SerializeField] private Button restartButton;
    [SerializeField] private Button exitButton;

    public override void Init(FlappyUIManager flappyUIManager)
    {
        base.Init(flappyUIManager);

        restartButton.onClick.AddListener(OnClikReStart);
        exitButton.onClick.AddListener(OnClickExit);
    }

    void OnClikReStart()
    {
        FlappyGameManager.Instance.RestartGame();
    }

    void OnClickExit()
    {
        SceneManager.LoadScene("MainScene");
    }

    protected override FlappyUIState GetUIState()
    {
        return FlappyUIState.GameOver;
    }
}
