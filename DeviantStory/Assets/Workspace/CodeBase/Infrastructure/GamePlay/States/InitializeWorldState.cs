using Cysharp.Threading.Tasks;
using UnityEngine;
using Workspace.CodeBase.Core.Factory;
using Workspace.CodeBase.Infrastructure.Service.StateMachineSystem.State;

namespace Workspace.CodeBase.Infrastructure.GamePlay.States
{
    public class InitializeWorldState : IState
    {
        private readonly PlayerFactory _playerFactory;

        public InitializeWorldState(PlayerFactory playerFactory) 
            => _playerFactory = playerFactory;

        public async UniTask Enter() 
            => await _playerFactory.Create(Vector3.zero);

        public UniTask Exit()
            => default;
    }
}