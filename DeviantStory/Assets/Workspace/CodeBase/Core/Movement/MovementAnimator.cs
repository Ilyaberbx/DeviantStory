using UnityEngine;
using Workspace.CodeBase.Extensions;

namespace Workspace.CodeBase.Core.Movement
{
    public class MovementAnimator : MonoBehaviour
    {
        private static readonly int IsWalking = Animator.StringToHash("IsWalking");
        private static readonly int IsRunning = Animator.StringToHash("IsRunning");
        
        [SerializeField] private Animator _animator;

        public void PlayMove(Vector3 movement) 
            => _animator.SetBool(IsWalking, !movement.IsZero());
        
        public void PlayRunning(bool value) 
            => _animator.SetBool(IsRunning, value);
    }
}