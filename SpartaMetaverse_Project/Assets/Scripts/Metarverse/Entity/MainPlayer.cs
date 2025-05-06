using UnityEngine;
using UnityEngine.InputSystem;


public class MainPlayer : MonoBehaviour
{
    // 인스펙터에 연결한 Animator
    [SerializeField] private Animator animator;

    public Vector2 inputVec; // 이동 방향 입력(Input System)
    float speed = 5; // 이동속도
    float jumpHeight = 1f; // 점프 높이
    bool isJumping = false; // 점프 여부
    float jumpTimer = 0f; // 점프 시간 누적
    float jumpDuration = 0.5f; // 점프 걸리는 시간
    float jumpStartY; // 점프 시작 시점의 y값

    Rigidbody2D rigid; // 물리 이동용 Rigidbody2D
    SpriteRenderer sprite; // 좌우 반전용 SpriteRenderer
    IInteract interactTarget; // 상호작용 대상


    void Awake()
    {
        // 컴포넌트 초기화
        rigid = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    void FixedUpdate()
    {
        // UI가 켜져 있을 시 이동/점프 불가
        if (UIManager.instance.IsPanelOpen()) return;
        // 기본 이동 계산
        Vector2 move = inputVec * speed * Time.fixedDeltaTime;

        // 움직일때 애니메이터 값 변경
        bool isMoving = inputVec != Vector2.zero;
        animator.SetBool("IsMove", isMoving);
        // 점프 중일때
        if (isJumping)
        {
            jumpTimer += Time.fixedDeltaTime; // 점프 진행 시간 누적
            float t = jumpTimer / jumpDuration; // 점프 진행 비율 (0~1)

            if (t >= 1f)
            {
                // 점프 종료 처리
                isJumping = false;
                jumpTimer = 0f;
                t = 1f;
            }
            float y;
            if (t < 0.5f)
            {
                // 점프 상승 부분 0 ~ 0.5
                float T = t / 0.5f;
                y = Mathf.Lerp(jumpStartY, jumpStartY + jumpHeight, T);
            }
            else
            {
                // 점프 하강 부분 0.5 ~ 1
                float T = (t - 0.5f) / 0.5f;
                y = Mathf.Lerp(jumpStartY + jumpHeight, jumpStartY, T);
            }

            // 점프 위치 적용
            rigid.MovePosition(new Vector2(rigid.position.x + move.x, y));
            return;
        }

        // 점프 중이 아닐때는 그냥이동
        rigid.MovePosition(rigid.position + move);
    }

    void LateUpdate()
    {
        // 이동 방향에 따라 캐릭터 좌우 반전
        if (inputVec.x != 0)
        {
            sprite.flipX = inputVec.x < 0 ? true : false;
        }
    }

    // Input System으로 이동 입력 받을 때 호출
    void OnMove(InputValue value)
    {
        inputVec = value.Get<Vector2>();
    }

    // Input System으로 점프 입력 받을 때 호출
    void OnJump()
    {
        // UI가 열려 있으면 점프 금지
        if (UIManager.instance.IsPanelOpen())
            return;

        // 점프 상태가 아닐 떄
        if (!isJumping)
        {
            isJumping = true;
            jumpTimer = 0f;
            jumpStartY = rigid.position.y; // 현재 위치 저장
        }
    }

    // Input System으로 F(상호작용)키 입력 시 호출
    void OnInteract()
    {
        if (interactTarget != null)
        {
            interactTarget.OnInteract(); // 대상에게 상호작용 요청
        }
    }

    // Input System으로 C(취소)키 입력 시 호출
    void OnCancel()
    {
        if (interactTarget is ICancel cancel)
        {
            cancel.OnCancel(); // 대상에게 ICancel이 구현되어 있으면 취소 요청
        }
    }

    void OnExitMenu()
    {
        UIManager.instance.ChangeState(UIState.Exit);
    }

    // 트리거 영역에 들어갔을 때 실행
    private void OnTriggerEnter2D(Collider2D collision)
    {
        IInteract interact = collision.GetComponentInParent<IInteract>();
        if (interact != null)
        {
            interactTarget = interact; // 상호작용 대상 등록
        }
    }

    // 트리거 영역에 벗어났을 때 실행
    private void OnTriggerExit2D(Collider2D collision)
    {
        IInteract interactable = collision.GetComponent<IInteract>();
        if (interactable != null && interactTarget == interactable)
        {
            interactTarget = null; // 대상에서 벗어나면 상호작용 대상 초기화
        }
    }
}
