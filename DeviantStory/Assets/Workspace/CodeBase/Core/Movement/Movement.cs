using System;
using Photon.Pun;
using UnityEngine;
using Workspace.CodeBase.Extensions;
using Workspace.CodeBase.Services.Input;
using Zenject;

namespace Workspace.CodeBase.Core.Movement
{
    public class Movement : MonoBehaviour
    {
        public event Action<Vector3> OnMove;

        [SerializeField] private PhotonView _photonView;
        [SerializeField] private CharacterController _characterController;
        [SerializeField] private MovementAnimator _animator;
        [SerializeField, Min(1)] private float _walkSpeed;
        [SerializeField, Min(1)] private float _runSpeed;


        private IInputService _input;
        private Vector3 _movement;
        private float _gravity = -9.8f;

        [Inject]
        public void Construct(IInputService input)
            => _input = input;

        private void Update()
        {
            if (!_photonView.IsMine)
                return;

            if (_input.IsMovementPressed())
            {
                float speed;
                
                if (_input.IsRunPressed())
                {
                    speed = _runSpeed;
                    _animator.PlayRunning(true);
                }
                else
                {
                    speed = _walkSpeed;
                    _animator.PlayRunning(false);
                }

                Move(_input.GetMovementInput(), speed);
            }
            else
            {
                RaiseMoved(Vector3.zero);
                _animator.PlayRunning(false);
                _animator.PlayMove(Vector3.zero);
            }
            
            ApplyGravity();
        }

        private void ApplyGravity()
        {
            if (_characterController.isGrounded)
            {
                _movement = _movement.WithY(-0.5f);
                return;
            }


            _movement = _movement.AddY(_gravity * Time.deltaTime);
        }

        private void Move(Vector2 input, float speed)
        {
            _movement = _movement.WithX(input.x).WithZ(input.y);
            
            _characterController.Move(_movement * speed * Time.deltaTime);
            RaiseMoved(_movement);
            _animator.PlayMove(_movement);
        }

        protected virtual void RaiseMoved(Vector3 movement)
            => OnMove?.Invoke(movement);
    }
}