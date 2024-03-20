using Cysharp.Threading.Tasks;
using Workspace.CodeBase.Infrastructure.FiniteStateMachine.Factory;
using Workspace.CodeBase.Infrastructure.GamePlay.States;

namespace Workspace.CodeBase.Infrastructure.GamePlay.Root
{
    public class GameplayBootstrapper : IBootstrapper
    {
        private readonly IStateFactory _factory;
        private readonly GameplayStateMachine _stateMachine;

        public GameplayBootstrapper(IStateFactory factory
            , GameplayStateMachine stateMachine)
        {
            _factory = factory;
            _stateMachine = stateMachine;
        }

        public void Initialize()
        {
            _stateMachine.RegisterState(_factory.Create<InitializeWorldState>());
            _stateMachine.Enter<InitializeWorldState>().Forget();
        }
    }
}