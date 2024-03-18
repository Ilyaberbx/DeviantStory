using Cysharp.Threading.Tasks;

namespace Workspace.CodeBase.Networking
{
    public interface IConnectionService
    {
        UniTask ConnectToMasterServer();
        void Disconnect();
    }
}