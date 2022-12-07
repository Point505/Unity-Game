using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;


public class RoomPlayer : NetworkRoomPlayer
{
    [SyncVar] // 네트워크 통해 동기화
    public EPlayerColor playerColor;

    public void Start()
    {
        base.Start();

        if (isServer)
        {
            SpawnLobbyPlayerCharacter();
        }
    }

    private void SpawnLobbyPlayerCharacter()
    {
        // 대기실에 접속 중인 플레이어를 가져옴
        var roomSlots = (NetworkManager.singleton as RoomManager).roomSlots;
        EPlayerColor color = EPlayerColor.Red;
        // 플레이어들이 든 roomSlots를 돌면서 사용하지 않는 색상 고름
        for (int i = 0; i < (int)EPlayerColor.Lime + 1; i++)
        {
            bool isFindSameColor = false;
            foreach (var roomPlayer in roomSlots)
            {
                var amongUsRoomPlayer = roomPlayer as RoomPlayer;
                if (amongUsRoomPlayer.playerColor == (EPlayerColor)i && roomPlayer.netId != netId)
                {
                    isFindSameColor = true;
                    break;
                }
            }
            if (!isFindSameColor)
            {
                color = (EPlayerColor)i;
                break;
            }
        }
        // 자신의 색상으로 지정
        playerColor = color;

        // AmongUsRoomManager에서 옮겨옴
       // Vector3 spawnPos = FindObjectOfType<SpawnPositions>().GetSpawnPosition();


        var playerCharacter = Instantiate(RoomManager.singleton.spawnPrefabs[0].GetComponent<CharacterMover>());
        NetworkServer.Spawn(playerCharacter.gameObject, connectionToClient);
        playerCharacter.playerColor = color;
        // 

    }
}