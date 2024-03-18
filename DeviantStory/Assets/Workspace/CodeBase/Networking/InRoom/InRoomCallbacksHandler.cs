using ExitGames.Client.Photon;
using Photon.Realtime;

namespace Workspace.CodeBase.Networking.InRoom
{
    public class InRoomCallbacksHandler : IInRoomCallbacks
    {
        public virtual void OnPlayerEnteredRoom(Player newPlayer)
        {
        }

        public virtual void OnPlayerLeftRoom(Player otherPlayer)
        {
        }

        public virtual void OnRoomPropertiesUpdate(Hashtable propertiesThatChanged)
        {
        }

        public virtual void OnPlayerPropertiesUpdate(Player targetPlayer, Hashtable changedProps)
        {
        }

        public virtual void OnMasterClientSwitched(Player newMasterClient)
        {
        }
    }
}