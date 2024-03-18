using Zenject;

namespace Workspace.CodeBase.Networking.Connection
{
    public class ConnectionServiceInstaller : MonoInstaller
    {
        public override void InstallBindings() 
            => Container.BindInterfacesTo<ConnectionService>()
                .AsSingle();
    }
}