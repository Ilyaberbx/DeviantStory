using Cysharp.Threading.Tasks;

namespace Workspace.CodeBase.Infrastructure.Service.StateMachineSystem.State
{
    public interface IExitableState
    {
        UniTask Exit();
    }
}