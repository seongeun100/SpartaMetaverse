using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TalkUI : BaseUI<UIState, UIManager>
{
    [SerializeField] private TextMeshProUGUI talkText;
    public void SetText(string text)
    {
        talkText.text = text;
    }

    public void ClearText()
    {
        talkText.text = "";
    }

    public void AppendText(char text)
    {
        talkText.text += text;
    }

    protected override UIState GetUIState()
    {
        return UIState.Talk;
    }
}
