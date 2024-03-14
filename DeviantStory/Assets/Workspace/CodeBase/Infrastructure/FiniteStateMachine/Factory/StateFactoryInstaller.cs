using Zenject;

namespace Workspace.CodeBase.Infrastructure.FiniteStateMachine.Factory
{
    public class StateFactoryInstaller : MonoInstaller
    {
        public override void InstallBindings() 
            => BindStateFactory();

        private void BindStateFactory() 
            => Container.BindInterfacesTo<StateFactory>()
                .AsSingle()
                .NonLazy();

    }
}