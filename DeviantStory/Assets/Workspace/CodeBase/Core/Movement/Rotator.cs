using Better.Extensions.Runtime;
using UnityEngine;
using Workspace.CodeBase.Extensions;

namespace Workspace.CodeBase.Core.Movement
{
    public class Rotator : MonoBehaviour
    {
        [SerializeField] private float _rotationFactorPerFrame;
        [SerializeField] private Movement _movement;

        private void Awake() 
            => _movement.OnMove += Rotate;

        private void OnDestroy() 
            => _movement.OnMove -= Rotate;

        private void Rotate(Vector3 movement)
        {
            if(movement.IsZero())
                return;

            Vector3 positionToLookAt = movement.Flat();
            Quaternion currentRotation = transform.rotation;
            Quaternion targetRotation = Quaternion.LookRotation(positionToLookAt);
            transform.rotation = Quaternion.Slerp(currentRotation, targetRotation, _rotationFactorPerFrame * Time.deltaTime);
        }
    }
}