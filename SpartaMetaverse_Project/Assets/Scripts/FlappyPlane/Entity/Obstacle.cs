using UnityEngine;

// FlappyPlane 게임 장애물 관리
public class Obstacle : MonoBehaviour
{
    public float highPosY = 1f; // 장애물이 생성될 수 있는 최대 Y값
    public float lowPosY = -1f; // 장애물이 생성될 수 있는 최소 Y값

    public float holeSizeMin = 1f; // 지나갈 구멍 최소 크기
    public float holeSizeMax = 3f; // 지나갈 구멍 최대 크기

    public Transform topObject; // 위쪽 장애물
    public Transform bottomObject; // 아래쪽 장애물

    public float widthPadding = 4f; // 장애물 간 간격

    FlappyGameManager flappyGameManager; // 점수 증가를 위한 게임 매니저 참조

    private void Start()
    {
        flappyGameManager = FlappyGameManager.Instance; // 싱글톤 참조 가져오기
    }


    // 장애물을 랜덤 위치에 배치하는 함수
    public Vector3 SetRandomPlace(Vector3 lastPosition, int obstacleCount)
    {
        float holeSize = Random.Range(holeSizeMin, holeSizeMax); // 구멍 크기 랜덤
        float halfHoleSize = holeSize / 2;

        // 위/아래 기둥 위치 조정
        topObject.localPosition = new Vector3(0, halfHoleSize);
        bottomObject.localPosition = new Vector3(0, -halfHoleSize);

        // 가로로 일정 간격 이동한 위치 설정
        Vector3 placePosition = lastPosition + new Vector3(widthPadding, 0);
        // Y 위치는 랜덤하게 높이 조정
        placePosition.y = Random.Range(lowPosY, highPosY);

        // 장애물 위치 설정
        transform.position = placePosition;

        return placePosition; // 다음 장애물 배치할 때 참조용으로 반환
    }
    // 플레이어가 장애물을 지나갔을 때
    private void OnTriggerExit2D(Collider2D other)
    {
        Player player = other.GetComponent<Player>();
        if (player != null)
            flappyGameManager.AddScore(1); // 점수 1증가
    }

}
