using UnityEngine;

// FlappyPlane 게임 플레이어 제어
public class Player : MonoBehaviour
{
    Animator animator = null;
    Rigidbody2D _rigidbody = null;

    public float flapForce = 6f; // 점프할 때 위로 가해지는 힘
    public float forwardSpeed = 3f; // 오른쪽으로 가는 속도
    public bool isDead = false; // 죽었는지 여부

    bool isFlap = false; // 점프 입력이 들어왔는지 여부

    public bool godMode = false; // 치트 모드(충돌해도 안죽음)
    private bool isGameOver = false; // GameOver() 중복 호출 방지

    FlappyGameManager flappyGameManager; // 게임 흐름 제어 매니저 참조

    void Start()
    {
        flappyGameManager = FlappyGameManager.Instance;
        animator = GetComponentInChildren<Animator>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (isDead)
        {
            // 처음 죽었을 때만 GameOver 처리
            if (!isGameOver)
            {
                flappyGameManager.GameOver();
                isGameOver = true;
            }
        }
        else
        {
            // 스페이스바 또는 마우스 클릭 시 점프 입력
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
                isFlap = true;
            }
        }
    }

    private void FixedUpdate()
    {
        if (isDead) return;

        // 항상 오른쪽으로 이동
        Vector3 velocity = _rigidbody.velocity;
        velocity.x = forwardSpeed;

        // 점프 입력이 있었을 경우 위로 힘을 가함
        if (isFlap)
        {
            velocity.y += flapForce;
            isFlap = false;
        }

        _rigidbody.velocity = velocity;

        // 캐릭터 회전 처리 (상승할 땐 위로, 하강할 땐 아래로)
        float angle = Mathf.Clamp((_rigidbody.velocity.y * 10f), -90, 90);
        float lerpAngle = Mathf.LerpAngle(transform.rotation.eulerAngles.z, angle, Time.fixedDeltaTime * 5f);
        transform.rotation = Quaternion.Euler(0, 0, lerpAngle);
    }

    // 플레이어와 충돌할 때
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (godMode) return; // 치트 모드면 무시

        if (isDead) return; // 이미 죽었으면 무시

        isDead = true;
        animator.SetInteger("IsDie", 1); // 죽음 애니메이션 실행
    }
}
