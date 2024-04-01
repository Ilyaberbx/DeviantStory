using System;
using Better.Extensions.Runtime;
using UnityEngine;
using Workspace.CodeBase.Extensions;

namespace Workspace.CodeBase.Core.Movement
{
    public class MovementAnimator : MonoBehaviour
    {
        private static readonly int IsWalking = Animator.StringToHash("IsWalking");
        private static readonly int IsRunning = Animator.StringToHash("IsRunning");
        
        [SerializeField] private Animator _animator;
        [SerializeField] private Movement _movement;

        private void Awake()
        {
            _movement.OnMove += PlayMove;
            _movement.OnRunToggle += PlayRunning;
        }

        private void OnDestroy()
        {
            _movement.OnMove -= PlayMove;
            _movement.OnRunToggle -= PlayRunning;
        }

        private void PlayMove(Vector3 movement) 
            => _animator.SetBool(IsWalking, !movement.Flat().IsZero());
        
        private void PlayRunning(bool value) 
            => _animator.SetBool(IsRunning, value);
    }
}