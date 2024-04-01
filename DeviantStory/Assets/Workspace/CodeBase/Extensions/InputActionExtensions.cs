using System;
using UnityEngine.InputSystem;
using Workspace.CodeBase.Services.Input;

namespace Workspace.CodeBase.Extensions
{
    public static class InputActionExtensions
    {
        public static void Register(this InputAction source, Action<InputAction.CallbackContext> callbackContext, RegisterType type)
        {
            switch (type)
            {
                case RegisterType.Started:
                    source.started += callbackContext;
                    break;
                case RegisterType.Performed:
                    source.performed += callbackContext;
                    break;
                case RegisterType.Canceled:
                    source.canceled += callbackContext;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }
        
        public static void Unregister(this InputAction source, Action<InputAction.CallbackContext> callbackContext, RegisterType type)
        {
            switch (type)
            {
                case RegisterType.Started:
                    source.started -= callbackContext;
                    break;
                case RegisterType.Performed:
                    source.performed -= callbackContext;
                    break;
                case RegisterType.Canceled:
                    source.canceled -= callbackContext;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }
    }
}