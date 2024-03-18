using System.Collections.Generic;
using Photon.Realtime;

namespace Workspace.CodeBase.Networking.Rooms
{
    public class MatchMakingCallbacksHandler : IMatchmakingCallbacks
    {
        public virtual void OnFriendListUpdate(List<FriendInfo> friendList)
        { }

        public virtual void OnCreatedRoom()
        { }

        public virtual void OnCreateRoomFailed(short returnCode, string message)
        { }

        public virtual void OnJoinedRoom()
        { }

        public virtual void OnJoinRoomFailed(short returnCode, string message)
        { }

        public virtual void OnJoinRandomFailed(short returnCode, string message)
        { }

        public virtual void OnLeftRoom()
        { }
    }
}