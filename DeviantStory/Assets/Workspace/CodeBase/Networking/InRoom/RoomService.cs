using System;
using Photon.Pun;
using Photon.Realtime;
using Workspace.CodeBase.Services.Logging;
using Zenject;

namespace Workspace.CodeBase.Networking.InRoom
{
    public class RoomService : InRoomCallbacksHandler
        , IRoomService
        , IInitializable
        , IDisposable
    {
        private readonly ILogService _logger;

        public RoomService(ILogService logger)
            => _logger = logger;

        public Room CurrentRoom => PhotonNetwork.CurrentRoom;

        public void Initialize() 
            => PhotonNetwork.AddCallbackTarget(this);

        public void Dispose() 
            => PhotonNetwork.RemoveCallbackTarget(this);

        public void LeaveRoom()
            => PhotonNetwork.LeaveRoom();

        public override void OnPlayerEnteredRoom(Player newPlayer)
            => _logger.LogNetworking(newPlayer.NickName + " entered room");

        public override void OnPlayerLeftRoom(Player otherPlayer)
            => _logger.LogNetworking(otherPlayer.NickName + " left room");
    }
}