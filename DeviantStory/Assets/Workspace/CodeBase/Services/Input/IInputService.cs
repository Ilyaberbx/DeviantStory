using System;
using UnityEngine;

namespace Workspace.CodeBase.Services.Input
{
    public interface IInputService
    {
        event Action<Vector2> OnMove;
    }
}