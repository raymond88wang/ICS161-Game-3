using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Launcher : Photon.PunBehaviour
{
    #region Public Variables

    public PhotonLogLevel Loglevel = PhotonLogLevel.Informational;
 
    [Tooltip("The maximum number of players per room. When a room is full, it can't be joined by new players, and so new room will be created")]
    public byte MaxPlayersPerRoom = 2;

    #endregion


    #region Private Variables

    string _gameVersion = "1";

    bool isConnecting;

    #endregion


    #region MonoBehaviour CallBacks


    private void Awake()
    {

        //#Critical
        // we don't join the lobby.  There is no need to join a lobby to get the list of rooms.
        PhotonNetwork.autoJoinLobby = false;

        //#critical
        // this makes sure we can use PhotonNetwork.LoadLevel() on the master client and all clients on the same room sync their level automatically
        PhotonNetwork.automaticallySyncScene = true;

        // #NotImportant
        // Force LogLevel
        PhotonNetwork.logLevel = Loglevel;
    }

    private void Start()
    {
        progressLabel.SetActive(false);
        controlPanel.SetActive(true);
    }

    #endregion

    #region Public Methods

    /// <summary>
    /// Start the connection process. 
    /// - If already connected, we attempt joining a random room
    /// - if not yet connected, Connect this application instance to Photon Cloud Network
    /// </summary>
    public void Connect()
    {
        // keep track of the will to join a room, because when we come back from the game we will get a callback that we are connected, so we need to know what to do then
        isConnecting = true;

        progressLabel.SetActive(true);
        controlPanel.SetActive(false);

        // we check if we are connected or not, we join if we are , else we initiate the connection to the server.
        if (PhotonNetwork.connected)
        {
            // #Critical we need at this point to attempt joining a Room. If it fails, we'll get notified in OnPhotonRandomJoinFailed() and we'll create one.
            RoomOptions ro = new RoomOptions() { IsVisible = true, MaxPlayers = 2 };
            PhotonNetwork.JoinOrCreateRoom("Game", ro, TypedLobby.Default);
        }
        else
        {
            // #Critical, we must first and foremost connect to Photon Online Server.
            PhotonNetwork.ConnectUsingSettings(_gameVersion);
        }
    }

    #endregion


    #region Photon.PunBehaviour CallBacks

    public override void OnConnectedToMaster()
    {
        if (isConnecting)
        {
            // #Critical: The first we try to do is to join a potential existing room. If there is, good, else, we'll be called back with OnPhotonRandomJoinFailed()  
            RoomOptions ro = new RoomOptions() { IsVisible = true, MaxPlayers = 2 };
            PhotonNetwork.JoinOrCreateRoom("Game", ro, TypedLobby.Default);
        }
    }

    public override void OnDisconnectedFromPhoton()
    {
        progressLabel.SetActive(false);
        controlPanel.SetActive(true);
    }

    
    public override void OnJoinedRoom()
    {
        // #Critical: We only load if we are the first player, else we rely on  PhotonNetwork.automaticallySyncScene to sync our instance scene.
        if (PhotonNetwork.room.PlayerCount == 1)
        {
            PhotonNetwork.LoadLevel("Level 1 - Tutorial"); //or maybe a different scene called wait
        }
    }
    

    #endregion


    #region Public Properties

    [Tooltip("The Ui Panel to let the user enter name, connect and play")]
    public GameObject controlPanel;
    [Tooltip("The UI Label to inform the user that the connection is in progress")]
    public GameObject progressLabel;

    #endregion
}


