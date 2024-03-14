using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using Workspace.CodeBase.Extensions;
using Zenject;

namespace Workspace.CodeBase.Services.Logging
{
    public class LogServiceInstaller : MonoInstaller
    {
        [TypeFilter("GetFilteredTypeList"), ShowInInspector]
        private ILogService _logger;

        public override void InstallBindings() =>
            Container.BindInterfacesTo(_logger.GetType())
                .AsSingle();
        
        public IEnumerable<Type> GetFilteredTypeList() 
            => typeof(ILogService).GetNonGenericInheritedTypes();
    }
}