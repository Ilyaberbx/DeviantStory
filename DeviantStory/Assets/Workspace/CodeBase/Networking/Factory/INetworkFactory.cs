using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Workspace.CodeBase.Networking.Factory
{
    public interface INetworkFactory
    {
        UniTask<T> Create<T>(AssetReference reference, Vector3 at, Quaternion rotation) where T : Object;
    }
}