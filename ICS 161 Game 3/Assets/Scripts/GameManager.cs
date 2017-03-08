using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

namespace Com.MyCompany.MyGame
{
    public class GameManager : Photon.PunBehaviour
    {
        #region Public Variables

        [Tooltip("The prefab to use for representing the player")]
        public GameObject playerPrefab;

        [SerializeField]
        Transform[] spawnPoints;

        #endregion


        #region Photon Messages

        public void OnLeftRoom() // not used
        {
            SceneManager.LoadScene(0); 
        }

        #endregion


        #region Public Methods

        public void LeaveRoom()
        {
            PhotonNetwork.LeaveRoom(); // not used
        }

        #endregion


        #region Private Methods

        private void Start()
        {
            if (PhotonNetwork.player == PhotonNetwork.playerList[0])
            {

                PhotonNetwork.Instantiate(playerPrefab.name, spawnPoints[0].position, spawnPoints[0].rotation, 0);
            }
            if (PhotonNetwork.room.PlayerCount == 2 && PhotonNetwork.player == PhotonNetwork.playerList[1])
            {
                PhotonNetwork.Instantiate(playerPrefab.name, spawnPoints[1].position, spawnPoints[1].rotation, 0);

            }
        }

        void LoadArena()
        {
            PhotonNetwork.LoadLevel("Level 1 - Tutorial");
        }

        #endregion


        #region Photon Messages


        public override void OnPhotonPlayerConnected(PhotonPlayer other)
        {
            if (PhotonNetwork.isMasterClient)
            {
                //LoadArena(); //load tutorial?
            }
        }


        public override void OnPhotonPlayerDisconnected(PhotonPlayer other)
        {
            if (PhotonNetwork.isMasterClient)
            {
                //LoadArena();//maybe load wait scene?
            }
        }


        #endregion
    }
}
