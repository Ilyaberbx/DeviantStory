using System;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace Workspace.CodeBase.Services.Input
{
    public class NewInputService : IInputService, IInitializable, IDisposable
    {
        public event Action<Vector2> OnMove;
        
        private readonly PlayerControls _controls = new();

        public void Initialize()
        {
            _controls.Movement.Movement.performed += HandleMovementPerformed;
            _controls.Enable();
        }

        public void Dispose()
        {
            _controls.Movement.Movement.performed -= HandleMovementPerformed;
            _controls.Disable();
        }

        private void HandleMovementPerformed(InputAction.CallbackContext callback) 
            => OnMove?.Invoke(callback.ReadValue<Vector2>());
    }
}