using Zenject;

namespace Workspace.CodeBase.Infrastructure.GamePlay.Root
{
    public class GameplayBootstrapperInstaller : MonoInstaller
    {
        public override void InstallBindings() 
            => Container.BindInterfacesTo<GameplayBootstrapper>()
                .AsSingle();
    }
}