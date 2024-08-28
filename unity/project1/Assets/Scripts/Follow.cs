using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class Follow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    private PhotonView pv;

    void Start()
    {
        pv = GetComponent<PhotonView>();

        if (pv.IsMine)
        {
            // ���� ������Ʈ�� ���� �÷��̾���, ī�޶� ã�� ���󰡵��� ����
            Camera.main.GetComponent<CameraFollow>().SetTarget(transform);
        }
    }
}
