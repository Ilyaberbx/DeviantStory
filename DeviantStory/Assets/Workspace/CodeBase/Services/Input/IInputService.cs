using System;
using UnityEngine.InputSystem;

namespace Workspace.CodeBase.Services.Input
{
    public interface IInputService
    {
        void RegisterMovement(Action<InputAction.CallbackContext> action, RegisterType type);
        void UnregisterMovement(Action<InputAction.CallbackContext> action, RegisterType type);

        void RegisterRun(Action<InputAction.CallbackContext> action, RegisterType type);
        void UnregisterRun(Action<InputAction.CallbackContext> action, RegisterType type);
        
        void RegisterJump(Action<InputAction.CallbackContext> action, RegisterType type);
        void UnregisterJump(Action<InputAction.CallbackContext> action, RegisterType type);
    }

    public enum RegisterType
    {
        Started,
        Performed,
        Canceled
    }
}