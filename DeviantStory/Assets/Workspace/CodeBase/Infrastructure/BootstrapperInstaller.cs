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
        public IBootstrapper BootstrapperType { get; private set; }
        
        public override void InstallBindings() =>
            Container.BindInterfacesTo(BootstrapperType.GetType())
                .AsSingle()
                .NonLazy();
        
        public IEnumerable<Type> GetFilteredTypeList() 
            => typeof(IBootstrapper).GetNonGenericInheritedTypes();
    }
}