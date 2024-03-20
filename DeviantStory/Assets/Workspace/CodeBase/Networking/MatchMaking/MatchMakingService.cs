using System;
using Cysharp.Threading.Tasks;
using Photon.Pun;
using Photon.Realtime;
using Workspace.CodeBase.Networking.Connection;
using Workspace.CodeBase.Services.Logging;
using Zenject;

namespace Workspace.CodeBase.Networking.MatchMaking
{
    public class MatchMakingService : MatchMakingCallbacksHandler
        , IMatchMakingService
        , IInitializable
        , IDisposable
    {
        private readonly IConnectionService _connectionService;
        private readonly ILogService _logger;

        private UniTaskCompletionSource _roomCreationTask;

        public MatchMakingService(IConnectionService connectionService
            , ILogService logger)
        {
            _connectionService = connectionService;
            _logger = logger;
        }

        public void Initialize() 
            => PhotonNetwork.AddCallbackTarget(this);

        public void Dispose() 
            => PhotonNetwork.RemoveCallbackTarget(this);

        public UniTask JoinOrCreateRoom()
        {
            if (!_connectionService.IsConnected)
            {
                _logger.LogNetworking("Can't create room cause of no connection to master server");
                return default;
            }

            _roomCreationTask = new UniTaskCompletionSource();
            
            _logger.LogNetworking("Room creation started");
            
            PhotonNetwork.JoinOrCreateRoom("RandomRoom", new RoomOptions { MaxPlayers = 3 }, TypedLobby.Default);

            return _roomCreationTask.Task;
        }

        public override void OnCreatedRoom()
        {
            _logger.LogNetworking("Room created");
            _roomCreationTask.TrySetResult();
        }

        public override void OnJoinedRoom()
        {
            _logger.LogNetworking("Room joined");
            _roomCreationTask.TrySetResult();
        }

        public override void OnCreateRoomFailed(short returnCode, string message) 
            => _logger.LogNetworking("Room creation failed: " + message);

        public override void OnJoinRoomFailed(short returnCode, string message) 
            => _logger.LogNetworking("Room join failed " + message);
    }
}