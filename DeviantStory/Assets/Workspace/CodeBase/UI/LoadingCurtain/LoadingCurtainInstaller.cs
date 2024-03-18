using UnityEngine;
using UnityEngine.AddressableAssets;
using Zenject;

namespace Workspace.CodeBase.UI.LoadingCurtain
{
    public class LoadingCurtainInstaller : MonoInstaller
    {
        [SerializeField] private AssetReference _curtainReference;

        public override void InstallBindings() 
            => Container.BindInterfacesAndSelfTo<LoadingCurtainProxy>()
                .AsSingle()
                .WithArguments(_curtainReference);
    }
}