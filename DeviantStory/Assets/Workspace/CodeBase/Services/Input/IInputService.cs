using UnityEngine;

namespace Workspace.CodeBase.Services.Input
{
    public interface IInputService
    {
        Vector2 GetMovementInput();

        bool IsMovementPressed();

        bool IsRunPressed();

        bool IsJumpPressed();
    }
}