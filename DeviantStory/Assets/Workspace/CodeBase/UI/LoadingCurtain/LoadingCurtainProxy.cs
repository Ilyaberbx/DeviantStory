using Cysharp.Threading.Tasks;
using UnityEngine.AddressableAssets;
using Workspace.CodeBase.Services.Factory;

namespace Workspace.CodeBase.UI.LoadingCurtain
{
    public class LoadingCurtainProxy : ILoadingCurtain
    {
        private readonly AssetReference _curtainReference;
        private readonly IPrefabFactoryAsync _factory;
        private LoadingCurtain _curtain;

        public LoadingCurtainProxy(AssetReference curtainReference
            , IPrefabFactoryAsync factory)
        {
            _curtainReference = curtainReference;
            _factory = factory;
        }

        public async UniTask Initialize()
            => _curtain = await _factory.Create<LoadingCurtain>(_curtainReference);

        public async UniTask Show()
            => await _curtain.Show();

        public void ShowImmediately()
            => _curtain.ShowImmediately();

        public async UniTask Hide()
            => await _curtain.Hide();

        public void Cancel()
            => _curtain.Cancel();
    }
}