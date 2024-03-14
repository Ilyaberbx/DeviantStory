using Workspace.CodeBase.Infrastructure.FiniteStateMachine;
using Workspace.CodeBase.Infrastructure.FiniteStateMachine.Factory;

namespace Workspace.CodeBase.Infrastructure.GameGlobal.Root
{
    public class GlobalBootstrapper : IBootstrapper
    {
        private readonly IStateFactory _factory;
        private readonly StateMachine _stateMachine;

        public GlobalBootstrapper(IStateFactory factory
            , StateMachine stateMachine)
        {
            _factory = factory;
            _stateMachine = stateMachine;
        }

        public void Initialize()
        {
            
        }
    }
}