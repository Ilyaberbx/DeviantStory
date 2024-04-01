using System;
using Photon.Pun;
using UnityEngine;
using UnityEngine.InputSystem;
using Workspace.CodeBase.Extensions;
using Workspace.CodeBase.Services.Input;
using Zenject;

namespace Workspace.CodeBase.Core.Movement
{
    public class Movement : MonoBehaviour
    {
        public event Action<Vector3> OnMove;
        public event Action<bool> OnRunToggle;

        [SerializeField] private PhotonView _photonView;
        [SerializeField] private CharacterController _characterController;
        [SerializeField, Min(1)] private float _walkSpeed;
        [SerializeField, Min(1)] private float _runSpeed;

        private IInputService _input;
        private Vector3 _movement;
        private float _movementSpeed;
        private readonly float _gravity = -9.8f;
        private bool _isRunning;

        [Inject]
        public void Construct(IInputService input)
            => _input = input;

        private void Start()
        {
            _movementSpeed = _walkSpeed;

            _input.RegisterMovement(HandleMovement, RegisterType.Started);
            _input.RegisterMovement(HandleMovement, RegisterType.Performed);
            _input.RegisterMovement(HandleMovement, RegisterType.Canceled);
            _input.RegisterRun(HandleRun, RegisterType.Started);
            _input.RegisterRun(HandleRun, RegisterType.Canceled);
        }

        private void OnDestroy()
        {
            _input.UnregisterMovement(HandleMovement, RegisterType.Started);
            _input.UnregisterMovement(HandleMovement, RegisterType.Performed);
            _input.UnregisterMovement(HandleMovement, RegisterType.Canceled);
            _input.UnregisterRun(HandleRun, RegisterType.Started);
            _input.UnregisterRun(HandleRun, RegisterType.Canceled);
        }

        private void HandleRun(InputAction.CallbackContext context)
        {
            _isRunning = !_isRunning;
            _movementSpeed = _isRunning ? _runSpeed : _walkSpeed;
            OnRunToggle?.Invoke(_isRunning);
        }

        private void HandleMovement(InputAction.CallbackContext context)
        {
            Vector2 input = context.ReadValue<Vector2>();
            _movement = _movement.WithX(input.x).WithZ(input.y);
        }

        private void Update()
        {
            if (!_photonView.IsMine)
                return;

            Move();
            HandleGravity();
        }

        private void HandleGravity()
        {
            if (_characterController.isGrounded)
            {
                _movement = _movement.WithY(-0.5f);
                return;
            }

            _movement = _movement.AddY(_gravity * Time.deltaTime);
        }

        private void Move()
        {
            Vector3 processedMovement = _movement.MultiplyXZ(_movementSpeed);
            _characterController.Move(processedMovement * Time.deltaTime);
            RaiseMoved(_movement);
        }

        protected virtual void RaiseMoved(Vector3 movement)
            => OnMove?.Invoke(movement);
    }
}