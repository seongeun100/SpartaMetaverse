using UnityEngine;
using UnityEngine.UI;

public class FlappyDescriptionUI : BaseUI<FlappyUIState, FlappyUIManager>
{
    [SerializeField] private Button mainMenuButton;

    public override void Init(FlappyUIManager flappyUIManager)
    {
        base.Init(flappyUIManager);
        mainMenuButton.onClick.AddListener(OnClickMainMenu);
    }

    void OnClickMainMenu()
    {
        uiManager.ChangeState(FlappyUIState.Main);
    }

    protected override FlappyUIState GetUIState()
    {
        return FlappyUIState.Description;
    }
}
