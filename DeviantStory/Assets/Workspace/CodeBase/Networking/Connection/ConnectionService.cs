using System;
using Cysharp.Threading.Tasks;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using Workspace.CodeBase.Services.Logging;
using Workspace.CodeBase.Services.SceneManagement;
using Zenject;
using Random = UnityEngine.Random;

namespace Workspace.CodeBase.Networking.Connection
{
    public class ConnectionService : ConnectionCallbacksHandler
        , IConnectionService
        , IInitializable
        , IDisposable
        , ITickable
    {
        private readonly ILogService _logger;
        private readonly ISceneLoader _sceneLoader;
        private UniTaskCompletionSource _connectionCompletionSource;

        public ConnectionService(ILogService logger
            , ISceneLoader sceneLoader)
        {
            _logger = logger;
            _sceneLoader = sceneLoader;
        }

        public bool IsConnected => PhotonNetwork.IsConnected;

        public void Initialize()
            => PhotonNetwork.AddCallbackTarget(this);

        public void Dispose()
            => PhotonNetwork.RemoveCallbackTarget(this);

        public void Tick()
        {
            if (Input.GetKeyDown(KeyCode.D))
                Disconnect();
        }

        public async UniTask ConnectToMasterServer()
        {
            PhotonNetwork.NickName = "Player" + Random.Range(1, 1000);
            PhotonNetwork.GameVersion = "0.1";

            _logger.LogNetworking("Player's name is set to: " + PhotonNetwork.NickName);
            _logger.LogNetworking("Game version: " + PhotonNetwork.GameVersion);

            _connectionCompletionSource = new UniTaskCompletionSource();

            PhotonNetwork.ConnectUsingSettings();

            await _connectionCompletionSource.Task;
        }

        public void Disconnect()
            => PhotonNetwork.Disconnect();

        public override void OnConnectedToMaster()
        {
            _logger.LogNetworking("Connected to master");
            _connectionCompletionSource.TrySetResult();
        }

        public override void OnConnected()
            => _logger.LogNetworking("Low level connection established");

        public override void OnDisconnected(DisconnectCause cause)
            => _logger.LogNetworking("Disconnected by cause " + cause);
    }
}