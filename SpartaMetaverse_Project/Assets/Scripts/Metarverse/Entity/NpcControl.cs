using UnityEngine;

// 인터페이스 IInteract, ICancel을 구현함
public class NpcControl : MonoBehaviour, IInteract, ICancel
{
    // NPC의 ID
    [SerializeField] private int id;

    // 외부에서 읽을 수 있도록 프로퍼티로 노출
    public int Id => id;

    // 플레이어가 F키(상호작용)를 입력 했을때 호출
    public void OnInteract()
    {
        // GameManager에 현재 NPC GameObject를 전달해 대화 시작
        GameManager.instance.Interaction(gameObject);
    }

    // C키(취소)를 입력 했을때 호출
    public void OnCancel()
    {
        // GameManager에 대화 취소 요청
        GameManager.instance.CancelTalk();
    }
}
