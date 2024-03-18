using Zenject;

namespace Workspace.CodeBase.Networking
{
    public class ConnectionServiceInstaller : MonoInstaller
    {
        public override void InstallBindings() 
            => Container.BindInterfacesTo<ConnectionService>()
                .AsSingle();
    }
}