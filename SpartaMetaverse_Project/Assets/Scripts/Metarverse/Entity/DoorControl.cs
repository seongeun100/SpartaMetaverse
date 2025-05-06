using UnityEngine;

// 문 열림/닫힘 제어
public class DoorControl : MonoBehaviour, IInteract
{
    // 인스펙터에 연결할 Collider2D, Animator
    [SerializeField] private Collider2D doorCollider;
    [SerializeField] private Animator animator;

    // F(상호작용)키 입력햇을 때
    public void OnInteract()
    {

        if (doorCollider.enabled)
        {
            // 문열기
            animator.SetBool("IsOpen", true);
            // 충돌 비활성화
            doorCollider.enabled = false;
        }
        else
        {
            // 문닫기
            animator.SetBool("IsOpen", false);
            // 충돌 활성화
            doorCollider.enabled = true;
        }
    }

    // 플레이어가 트리거에서 벗어났을 때
    private void OnTriggerExit2D(Collider2D collision)
    {
        // 플레이어일 때
        if (collision.CompareTag("Player"))
        {
            // 문닫기
            animator.SetBool("IsOpen", false);
            // 충돌 활성화
            doorCollider.enabled = true;
        }
    }

}
