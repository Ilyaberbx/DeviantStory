using UnityEngine;

namespace Workspace.CodeBase.Extensions
{
    public static class CharacterControllerExtension
    {
        public static float GetGravity(this CharacterController source)
        {
            Debug.Log("Is Grounded: " + source.isGrounded);
            return source.isGrounded ? -.5f : -.5f;
        }
    }
}