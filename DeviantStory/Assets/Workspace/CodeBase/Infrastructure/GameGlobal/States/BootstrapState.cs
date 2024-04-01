using System;
using Cysharp.Threading.Tasks;
using Workspace.CodeBase.Infrastructure.Service.StateMachineSystem.State;
using Workspace.CodeBase.Services.Logging;
using Workspace.CodeBase.UI.LoadingCurtain;

namespace Workspace.CodeBase.Infrastructure.GameGlobal.States
{
    public class BootstrapState : IState
    {
        private readonly GlobalStateMachine _stateMachine;
        private readonly LoadingCurtainProxy _curtainProxy;
        private readonly ILogService _logger;

        public BootstrapState(GlobalStateMachine stateMachine,
            LoadingCurtainProxy curtainProxy,
            ILogService logger)
        {
            _stateMachine = stateMachine;
            _curtainProxy = curtainProxy;
            _logger = logger;
        }

        public async UniTask Enter()
        {
            await InitializeServices();
            
           // Application.targetFrameRate = 5;
            _logger.LogInfrastructure("Bootstrap globals");
            _stateMachine.Enter<GamePlayState>().Forget();
        }
        
        private async UniTask InitializeServices()
        {
            await _logger.Initialize();
            await _curtainProxy.Initialize();
        }

        public UniTask Exit()
            => default;
    }
    
}