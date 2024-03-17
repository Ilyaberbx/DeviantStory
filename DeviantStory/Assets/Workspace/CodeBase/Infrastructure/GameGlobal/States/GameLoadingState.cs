using Cysharp.Threading.Tasks;
using UnityEngine.SceneManagement;
using Workspace.CodeBase.Services.Assets;
using Workspace.CodeBase.Services.SceneManagement;

namespace Workspace.CodeBase.Infrastructure.GameGlobal.States
{
    public class GameLoadingState
    {
        private readonly IAssetsProvider _assets;
        private readonly ISceneLoader _sceneLoader;

        public GameLoadingState(IAssetsProvider assets
            , ISceneLoader sceneLoader)
        {
            _assets = assets;
            _sceneLoader = sceneLoader;
        }

        public async UniTask Enter()
        {
            await _assets.WarmUpAssetsByLabel(AssetsLabels.GameLoading);
            _sceneLoader.LoadAsync(SceneNames.GameLoading, LoadSceneMode.Single).Forget();
        }

        public UniTask Exit()
            => _assets.ReleaseAssetsByLabel(AssetsLabels.GameLoading);
    }
}