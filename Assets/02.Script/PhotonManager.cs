using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class PhotonManager : MonoBehaviourPunCallbacks
{
    private readonly string version = "1.0";
    private string UserID = "Me";

    private void Awake()
    {
        // 마스터 클라이언트 씬 자동동기화 시키기
        PhotonNetwork.AutomaticallySyncScene = true;
        // 게임버전 설정하기
        PhotonNetwork.GameVersion = version;
        // 접속 유저 닉네임 설정
        PhotonNetwork.NickName = UserID;
        // 포톤 서버 접속
        PhotonNetwork.ConnectUsingSettings();
    }

    // 포톤 서버에 접속 후 호출되는 함수
    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby()
    {
        PhotonNetwork.JoinRandomRoom();
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log("1");
        // 룸 옵션 설정
        RoomOptions roomOption = new RoomOptions();
        roomOption.MaxPlayers = 4;
        roomOption.IsOpen = true;
        roomOption.IsVisible = true;

        PhotonNetwork.CreateRoom("FPS", roomOption);
    }

    public override void OnCreatedRoom()
    {
        Debug.Log("2");
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("3");
        // 룸에 접속한 사용자 정보 조회
        foreach (var player in PhotonNetwork.CurrentRoom.Players)
        {
            Debug.Log($"{player.Value.NickName}, {player.Value.ActorNumber}");
        }

        // 위치 정보 배열로 지정해버리기
        Transform[] points = GameObject.Find("[Obj]SpawnPoint").GetComponentsInChildren<Transform>();
        int index = Random.Range(1, points.Length);

        // 캐릭터 생성
        PhotonNetwork.Instantiate("Player", points[index].position, points[index].rotation, 0);
    }
}
