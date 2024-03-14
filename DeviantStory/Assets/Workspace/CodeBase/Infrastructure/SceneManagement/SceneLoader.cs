using Cysharp.Threading.Tasks;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.SceneManagement;

namespace Workspace.CodeBase.Infrastructure.SceneManagement
{
    public class SceneLoader : ISceneLoader
    {
        public async UniTask LoadAsync(string name, LoadSceneMode mode)
        {
            AsyncOperationHandle<SceneInstance> handle = Addressables.LoadSceneAsync(name, mode);
            await handle.ToUniTask();
        }
    }
}