using System;
using Workspace.CodeBase.Infrastructure.Service.StateMachineSystem.State;
using Zenject;

namespace Workspace.CodeBase.Infrastructure.FiniteStateMachine.Factory
{
    public class StateFactory : IStateFactory
    {
        private readonly IInstantiator _instantiator;

        public StateFactory(IInstantiator instantiator) => 
            _instantiator = instantiator;

        public TState Create<TState>() where TState : IExitableState => 
            _instantiator.Instantiate<TState>();

        public TState Create<TState>(Type type) where TState : IExitableState 
            => (TState)_instantiator.Instantiate(type);

        public TState Create<TState>(object[] arguments) where TState : IExitableState => 
            _instantiator.Instantiate<TState>(arguments);
    }
}