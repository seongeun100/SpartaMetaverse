using UnityEngine;

// FlappyPlane 오브젝트 반복 제어
public class BgLooper : MonoBehaviour
{
    public int obstacleCount = 0; // 현재 장애물 수
    public Vector3 obstacleLastPosition = Vector3.zero; // 마지막으로 배치된 장애물의 위치

    void Start()
    {
        // 현재 씬에 존재하는 모든 Obstacle 컴포넌트 찾아오기
        Obstacle[] obstacles = GameObject.FindObjectsOfType<Obstacle>();

        // 시작 기준 위치는 첫 번째 장애물 위치
        obstacleLastPosition = obstacles[0].transform.position;
        obstacleCount = obstacles.Length;

        // 모든 장애물을 초기 배치
        for (int i = 0; i < obstacleCount; i++)
        {
            obstacleLastPosition = obstacles[i].SetRandomPlace(obstacleLastPosition, obstacleCount);
        }
    }

    // 트리거에 오브젝트가 닿을때
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Obstacle obstacle = collision.GetComponent<Obstacle>();
        if (obstacle)
        {
            // 해당 장애물을 마지막 배치 기준으로 새 위치에 재배치
            obstacleLastPosition = obstacle.SetRandomPlace(obstacleLastPosition, obstacleCount);
        }
    }

    void Update()
    {

    }
}
