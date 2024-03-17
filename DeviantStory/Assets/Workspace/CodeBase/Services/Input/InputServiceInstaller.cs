using Better.Attributes.Runtime.Select;
using UnityEngine;
using Zenject;

namespace Workspace.CodeBase.Services.Input
{
    public class InputServiceInstaller : MonoInstaller
    {
        [Select, SerializeReference]
        private IInputService _input;

        public override void InstallBindings() =>
            Container.BindInterfacesTo(_input.GetType())
                .AsSingle();
        
    }
}