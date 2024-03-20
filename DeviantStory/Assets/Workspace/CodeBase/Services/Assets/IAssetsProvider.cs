using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine.AddressableAssets;

namespace Workspace.CodeBase.Services.Assets
{
    public interface IAssetsProvider
    {
        UniTask InitializeAsync();
        UniTask<TAsset> Load<TAsset>(string key) where TAsset : class;
        UniTask<TAsset> Load<TAsset>(AssetReference assetReference) where TAsset : class;
        IAsyncEnumerable<string> GetAssetsListByLabel<TAsset>(string label);
        IAsyncEnumerable<string> GetAssetsListByLabel(string label, Type type = null);
        UniTask WarmUpAssetsByLabel(string label);
        UniTask ReleaseAssetsByLabel(string label);
        void CleanUp();
        UniTask<TAsset[]> LoadAll<TAsset>(IEnumerable<string> keys) where TAsset : class;
        UniTask<TAsset[]> LoadAll<TAsset>(IAsyncEnumerable<string> keys) where TAsset : class;
    }
}