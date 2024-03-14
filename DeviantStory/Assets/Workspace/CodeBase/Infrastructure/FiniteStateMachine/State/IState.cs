using Cysharp.Threading.Tasks;

namespace Workspace.CodeBase.Infrastructure.Service.StateMachineSystem.State
{
    public interface IState : IExitableState
    {
        UniTask Enter();
    }
}