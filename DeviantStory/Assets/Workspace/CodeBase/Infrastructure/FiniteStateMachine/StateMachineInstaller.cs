using Better.Attributes.Runtime.Select;
using Better.DataStructures.Runtime.SerializedTypes;
using UnityEngine;
using Zenject;

namespace Workspace.CodeBase.Infrastructure.FiniteStateMachine
{
    public class StateMachineInstaller : MonoInstaller
    {
        [Select(typeof(StateMachine)), SerializeField]
        private SerializedType _serializedType;

        public override void InstallBindings() =>
            Container.BindInterfacesAndSelfTo(_serializedType.Type)
                .AsSingle();
    }
}