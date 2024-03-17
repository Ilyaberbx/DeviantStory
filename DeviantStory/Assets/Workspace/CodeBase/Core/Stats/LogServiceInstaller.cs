using Better.Attributes.Runtime.Select;
using UnityEngine;
using Workspace.CodeBase.Services.Logging;
using Zenject;

namespace Workspace.CodeBase.Core.Stats
{
    public class LogServiceInstaller : MonoInstaller
    {
        [Select, SerializeReference]
        private ILogService _logger;

        public override void InstallBindings() =>
            Container.BindInterfacesTo(_logger.GetType())
                .AsSingle();
        
    }
}