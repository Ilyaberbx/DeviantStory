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
        private IInputService _input;

        public override void InstallBindings() =>
            Container.BindInterfacesTo(_input.GetType())
                .AsSingle();

        public IEnumerable<Type> GetFilteredTypeList() 
            => typeof(IInputService).GetNonGenericInheritedTypes();
    }
}