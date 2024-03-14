using Workspace.CodeBase.Infrastructure.Service.StateMachineSystem.State;

namespace Workspace.CodeBase.Infrastructure.FiniteStateMachine.Factory
{
    public interface IStateFactory
    {
        TState Create<TState>() where TState : IExitableState;
        TState Create<TState>(object[] arguments) where TState : IExitableState;
    }
}