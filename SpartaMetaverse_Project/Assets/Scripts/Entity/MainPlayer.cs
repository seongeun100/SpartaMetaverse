using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;


public class MainPlayer : MonoBehaviour
{
    GameManager gameManager;

    public Vector2 inputVec;
    float speed = 5; // 이동속도
    float jumpHeight = 1f; // 점프 높이
    bool isJumping = false; // 점프 여부
    float jumpTimer = 0f; // 점프 시간 누적
    float jumpDuration = 0.5f; // 점프 걸리는 시간
    float jumpStartY; // 점프 시작 시점의 y값

    Rigidbody2D rigid;
    SpriteRenderer sprite;
    IInteractable interactTarget;


    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    void Start()
    {

    }

    void FixedUpdate()
    {
        if (UIManager.instance.IsPanelOpen()) return;
        // 기본 이동 계산
        Vector2 move = inputVec * speed * Time.fixedDeltaTime;

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
                // 점프 상승 부분
                float T = t / 0.5f;
                y = Mathf.Lerp(jumpStartY, jumpStartY + jumpHeight, T);
            }
            else
            {
                // 점프 하강 부분
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
        if (UIManager.instance.IsPanelOpen())
            return;
        if (!isJumping)
        {
            isJumping = true;
            jumpTimer = 0f;
            jumpStartY = rigid.position.y; // 현재 위치 저장
        }
    }

    void OnInteract()
    {
        if (interactTarget != null)
        {
            interactTarget.OnInteract();
        }
    }

    void OnCancel()
    {
        if (interactTarget is ICancelable cancelable)
        {
            cancelable.OnCancel();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        IInteractable interactable = collision.GetComponent<IInteractable>();
        if (interactable != null)
        {
            interactTarget = interactable;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        IInteractable interactable = collision.GetComponent<IInteractable>();
        if (interactable != null && interactTarget == interactable)
        {
            interactTarget = null;
        }
    }
}
