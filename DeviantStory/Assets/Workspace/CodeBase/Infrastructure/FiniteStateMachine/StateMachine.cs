using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Workspace.CodeBase.Infrastructure.Service.StateMachineSystem.State;
using Zenject;

namespace Workspace.CodeBase.Infrastructure.FiniteStateMachine
{
    public abstract class StateMachine : ITickable, IFixedTickable
    {
        private readonly Dictionary<Type, IExitableState> _registeredStates = new();
        private IExitableState _currentState;
        private ITickable _tickableState;
        private IFixedTickable _fixedTickableState;

        public async UniTask Enter<TState>() where TState : class, IState
        {
            TState newState = await ChangeState<TState>();

            await newState.Enter();

            CollectTickables<TState>();
        }
        
        public async UniTask Enter<TState, TPayload>(TPayload payload) where TState : class, IPayloadedState<TPayload>
        {
            TState newState = await ChangeState<TState>();

            await newState.Enter(payload);

            CollectTickables<TState>();
        }

        public async UniTask Enter<TState, TPayloadFirst, TPayloadSecond>(TPayloadFirst payloadFirst,
            TPayloadSecond payloadSecond) where TState : class, IPayloadedState<TPayloadFirst, TPayloadSecond>
        {
            TState newState = await ChangeState<TState>();

            await newState.Enter(payloadFirst, payloadSecond);

            CollectTickables<TState>();
        }

        private void CollectTickables<TState>() where TState : class, IExitableState
        {
            if (typeof(TState).IsAssignableFrom(typeof(ITickable)))
                _tickableState = _currentState as ITickable;

            if (typeof(TState).IsAssignableFrom(typeof(IFixedTickable)))
                _fixedTickableState = _currentState as IFixedTickable;
        }

        public void RegisterState(IExitableState state)
            => _registeredStates.Add(state.GetType(), state);

        public void Tick() 
            => _tickableState?.Tick();

        public void FixedTick() 
            => _fixedTickableState?.FixedTick();

        private async UniTask<TState> ChangeState<TState>() where TState : class, IExitableState
        {
            _tickableState = null;
            _fixedTickableState = null;

            if (_currentState != null)
                await _currentState.Exit();


            TState state = GetState<TState>();
            _currentState = state;
            return state;
        }

        private TState GetState<TState>() where TState : class, IExitableState =>
            _registeredStates[typeof(TState)] as TState;
    }
}