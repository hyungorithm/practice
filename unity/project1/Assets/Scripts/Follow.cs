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
            // 현재 오브젝트가 로컬 플레이어라면, 카메라를 찾고 따라가도록 설정
            Camera.main.GetComponent<CameraFollow>().SetTarget(transform);
        }
    }
}
