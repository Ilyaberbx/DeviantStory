using Cinemachine;
using UnityEngine;

namespace Workspace.CodeBase.Core.Camera
{
    [RequireComponent(typeof(CinemachineVirtualCameraBase))]
    public class GameCamera : MonoBehaviour
    {
        [field: SerializeField] public bool IsPlayerCamera { get; private set; }

        private CinemachineVirtualCameraBase _virtualCamera;

        private void Awake()
            => _virtualCamera = GetComponent<CinemachineVirtualCameraBase>();

        public void SetTarget(Transform target)
        {
            _virtualCamera.LookAt = target;
            _virtualCamera.Follow = target;
        }

        public void SetPriority(int priority)
            => _virtualCamera.Priority = priority;
    }
}