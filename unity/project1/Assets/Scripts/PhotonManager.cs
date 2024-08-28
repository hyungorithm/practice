using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class PhotonManager : MonoBehaviourPunCallbacks
{
    private readonly string version = "1.0f";
    private string userId = "KSH";
    private GameObject localPlayer;

    private void Awake()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
        PhotonNetwork.GameVersion = version;
        PhotonNetwork.NickName = userId;

        Debug.Log(PhotonNetwork.SendRate); // ���漭���� ��� Ƚ�� (30)
        PhotonNetwork.ConnectUsingSettings(); // ���� ����
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected To Master!");
        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby()
    {
        base.OnJoinedLobby();
        Debug.Log($"Connected To Lobby = {PhotonNetwork.InLobby}");
        PhotonNetwork.JoinRandomRoom();
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log($"Join Failed {returnCode} : {message}");

        RoomOptions ro = new RoomOptions();
        ro.MaxPlayers = 20;
        ro.IsOpen = true;
        ro.IsVisible = true;

        PhotonNetwork.CreateRoom("My Room", ro);
    }

    public override void OnCreatedRoom()
    {
        Debug.Log("Created Room!");
        Debug.Log($"Room Name = {PhotonNetwork.CurrentRoom.Name}");
    }

    public override void OnJoinedRoom()
    {
        Debug.Log($"In Room = {PhotonNetwork.InRoom}");
        Debug.Log($"Player Count = {PhotonNetwork.CurrentRoom.PlayerCount}");

        foreach (var player in PhotonNetwork.CurrentRoom.Players)
        {
            Debug.Log($"{player.Value.NickName}, {player.Value.ActorNumber}");
        }

        Transform[] points = GameObject.Find("CreatePlayerGroup").GetComponentsInChildren<Transform>();
        int idx = Random.Range(1, points.Length);

        // ���� �÷��̾� ���� �� PhotonView ����
        localPlayer = PhotonNetwork.Instantiate("Player", points[idx].position, points[idx].rotation, 0);

        // ī�޶� ���� �� ���� �÷��̾ �Ҵ�
        GameObject camera = Instantiate(Resources.Load<GameObject>("Camera"));  // Camera Prefab�� Resources���� �ε��Ͽ� ����
        camera.GetComponent<CameraFollow>().SetTarget(localPlayer.transform);
    }

    private void Update()
    {
    }
}
