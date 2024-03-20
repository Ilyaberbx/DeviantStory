using Zenject;

namespace Workspace.CodeBase.Networking.Factory
{
    public class NetworkFactoryInstaller : MonoInstaller
    {
        public override void InstallBindings() 
            => Container.BindInterfacesTo<NetworkFactory>()
                .AsSingle();
    }
}