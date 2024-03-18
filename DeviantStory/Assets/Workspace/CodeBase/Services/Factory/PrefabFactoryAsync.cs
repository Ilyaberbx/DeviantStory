using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using Workspace.CodeBase.Services.Assets;
using Zenject;

namespace Workspace.CodeBase.Services.Factory
{
    public class PrefabFactoryAsync : IPrefabFactoryAsync
    {
        private readonly IInstantiator _instantiator;
        private readonly IAssetsProvider _assets;

        public PrefabFactoryAsync(IInstantiator instantiator, IAssetsProvider assets)
        {
            _instantiator = instantiator;
            _assets = assets;
        }

        public async UniTask<T> Create<T>(string address) where T : Object
        {
            GameObject prefab = await _assets.Load<GameObject>(address);
            GameObject createdObject = _instantiator.InstantiatePrefab(prefab);
            return createdObject.GetComponent<T>();
        }

        public async UniTask<T> Create<T>(string address, Vector3 at, Transform container) where T : Object
        {
            GameObject prefab = await _assets.Load<GameObject>(address);
            GameObject createdObject = _instantiator.InstantiatePrefab(prefab, at, Quaternion.identity, container);
            return createdObject.GetComponent<T>();
        }

        public async UniTask<T> Create<T>(string address, Vector3 at, Quaternion rotation, Transform container)
            where T : Object
        {
            GameObject prefab = await _assets.Load<GameObject>(address);
            GameObject createdObject = _instantiator.InstantiatePrefab(prefab, at, rotation, container);
            return createdObject.GetComponent<T>();
        }

        public async UniTask<T> Create<T>(string address, Vector3 at, bool selfRotation, Transform container)
            where T : Object
        {
            GameObject prefab = await _assets.Load<GameObject>(address);
            GameObject createdObject = _instantiator.InstantiatePrefab(prefab, at,
                selfRotation ? prefab.transform.localRotation : Quaternion.identity, container);

            return createdObject.GetComponent<T>();
        }

        public async UniTask<T> Create<T>(AssetReference reference, Vector3 at, bool selfRotation, Transform container)
            where T : Object
        {
            GameObject prefab = await _assets.Load<GameObject>(reference);
            GameObject createdObject = _instantiator.InstantiatePrefab(prefab, at,
                selfRotation ? prefab.transform.localRotation : Quaternion.identity, container);

            return createdObject.GetComponent<T>();
        }

        public async UniTask<T> Create<T>(string address, Transform container) where T : Object
        {
            GameObject prefab = await _assets.Load<GameObject>(address);
            GameObject createdObject =
                _instantiator.InstantiatePrefab(prefab, container);
            return createdObject.GetComponent<T>();
        }

        public async UniTask<T> Create<T>(AssetReference reference) where T : Object
        {
            GameObject prefab = await _assets.Load<GameObject>(reference);
            GameObject createdObject = _instantiator.InstantiatePrefab(prefab);
            return createdObject.GetComponent<T>();
        }

        public UniTask<T> Create<T>(AssetReference reference, Vector3 at, Quaternion rotation, Transform container)
            where T : Object => Create<T>(reference.AssetGUID, at, rotation, container);

        public async UniTask<T> Create<T>(AssetReference reference, Vector3 at, Transform container) where T : Object
        {
            GameObject prefab = await _assets.Load<GameObject>(reference);
            GameObject createdObject = _instantiator.InstantiatePrefab(prefab, at, Quaternion.identity, container);
            return createdObject.GetComponent<T>();
        }

        public async UniTask<T> Create<T>(AssetReference reference, Transform container) where T : Object
        {
            GameObject prefab = await _assets.Load<GameObject>(reference);
            GameObject createdObject =
                _instantiator.InstantiatePrefab(prefab, container);
            return createdObject.GetComponent<T>();
        }
    }
}