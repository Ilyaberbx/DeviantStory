using UnityEngine;
using UnityEngine.AddressableAssets;
using Zenject;

namespace Workspace.CodeBase.Services.Logging
{
    public class LogServiceInstaller : MonoInstaller
    {
        [SerializeField] private AssetReference _logTableReference;

        public override void InstallBindings() =>
            Container.BindInterfacesTo<TextLogService>()
                .AsSingle()
                .WithArguments(_logTableReference);

    }
}