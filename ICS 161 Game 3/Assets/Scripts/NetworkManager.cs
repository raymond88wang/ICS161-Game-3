using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NetworkManager : MonoBehaviour
{

    [SerializeField]
    Transform[] spawnPoints;

    private GameObject player;

    private void Start()
    {
        PhotonNetwork.logLevel = PhotonLogLevel.Full;
        PhotonNetwork.ConnectUsingSettings("0.2"); // version number

    }

    private void OnJoinedLobby()
    {
        RoomOptions ro = new RoomOptions() { IsVisible = true, MaxPlayers = 2 };
        PhotonNetwork.JoinOrCreateRoom("Game", ro, TypedLobby.Default);
    }

    private void LoadLevel()
    {
        PhotonNetwork.LoadLevel("Level 1 - Tutorial");
    }

    private void SpawnPlayer()
    {
        if (PhotonNetwork.room.PlayerCount == 1)
        {
            PhotonNetwork.Instantiate("Player", spawnPoints[0].position, spawnPoints[0].rotation, 0);
        }
        else
        {
            PhotonNetwork.Instantiate("Player", spawnPoints[1].position, spawnPoints[1].rotation, 0);

        }
    }

}
