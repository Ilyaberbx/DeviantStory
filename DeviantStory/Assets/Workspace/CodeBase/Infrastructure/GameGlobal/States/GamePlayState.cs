using Cysharp.Threading.Tasks;
using UnityEngine.SceneManagement;
using Workspace.CodeBase.Infrastructure.Service.StateMachineSystem.State;
using Workspace.CodeBase.Networking;
using Workspace.CodeBase.Networking.Connection;
using Workspace.CodeBase.Networking.Rooms;
using Workspace.CodeBase.Services.Assets;
using Workspace.CodeBase.Services.Logging;
using Workspace.CodeBase.Services.SceneManagement;
using Workspace.CodeBase.UI.LoadingCurtain;

namespace Workspace.CodeBase.Infrastructure.GameGlobal.States
{
    public class GamePlayState : IState
    {
        private readonly IAssetsProvider _assets;
        private readonly ISceneLoader _sceneLoader;
        private readonly ILoadingCurtain _curtain;
        private readonly ILogService _logger;
        private readonly IConnectionService _connectionService;
        private readonly IRoomsService _roomsService;

        public GamePlayState(IAssetsProvider assets
            , ISceneLoader sceneLoader
            , ILoadingCurtain curtain
            , ILogService logger
            , IConnectionService connectionService
            , IRoomsService roomsService)
        {
            _assets = assets;
            _sceneLoader = sceneLoader;
            _curtain = curtain;
            _logger = logger;
            _connectionService = connectionService;
            _roomsService = roomsService;
        }

        public async UniTask Enter()
        {
            _curtain.Show();

            _logger.LogInfrastructure("Gameplay state");
            
            await _assets.WarmUpAssetsByLabel(AssetsLabels.Gameplay);
            await _sceneLoader.LoadAsync(SceneNames.Gameplay, LoadSceneMode.Single);
            await _connectionService.ConnectToMasterServer();
            await _roomsService.JoinOrCreateRoom();
            
            _curtain.Hide();
        }

        public async UniTask Exit()
        {
            _curtain.Show();
            await _assets.ReleaseAssetsByLabel(AssetsLabels.Gameplay);
        }
    }
}