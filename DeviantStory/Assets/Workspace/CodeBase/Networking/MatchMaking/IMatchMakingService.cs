using Cysharp.Threading.Tasks;

namespace Workspace.CodeBase.Networking.MatchMaking
{
    public interface IMatchMakingService
    {
        UniTask JoinOrCreateRoom();
    }
}