using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using Photon.Pun;
using UnityEngine.SceneManagement;
using Workspace.CodeBase.Infrastructure.Service.StateMachineSystem.State;
using Workspace.CodeBase.Networking.Connection;
using Workspace.CodeBase.Networking.Factory;
using Workspace.CodeBase.Networking.MatchMaking;
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
        private readonly IMatchMakingService _matchMakingService;

        public GamePlayState(IAssetsProvider assets
            , ISceneLoader sceneLoader
            , ILoadingCurtain curtain
            , ILogService logger
            , IConnectionService connectionService
            , IMatchMakingService matchMakingService)
        {
            _assets = assets;
            _sceneLoader = sceneLoader;
            _curtain = curtain;
            _logger = logger;
            _connectionService = connectionService;
            _matchMakingService = matchMakingService;
        }

        public async UniTask Enter()
        {
            _curtain.Show();

            _logger.LogInfrastructure("Gameplay state");

            await _connectionService.ConnectToServer();


            await _assets.WarmUpAssetsByLabel(AssetsLabels.Gameplay);
            await _assets.WarmUpAssetsByLabel(AssetsLabels.Networking);
            
            await InitializePool();
            await _matchMakingService.JoinOrCreateRoom();


            await _sceneLoader.LoadAsync(SceneNames.Gameplay, LoadSceneMode.Single);


            _curtain.Hide();
        }

        private async UniTask InitializePool()
        {
            PunAddressablesPool punPrefabPool = new PunAddressablesPool(_logger, _assets);
            await punPrefabPool.Initialize();
            PhotonNetwork.PrefabPool = punPrefabPool;
        }

        public async UniTask Exit()
        {
            _curtain.Show();
            await _assets.ReleaseAssetsByLabel(AssetsLabels.Gameplay);
            await _assets.ReleaseAssetsByLabel(AssetsLabels.Networking);
        }
    }
}