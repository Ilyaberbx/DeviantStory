using Cysharp.Threading.Tasks;
using UnityEngine;
using Workspace.CodeBase.Core.Camera;
using Workspace.CodeBase.Core.Factory;
using Workspace.CodeBase.Infrastructure.Service.StateMachineSystem.State;

namespace Workspace.CodeBase.Infrastructure.GamePlay.States
{
    public class InitializeWorldState : IState
    {
        private readonly PlayerFactory _playerFactory;
        private readonly ICameraService _cameraService;

        public InitializeWorldState(PlayerFactory playerFactory, ICameraService cameraService)
        {
            _playerFactory = playerFactory;
            _cameraService = cameraService;
        }

        public async UniTask Enter()
        {
            var player = await _playerFactory.Create(Vector3.zero);
            _cameraService.Initialize(player);
        }

        public UniTask Exit()
            => default;
    }
}