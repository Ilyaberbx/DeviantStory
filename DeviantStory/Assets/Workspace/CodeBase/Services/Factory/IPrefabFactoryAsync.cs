using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Workspace.CodeBase.Services.Factory
{
    public interface IPrefabFactoryAsync
    {
        UniTask<T> Create<T>(string address) where T : Object;
        UniTask<T> Create<T>(string address, Vector3 at, Transform container) where T : Object;
        UniTask<T> Create<T>(string address, Vector3 at, Quaternion rotation, Transform container) where T : Object;
        UniTask<T> Create<T>(string address, Vector3 at, bool selfRotation, Transform container) where T : Object;
        UniTask<T> Create<T>(AssetReference reference, Vector3 at, bool selfRotation, Transform container) where T : Object;
        UniTask<T> Create<T>(string address, Transform container) where T : Object;
        UniTask<T> Create<T>(AssetReference reference) where T : Object;
        UniTask<T> Create<T>(AssetReference reference, Vector3 at, Quaternion rotation, Transform container) where T : Object;
        UniTask<T> Create<T>(AssetReference reference, Vector3 at, Transform container) where T : Object;
        UniTask<T> Create<T>(AssetReference reference, Transform container) where T : Object;
    }
}