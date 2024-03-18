using Zenject;

namespace Workspace.CodeBase.Networking.Rooms
{
    public class RoomsServiceInstaller : MonoInstaller
    {
        public override void InstallBindings() 
            => Container.BindInterfacesTo<RoomsService>()
                .AsSingle();
    }
}