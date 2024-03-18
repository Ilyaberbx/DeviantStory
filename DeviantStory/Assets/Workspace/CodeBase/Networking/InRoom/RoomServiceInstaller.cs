using Zenject;

namespace Workspace.CodeBase.Networking.InRoom
{
    public class RoomServiceInstaller : MonoInstaller
    {
        public override void InstallBindings() 
            => Container.BindInterfacesTo<RoomService>()
                .AsSingle();
    }
}