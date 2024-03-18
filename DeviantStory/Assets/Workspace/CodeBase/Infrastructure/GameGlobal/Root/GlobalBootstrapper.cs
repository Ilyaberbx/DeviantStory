using Cysharp.Threading.Tasks;
using Workspace.CodeBase.Infrastructure.FiniteStateMachine.Factory;
using Workspace.CodeBase.Infrastructure.GameGlobal.States;

namespace Workspace.CodeBase.Infrastructure.GameGlobal.Root
{
    public class GlobalBootstrapper : IBootstrapper
    {
        private readonly IStateFactory _factory;
        private readonly GlobalStateMachine _stateMachine;

        public GlobalBootstrapper(IStateFactory factory
            , GlobalStateMachine stateMachine)
        {
            _factory = factory;
            _stateMachine = stateMachine;
        }

        public void Initialize()
        {
            _stateMachine.RegisterState(_factory.Create<BootstrapState>());
            _stateMachine.RegisterState(_factory.Create<GamePlayState>());
            _stateMachine.RegisterState(_factory.Create<GameLoadingState>());

            _stateMachine.Enter<BootstrapState>().Forget();
        }
    }
}