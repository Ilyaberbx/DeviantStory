using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Photon.Pun;
using UnityEngine;
using Workspace.CodeBase.Services.Assets;
using Workspace.CodeBase.Services.Logging;

namespace Workspace.CodeBase.Networking.Factory
{
    public class PunAddressablesPool : IPunPrefabPool
    {
        private readonly ILogService _logger;
        private readonly IAssetsProvider _assets;
        private readonly Dictionary<string, GameObject> _prefabByAssetKey = new();

        public PunAddressablesPool(ILogService logger
            , IAssetsProvider assets)
        {
            _logger = logger;
            _assets = assets;
        }

        public async UniTask Initialize()
        {
            IAsyncEnumerable<string> keys = _assets.GetAssetsListByLabel<GameObject>(AssetsLabels.Networking);

            await foreach (string key in keys)
            {
                Debug.Log(key);
                _prefabByAssetKey.Add(key, await _assets.Load<GameObject>(key));
            }
        }

        public GameObject Instantiate(string prefabId, Vector3 position, Quaternion rotation)
        {
            if (!_prefabByAssetKey.TryGetValue(prefabId, out GameObject prefab))
            {
                _logger.LogError("Can't load prefab " + prefabId + ". Make sure prefab labeled as Networking");
                return default;
            }

            return Object.Instantiate(prefab, position, rotation);
        }

        public void Destroy(GameObject gameObject)
        {
            Object.Destroy(gameObject);
            _logger.LogNetworking(gameObject.name + " destroyed");
        }
    }
}