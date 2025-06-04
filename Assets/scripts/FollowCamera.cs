using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform target;         // 따라갈 대상 (플레이어)
    private Vector3 offset;          // 초기 상대 위치 (카메라 - 플레이어)

    void Start()
    {
        if (target == null)
        {
            Debug.LogError("FollowCamera: 타겟이 지정되지 않았습니다.");
            return;
        }

        offset = transform.position - target.position; // 현재 위치에서의 상대 거리 저장
    }

    void LateUpdate()
    {
        if (target != null)
        {
            transform.position = target.position + offset;
            // 회전은 고정된 상태를 유지 (초기 회전 유지)
        }
    }
}
