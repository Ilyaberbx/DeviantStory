using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceLocations;

namespace Workspace.CodeBase.Services.Assets
{
    public class AssetsProvider : IAssetsProvider
    {
        private readonly Dictionary<string, AsyncOperationHandle> _assetRequests = new();

        public async UniTask InitializeAsync() =>
            await Addressables.InitializeAsync().ToUniTask();

        public async UniTask<TAsset> Load<TAsset>(string key) where TAsset : class
        {
            AsyncOperationHandle handle;

            if (!_assetRequests.TryGetValue(key, value: out handle))
            {
                handle = Addressables.LoadAssetAsync<TAsset>(key);
                _assetRequests.Add(key, handle);
            }

            await handle.ToUniTask();

            return handle.Result as TAsset;
        }

        public async UniTask<TAsset> Load<TAsset>(AssetReference assetReference) where TAsset : class =>
            await Load<TAsset>(assetReference.AssetGUID);

        public IAsyncEnumerable<string> GetAssetsListByLabel<TAsset>(string label)
            => GetAssetsListByLabel(label, typeof(TAsset));

        public async IAsyncEnumerable<string> GetAssetsListByLabel(string label, Type type = null)
        {
            AsyncOperationHandle<IList<IResourceLocation>> operationHandle =
                Addressables.LoadResourceLocationsAsync(label, type);

            IList<IResourceLocation> locations = await operationHandle.ToUniTask();

            foreach (IResourceLocation location in locations)
                yield return location.PrimaryKey;

            Addressables.Release(operationHandle);
        }
        
        public async UniTask<TAsset[]> LoadAll<TAsset>(IEnumerable<string> keys) where TAsset : class
        {
            List<UniTask<TAsset>> tasks = new List<UniTask<TAsset>>();

            foreach (var key in keys)
                tasks.Add(Load<TAsset>(key));

            return await UniTask.WhenAll(tasks);
        }

        public async UniTask<TAsset[]> LoadAll<TAsset>(IAsyncEnumerable<string> keys) where TAsset : class
        {
            List<UniTask<TAsset>> tasks = new List<UniTask<TAsset>>();

            await foreach (var key in keys)
                tasks.Add(Load<TAsset>(key));

            return await UniTask.WhenAll(tasks);
        }


        public async UniTask WarmUpAssetsByLabel(string label)
        {
            IAsyncEnumerable<string> assetsList = GetAssetsListByLabel(label);
            await LoadAll<object>(assetsList);
        }

        public async UniTask ReleaseAssetsByLabel(string label)
        {
            IAsyncEnumerable<string> assetsList = GetAssetsListByLabel(label);

            await foreach (var assetKey in assetsList)
                if (_assetRequests.TryGetValue(assetKey, out var handler))
                {
                    Addressables.Release(handler);
                    _assetRequests.Remove(assetKey);
                }
        }

        public void CleanUp()
        {
            foreach (var assetRequest in _assetRequests)
                Addressables.Release(assetRequest.Value);

            _assetRequests.Clear();
        }
    }
}