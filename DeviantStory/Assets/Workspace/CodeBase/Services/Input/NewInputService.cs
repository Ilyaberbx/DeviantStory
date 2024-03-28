using System;
using UnityEngine;
using Zenject;

namespace Workspace.CodeBase.Services.Input
{
    public class NewInputService : IInputService, IInitializable, IDisposable
    {
        private readonly PlayerControls _controls = new();

        public void Initialize() 
            => _controls.Enable();

        public void Dispose() 
            => _controls.Disable();
        
        public Vector2 GetMovementInput() 
            => _controls.Player.Movement.ReadValue<Vector2>();

        public bool IsMovementPressed() 
            => GetMovementInput().sqrMagnitude != 0;

        public bool IsRunPressed() 
            => _controls.Player.Run.IsPressed();
    }
}