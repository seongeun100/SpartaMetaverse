using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraFollow : MonoBehaviour
{
    public Camera targetCamera;

    // 마우스 휠 줌 속도 및 제한 범위
    public float zoomSpeed = 2f;
    public float minSize = 2f;
    public float maxSize = 5f;

    public Transform target; // 따라갈 대상
    public float smoothSpeed = 5f; // 카메라 이동 부드러움 속도
    // 카메라 이동 제한 범위
    public Vector2 minBounds;
    public Vector2 maxBounds;

    // 카메라와 타겟 간의 초기 거리
    private Vector3 offset;

    // 스크롤 입력값
    private float scrollValue = 0f;

    void Start()
    {
        // 인스펙터창에서 카메라 할당되지 않아도 메인 카메라 자동으로 설정
        if (targetCamera == null)
        {
            targetCamera = Camera.main;
        }
        offset = transform.position - target.position;
    }

    void Update()
    {
        if (scrollValue != 0)
        {
            // 카메라 줌 조절
            targetCamera.orthographicSize -= scrollValue * zoomSpeed * Time.deltaTime;
            // 카메라 줌 사이즈 제한
            targetCamera.orthographicSize = Mathf.Clamp(targetCamera.orthographicSize, minSize, maxSize);
            // 한 프레임만 적용
            scrollValue = 0;
        }
    }

    public void OnCameraZoom(InputValue value)
    {
        // 마우스 휠 스크롤 y 값 받아옴
        Vector2 scrollDelta = value.Get<Vector2>();
        scrollValue = scrollDelta.y;
    }

    void LateUpdate()
    {
        // 따라갈 위치 계산
        Vector3 desiredPosition = target.position + offset;
        desiredPosition.z = transform.position.z;

        // 위치 제한 적용
        desiredPosition.x = Mathf.Clamp(desiredPosition.x, minBounds.x, maxBounds.x);
        desiredPosition.y = Mathf.Clamp(desiredPosition.y, minBounds.y, maxBounds.y);

        // 부드럽게 이동
        transform.position = Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime * smoothSpeed);
    }
}
