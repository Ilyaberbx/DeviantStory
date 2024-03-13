using Photon.Pun;
using UnityEngine;
using Workspace.Workspace.CodeBase.Utiliting;

namespace Workspace.CodeBase.Networking
{
    public class LobbyService
    {
        public void Start()
        {
            PhotonNetwork.NickName = "Player" + Random.Range(1, 1000);
            PhotonNetwork.GameVersion = "0.1";
            PhotonNetwork.AutomaticallySyncScene = true;
            PhotonNetwork.ConnectUsingSettings();

            Utilities.Logger.Log("Player's name is set to: " + PhotonNetwork.NickName);
        }
    }
}