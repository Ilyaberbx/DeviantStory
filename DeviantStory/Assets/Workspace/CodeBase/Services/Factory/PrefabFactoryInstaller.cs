using Zenject;

namespace Workspace.CodeBase.Services.Factory
{
    public class PrefabFactoryInstaller : MonoInstaller
    {
        public override void InstallBindings() 
            => BindPrefabFactory();

        private void BindPrefabFactory() 
            => Container.BindInterfacesTo<PrefabFactoryAsync>()
                .AsSingle();
    }
}