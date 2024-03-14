using System.Collections.Generic;
using UnityEngine;

namespace Workspace.CodeBase.Extensions
{
    public static class TransformExtension
    {
        public static IEnumerable<Transform> GetChildren(this Transform source)
        {
            foreach (Transform child in source)
                yield return child;
        }
    }
}