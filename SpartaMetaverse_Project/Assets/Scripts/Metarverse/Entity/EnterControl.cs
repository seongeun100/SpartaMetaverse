using UnityEngine;

public class EnterControl : MonoBehaviour, IInteract, ICancel
{
    // 인스펙터에서 받아올 이동하게될 위치와 이동할 플레이어
    [SerializeField] private Transform targetPosition;
    [SerializeField] private GameObject player;

    // 플레이어가 범위 안에 있는지 확인
    private bool isInRange = false;

    // F(상호작용)키를 입력했을 때
    public void OnInteract()
    {
        if (isInRange)
        {
            // 플레이어 위치를 지정한 위치로 이동
            player.transform.position = targetPosition.position;
            // UI 상태 비활성화
            UIManager.instance.ChangeState(UIState.None);
        }
    }

    // C(취소)키를 입력했을 때
    public void OnCancel()
    {
        if (isInRange)
        {
            // UI 상태 비활성화
            UIManager.instance.ChangeState(UIState.None);
        }
    }

    // 플레이어가 트리거 안으로 들어왔을 때
    private void OnTriggerEnter2D(Collider2D other)
    {
        // 플레이어일 때
        if (other.CompareTag("Player"))
        {
            isInRange = true;
            // UI 상태를 Enter로 전환하고 EnterUI 활성화
            UIManager.instance.ChangeState(UIState.Enter);
            // 입장 버튼 클릭 시
            UIManager.instance.GetEnterUI().SetEnterAction(() =>
            {
                // 플레이어 위치를 지정한 위치로 이동
                player.transform.position = targetPosition.position;
                // UI 상태 비활성화
                UIManager.instance.ChangeState(UIState.None);
            });
        }
    }

    // 플레이어가 트리거를 벗어났을 때
    private void OnTriggerExit2D(Collider2D other)
    {
        // 플레이어일 때
        if (other.CompareTag("Player"))
        {
            isInRange = false;
            // UI 상태 비활성화
            UIManager.instance.ChangeState(UIState.None);
        }
    }
}
