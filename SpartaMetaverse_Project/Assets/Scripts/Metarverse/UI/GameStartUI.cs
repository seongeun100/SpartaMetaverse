using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameStartUI : BaseUI<UIState, UIManager>
{
    // 인스펙터에서 연결할 버튼들, 미니게임 씬 이름
    [SerializeField] private Button enterButton;
    [SerializeField] private Button cancelButton;
    [SerializeField] private string miniGameSceneName;

    // UIManager에서 UI를 초기화할 때  호출
    public override void Init(UIManager uiManager)
    {
        base.Init(uiManager);
        // 입장버튼 클릭 시
        enterButton.onClick.AddListener(() =>
        {
            GameManager.instance.SetReturnPosition(); // 돌아올 위치 저장
            SceneManager.LoadScene(miniGameSceneName); // 미니게임 씬으로 전환
        });
        // 취소버튼 클릭 시
        cancelButton.onClick.AddListener(() =>
        {
            uiManager.ChangeState(UIState.None); // UI 상태를 비활성화로 변경
        });
    }

    // UI의 상태를 반환
    protected override UIState GetUIState()
    {
        return UIState.GameStart;
    }
}
