using Cysharp.Threading.Tasks;
using Workspace.CodeBase.Infrastructure.Service.StateMachineSystem.State;

namespace Workspace.CodeBase.Infrastructure.GameGlobal.States
{
    public class BootstrapState : IState
    {
        private readonly GlobalStateMachine _stateMachine;

        public BootstrapState(GlobalStateMachine stateMachine)
            => _stateMachine = stateMachine;

        public UniTask Enter()
        {
            _stateMachine.Enter<GamePlayState>().Forget();
            return default;
        }

        public UniTask Exit()
            => default;
    }
}