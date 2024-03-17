using Better.Attributes.Runtime.Select;
using UnityEngine;
using Zenject;

namespace Workspace.CodeBase.Infrastructure
{
    public class BootstrapperInstaller : MonoInstaller
    {
        [Select, SerializeReference]
        private IBootstrapper _bootstrapper;

        public override void InstallBindings() =>
            Container.BindInterfacesTo(_bootstrapper.GetType())
                .AsSingle();
        
    }
}