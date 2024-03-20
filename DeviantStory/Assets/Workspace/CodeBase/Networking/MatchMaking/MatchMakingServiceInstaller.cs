using Zenject;

namespace Workspace.CodeBase.Networking.MatchMaking
{
    public class MatchMakingServiceInstaller : MonoInstaller
    {
        public override void InstallBindings() 
            => Container.BindInterfacesTo<MatchMakingService>()
                .AsSingle();
    }
}