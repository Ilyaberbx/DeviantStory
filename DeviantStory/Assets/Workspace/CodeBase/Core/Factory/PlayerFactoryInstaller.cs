using UnityEngine;
using UnityEngine.AddressableAssets;
using Zenject;

namespace Workspace.CodeBase.Core.Factory
{
    public class PlayerFactoryInstaller : MonoInstaller
    {
        [SerializeField] private AssetReference _playerReference;
        
        public override void InstallBindings() 
            => Container.Bind<PlayerFactory>()
                .AsSingle()
                .WithArguments(_playerReference);
    }
}