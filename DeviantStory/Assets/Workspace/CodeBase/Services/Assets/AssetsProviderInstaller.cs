using Zenject;

namespace Workspace.CodeBase.Services.Assets
{
    public class AssetsProviderInstaller : MonoInstaller
    {
        public override void InstallBindings() 
            => Container.BindInterfacesTo<AssetsProvider>()
                .AsSingle();
    }
}