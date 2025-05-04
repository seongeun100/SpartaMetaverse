using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    [SerializeField] private GameObject talkPanel;
    [SerializeField] private GameObject canvas;
    [SerializeField] private TextMeshProUGUI talkText;

    void Awake()
    {
        instance = this;
    }

    public void ShowTalkPanel()
    {
        talkPanel.SetActive(true);
    }

    public void HideTalkPanel()
    {
        talkPanel.SetActive(false);
    }

    public void SetTalkText(string text)
    {
        talkText.text = text;
    }

    public void ClearTalkText()
    {
        talkText.text = "";
    }

    public void AppendTalkText(char text)
    {
        talkText.text += text;
    }

    public bool IsPanelOpen()
    {
        foreach (Transform child in canvas.transform)
        {
            if (child.gameObject.activeSelf)
                return true;
        }
        return false;
    }
}
