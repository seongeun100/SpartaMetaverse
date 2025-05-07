using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; // 싱글톤
    public static Vector2 returnPosition; // 씬 이동 후 돌아올 플레이어 위치 저장용

    private UIManager uiManager; // UIManager 참조
    private TalkUI talkUI; // TalkUI 참조
    private GameObject scanObject; // 현재 상호작용중인 오브젝트

    public TalkManager talkManager; // Talk 데이터 관리 매니저

    public bool isTalking; // 대화여부 확인
    public int talkIndex; // 현재 대화 인덱스
    public MainPlayer player; // 메인 플레이어 참조

    Coroutine typingCoroutine; // 대화 타이핑 효과 코루틴 저장 변수

    void Awake()
    {
        instance = this; // 싱글톤 초기화
        uiManager = UIManager.instance; // UIManager 싱글톤 참조
        talkUI = uiManager.GetTalkUI(); // TalkUI 가져오기
    }

    void Start()
    {
        if (talkUI == null)
        {
            return;
        }

        // returnPosition이 설정되어 있으면 해당위치로 플레이어 이동
        if (returnPosition != Vector2.zero)
        {
            player.transform.position = returnPosition;

            // 메인 카메라도 플레이어 위치로 이동
            Camera mainCam = Camera.main;
            Vector3 camPos = player.transform.position;
            camPos.z = mainCam.transform.position.z; // 카메라 z값 유지
            mainCam.transform.position = camPos;
        }
        Time.timeScale = 1; // 멈춰져 있을 수 있어서 시간 재개
    }

    // 상호작용 
    public void Interaction(GameObject obj)
    {
        if (!isTalking)
        {
            scanObject = obj; // 상호작용 대상 저장
            talkIndex = 0; // 대화 시작 시 인덱스 초기화
            isTalking = true;

            uiManager.ChangeState(UIState.Talk); // Talk UI 활성화
            DisplayNextLine(); // 첫 대화 출력
        }
        else
        {
            DisplayNextLine(); // 대화중이면 다음줄 출력
        }
    }

    // 대화 취소 시 호출되는 함수
    public void CancelTalk()
    {
        // 대화중이면 값 초기화
        if (isTalking)
        {
            isTalking = false;
            talkIndex = 0;
            scanObject = null;
            uiManager.ChangeState(UIState.None); // 모든 UI 비활성화
        }
    }

    // 현재 플레이어 위치를 returnPosition에 저장하는 함수 (씬 전환 대비)
    public void SetReturnPosition()
    {
        returnPosition = player.transform.position;
    }

    // 대화 출력 함수
    void DisplayNextLine()
    {
        // 상호작용 대상없을시 return
        if (scanObject == null) return;

        // 상호작용 대상 ID값 가져옴
        NpcControl npc = scanObject.GetComponent<NpcControl>();
        // 현재 인덱스의 대화 가져옴
        string talkData = talkManager.GetTalk(npc.Id, talkIndex);

        // 대화 데이터가 없을시 대화 종료 함수 호출
        if (talkData == null)
        {
            EndTalk();
            return;
        }

        if (typingCoroutine != null)
            StopCoroutine(typingCoroutine); // 이전 대사 출력 중이면 중지

        // 타이핑 효과 시작
        typingCoroutine = StartCoroutine(TypeSentence(talkData));
        talkIndex++; // 다음 대화 인덱스로 증가
    }

    // 타이핑 효과 코루틴
    IEnumerator TypeSentence(string sentence)
    {
        talkUI.ClearText(); // 기존 텍스트 초기화
        foreach (char text in sentence.ToCharArray())
        {
            talkUI.AppendText(text); // 한글자씩 추가
            yield return new WaitForSeconds(0.03f); // 0.03초 간격
        }
    }

    // 대화 종료 처리(대화에 필요한 값 초기화)
    void EndTalk()
    {
        isTalking = false;
        talkIndex = 0;
        scanObject = null;
        uiManager.ChangeState(UIState.None); // 모든 UI 비활성화
    }
}