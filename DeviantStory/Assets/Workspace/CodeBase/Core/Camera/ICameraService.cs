using UnityEngine;

namespace Workspace.CodeBase.Core.Camera
{
    public interface ICameraService
    {
        public Vector3 GetBrainDirection(Vector3 direction);
        void ChangeCamera(int index);
        void Initialize(Transform player);
    }
}