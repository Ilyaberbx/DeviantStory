using Zenject;

namespace Workspace.CodeBase.Services.SceneManagement
{
    public class SceneLoaderInstaller : MonoInstaller
    {
        public override void InstallBindings() 
            => Container.BindInterfacesTo<SceneLoader>()
                .AsSingle();
    }
}