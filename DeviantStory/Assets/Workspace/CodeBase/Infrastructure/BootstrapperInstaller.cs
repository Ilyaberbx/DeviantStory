using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using Workspace.CodeBase.Extensions;
using Zenject;

namespace Workspace.CodeBase.Infrastructure
{
    public class BootstrapperInstaller : MonoInstaller
    {
        [TypeFilter("GetFilteredTypeList"), ShowInInspector]
        private IBootstrapper _bootstrapper;

        public override void InstallBindings() =>
            Container.BindInterfacesTo(_bootstrapper.GetType())
                .AsSingle();
        
        public IEnumerable<Type> GetFilteredTypeList() 
            => typeof(IBootstrapper).GetNonGenericInheritedTypes();
    }
}