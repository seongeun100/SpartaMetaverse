using TMPro;
using UnityEngine;

public class TalkUI : BaseUI<UIState, UIManager>
{
    [SerializeField] private TextMeshProUGUI talkText;

    // 외부에서 텍스트 전체를 설정하는 함수
    public void SetText(string text)
    {
        talkText.text = text;
    }

    // 텍스트 초기화하는 함수
    public void ClearText()
    {
        talkText.text = "";
    }

    // 텍스트에 한 글자씩 추가하는 함수
    public void AppendText(char text)
    {
        talkText.text += text;
    }

    // UI가 어떤 상태일 때 활성화되는지 반환 
    protected override UIState GetUIState()
    {
        return UIState.Talk;
    }
}
