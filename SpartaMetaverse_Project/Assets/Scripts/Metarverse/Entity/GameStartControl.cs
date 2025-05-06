using UnityEngine;

public class GameStartControl : MonoBehaviour, ICancel
{
    // 인스펙터에 연결할 Animator
    [SerializeField] private Animator animator;

    // 플레이어가 트리거 범위 안에 있는지 확인
    private bool isInRange = false;

    // C(취소)키 입력 시
    public void OnCancel()
    {
        if (isInRange)
        {
            // UI 상태 비활성화
            UIManager.instance.ChangeState(UIState.None);
        }
    }

    // 플레이어가 트리거 범위 안에 들어왔을 때 호출
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isInRange = true;
            animator.SetBool("IsPress", true);
            // UI 상태를 GameStart로 변경해서 UI 활성화
            UIManager.instance.ChangeState(UIState.GameStart);
        }
    }

    // 플레이어가 트리거 범위를 벗어났을 때 호출
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isInRange = false;
            animator.SetBool("IsPress", false);
            // UI 상태 비활성화
            UIManager.instance.ChangeState(UIState.None);
        }
    }
}
