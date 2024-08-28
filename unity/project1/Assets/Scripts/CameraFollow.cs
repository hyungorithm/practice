using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform target;
    public Vector3 offset;

    void LateUpdate()
    {
        if (target != null)
        {
            // 카메라를 타겟의 위치 + 오프셋으로 이동시킵니다.
            transform.position = target.position + offset;
        }
    }

    public void SetTarget(Transform newTarget)
    {
        // 카메라가 따라갈 타겟을 설정합니다.
        target = newTarget;
    }
}
