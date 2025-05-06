using UnityEngine;

// FlappyPlane 카메라 제어
public class FlappyCameraFollow : MonoBehaviour
{
    public Transform target; // 따라갈 대상(Player)
    float offsetX; // 초기 카메라 위치와 대상 간의 X축 거리 차이

    void Start()
    {
        // target이 설정되어 있지 않으면 아무것도 하지 않음
        if (target == null)
            return;

        // 카메라와 대상 간의 초기 X 거리 차이 저장
        offsetX = transform.position.x - target.position.x;
    }

    void Update()
    {
        if (target == null)
            return;

        // 카메라의 현재 위치를 복사
        Vector3 pos = transform.position;
        // X 위치만 대상 위치 + 초기 오프셋만큼 유지
        pos.x = target.position.x + offsetX;
        // 카메라 위치 갱신 (Y, Z는 고정)
        transform.position = pos;
    }
}
