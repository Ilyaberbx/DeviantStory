using System;
using System.Collections.Generic;
using System.Linq;
using Sirenix.OdinInspector;
using Sirenix.Utilities;
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
        {
            IEnumerable<Type> types = typeof(IBootstrapper).Assembly.GetTypes()
                .Where(x => !x.IsAbstract)
                .Where(x => !x.IsGenericTypeDefinition)
                .Where(x => x.ImplementsOrInherits(typeof(IBootstrapper)));

            return types;
        }
    }
}