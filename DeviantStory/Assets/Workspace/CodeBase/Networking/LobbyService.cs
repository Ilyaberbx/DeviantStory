using Photon.Pun;
using UnityEngine;
using Workspace.CodeBase.Services.Logging;

namespace Workspace.CodeBase.Networking
{
    public class LobbyService : ILobbyService
    {
        private readonly ILogService _logger;

        public LobbyService(ILogService logger)
            => _logger = logger;

        public void Start()
        {
            PhotonNetwork.NickName = "Player" + Random.Range(1, 1000);
            PhotonNetwork.GameVersion = "0.1";
            PhotonNetwork.AutomaticallySyncScene = true;
            PhotonNetwork.ConnectUsingSettings();

            _logger.Log("Player's name is set to: " + PhotonNetwork.NickName);
        }
    }
}