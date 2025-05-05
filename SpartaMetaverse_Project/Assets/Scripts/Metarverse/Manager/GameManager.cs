using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public static Vector2 returnPosition;

    private UIManager uiManager;
    private TalkUI talkUI;
    private GameObject scanObject;

    public TalkManager talkManager;

    public bool isTalking;
    public int talkIndex;
    public MainPlayer player;

    Coroutine typingCoroutine;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        uiManager = UIManager.instance;
        talkUI = uiManager.GetTalkUI(); // TalkUI 가져오기
        if (returnPosition != Vector2.zero)
        {
            player.transform.position = returnPosition;
        }
        // var cameraFollow = Camera.main.GetComponent<CameraFollow>();
        // if (player != null && cameraFollow != null)
        // {
        //     cameraFollow.SetTarget(player.transform);
        // }
    }

    public void Interaction(GameObject obj)
    {
        if (!isTalking)
        {
            scanObject = obj;
            talkIndex = 0;
            isTalking = true;

            uiManager.ChangeState(UIState.Talk);
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
            uiManager.ChangeState(UIState.None);
        }
    }

    public void SetReturnPosition()
    {
        returnPosition = player.transform.position;
    }

    void DisplayNextLine()
    {
        if (scanObject == null) return;

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
        talkUI.ClearText();
        foreach (char text in sentence.ToCharArray())
        {
            talkUI.AppendText(text);
            yield return new WaitForSeconds(0.03f);
        }
    }

    void EndTalk()
    {
        isTalking = false;
        talkIndex = 0;
        scanObject = null;
        uiManager.ChangeState(UIState.None);
    }
}