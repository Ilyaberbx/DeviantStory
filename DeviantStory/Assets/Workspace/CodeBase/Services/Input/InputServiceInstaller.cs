using Better.Attributes.Runtime.Select;
using Better.DataStructures.Runtime.SerializedTypes;
using UnityEngine;
using Zenject;

namespace Workspace.CodeBase.Services.Input
{
    public class InputServiceInstaller : MonoInstaller
    {
        [Select(typeof(IInputService)), SerializeField]
        private SerializedType _serializedType;

        public override void InstallBindings() =>
            Container.BindInterfacesTo(_serializedType.Type)
                .AsSingle();
        
    }
}