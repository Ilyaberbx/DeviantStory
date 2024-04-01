using System;
using UnityEngine.InputSystem;
using Workspace.CodeBase.Extensions;
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
        
        public void RegisterMovement(Action<InputAction.CallbackContext> action, RegisterType type) 
            => _controls.Player.Movement.Register(action, type);

        public void UnregisterMovement(Action<InputAction.CallbackContext> action, RegisterType type)
            => _controls.Player.Movement.Unregister(action, type);

        public void RegisterRun(Action<InputAction.CallbackContext> action, RegisterType type)
            => _controls.Player.Run.Register(action, type);

        public void UnregisterRun(Action<InputAction.CallbackContext> action, RegisterType type)
            => _controls.Player.Run.Unregister(action, type);

        public void RegisterJump(Action<InputAction.CallbackContext> action, RegisterType type)
            => _controls.Player.Jump.Register(action, type);

        public void UnregisterJump(Action<InputAction.CallbackContext> action, RegisterType type)
            => _controls.Player.Jump.Unregister(action, type);
    }
}