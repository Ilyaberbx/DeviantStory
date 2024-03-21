using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using Zenject;

namespace Workspace.CodeBase.Core.Camera
{
    public class CameraServiceInstaller : MonoInstaller
    {
        [SerializeField] private List<GameCamera> _cameras;
        [SerializeField] private CinemachineBrain _brain;

        public override void InstallBindings()
            => Container.BindInterfacesTo<CameraService>()
                .AsSingle()
                .WithArguments(_cameras, _brain);
    }
}