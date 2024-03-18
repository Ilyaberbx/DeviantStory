using Zenject;

namespace Workspace.CodeBase.Infrastructure.GameGlobal.Root
{
    public class GlobalBootstrapperInstaller : MonoInstaller
    {
        public override void InstallBindings() 
            => Container.BindInterfacesTo<GlobalBootstrapper>()
                .AsSingle();
    }
}