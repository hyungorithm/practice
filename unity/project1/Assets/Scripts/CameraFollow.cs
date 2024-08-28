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
            // ī�޶� Ÿ���� ��ġ + ���������� �̵���ŵ�ϴ�.
            transform.position = target.position + offset;
        }
    }

    public void SetTarget(Transform newTarget)
    {
        // ī�޶� ���� Ÿ���� �����մϴ�.
        target = newTarget;
    }
}
