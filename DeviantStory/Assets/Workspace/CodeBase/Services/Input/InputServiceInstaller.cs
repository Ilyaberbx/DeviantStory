using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using Workspace.CodeBase.Extensions;
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
            => typeof(IInputService).GetNonGenericInheritedTypes();
    }
}