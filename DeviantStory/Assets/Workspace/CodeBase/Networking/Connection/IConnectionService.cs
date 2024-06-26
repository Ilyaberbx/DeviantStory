using Cysharp.Threading.Tasks;

namespace Workspace.CodeBase.Networking.Connection
{
    public interface IConnectionService
    {
        bool IsConnected { get; }
        UniTask ConnectToServer();
        void Disconnect();
    }
}