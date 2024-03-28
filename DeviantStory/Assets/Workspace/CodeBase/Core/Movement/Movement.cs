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
        }

        private void Move(Vector2 input, float speed)
        {
            Vector3 direction = new Vector3(input.x, 0, input.y);
            Vector3 movement = direction * speed * Time.deltaTime;

            movement = movement.AddY(_characterController.GetGravity());
            
            _characterController.Move(movement);
            RaiseMoved(movement);
            _animator.PlayMove(movement);
        }

        protected virtual void RaiseMoved(Vector3 movement)
            => OnMove?.Invoke(movement);
    }
}