using System;
using UnityEngine.AddressableAssets;

namespace Workspace.CodeBase.Extensions
{
    public static class AddressableExtension
    {
        public static string GetRuntimeKey(this AssetReference assetReference)
        {
            if (!assetReference.RuntimeKeyIsValid())
                throw new Exception("Runtime key is invalid: " + assetReference);

            return (string)assetReference.RuntimeKey;
        }
    }
}