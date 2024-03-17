using Cysharp.Threading.Tasks;
using UnityEngine.SceneManagement;
using Workspace.CodeBase.Infrastructure.Service.StateMachineSystem.State;
using Workspace.CodeBase.Services.Assets;
using Workspace.CodeBase.Services.SceneManagement;

namespace Workspace.CodeBase.Infrastructure.GameGlobal.States
{
    public class GamePlayState : IState
    {
        private readonly IAssetsProvider _assets;
        private readonly ISceneLoader _sceneLoader;

        public GamePlayState(IAssetsProvider assets, ISceneLoader sceneLoader)
        {
            _assets = assets;
            _sceneLoader = sceneLoader;
        }

        public async UniTask Enter()
        {
            await _assets.WarmUpAssetsByLabel(AssetsLabels.Gameplay);
            _sceneLoader.LoadAsync(SceneNames.Gameplay, LoadSceneMode.Single).Forget();
        }

        public UniTask Exit() 
            => _assets.ReleaseAssetsByLabel(AssetsLabels.Gameplay);
    }
}