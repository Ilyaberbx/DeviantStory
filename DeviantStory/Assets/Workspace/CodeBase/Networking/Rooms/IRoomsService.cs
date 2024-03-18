using Cysharp.Threading.Tasks;

namespace Workspace.CodeBase.Networking.Rooms
{
    public interface IRoomsService
    {
        UniTask JoinOrCreateRoom();
    }
}