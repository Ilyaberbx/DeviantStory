using System;
using System.Collections.Generic;
using System.Linq;
using Sirenix.OdinInspector;
using Sirenix.Utilities;
using Zenject;

namespace Workspace.CodeBase.Services.Input
{
    public class InputServiceInstaller : MonoInstaller
    {
        [TypeFilter("GetFilteredTypeList"), ShowInInspector] 
        public IInputService InputType { get; private set; }
        
        public override void InstallBindings() =>
            Container.BindInterfacesTo(InputType.GetType())
                .AsSingle()
                .NonLazy();

        public IEnumerable<Type> GetFilteredTypeList()
        {
            IEnumerable<Type> types = typeof(IInputService).Assembly.GetTypes()
                .Where(x => !x.IsAbstract)
                .Where(x => !x.IsGenericTypeDefinition)
                .Where(x => x.ImplementsOrInherits(typeof(IInputService)));

            return types;
        }
    }
}