using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] private GameObject scanObject;

    private UIManager uiManager;

    public TalkManager talkManager;
    public GameObject talkPanel;

    public bool isTalking;
    public int talkIndex;

    Coroutine typingCoroutine;
    void Awake()
    {
        instance = this;
        uiManager = UIManager.instance;
    }

    public void Interaction(GameObject obj)
    {
        if (!isTalking)
        {
            scanObject = obj;
            talkIndex = 0;
            isTalking = true;
            uiManager.ShowTalkPanel();
            DisplayNextLine();
        }
        else
        {
            DisplayNextLine();
        }
    }

    public void CancelTalk()
    {
        if (isTalking)
        {
            isTalking = false;
            talkIndex = 0;
            scanObject = null;
            uiManager.HideTalkPanel();
        }
    }

    void DisplayNextLine()
    {
        NpcControl npc = scanObject.GetComponent<NpcControl>();
        string talkData = talkManager.GetTalk(npc.Id, talkIndex);

        if (talkData == null)
        {
            EndTalk();
            return;
        }

        if (typingCoroutine != null)
            StopCoroutine(typingCoroutine);

        typingCoroutine = StartCoroutine(TypeSentence(talkData));
        talkIndex++;
    }
    IEnumerator TypeSentence(string sentence)
    {
        UIManager.instance.ClearTalkText();
        foreach (char text in sentence.ToCharArray())
        {
            UIManager.instance.AppendTalkText(text);
            yield return new WaitForSeconds(0.03f); // 한 글자 출력 속도
        }
    }
    void EndTalk()
    {
        UIManager.instance.HideTalkPanel();
        isTalking = false;
        talkIndex = 0;
    }
}
