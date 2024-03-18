using System.Collections.Generic;
using Photon.Realtime;

namespace Workspace.CodeBase.Networking.Connection
{
    public abstract class ConnectionCallbacksHandler : IConnectionCallbacks
    {
        public virtual void OnConnected()
        {
        }

        public virtual void OnConnectedToMaster()
        {
        }

        public virtual void OnDisconnected(DisconnectCause cause)
        {
        }

        public virtual void OnRegionListReceived(RegionHandler regionHandler)
        {
        }

        public virtual void OnCustomAuthenticationResponse(Dictionary<string, object> data)
        {
        }

        public virtual void OnCustomAuthenticationFailed(string debugMessage)
        {
        }
        
    }
}