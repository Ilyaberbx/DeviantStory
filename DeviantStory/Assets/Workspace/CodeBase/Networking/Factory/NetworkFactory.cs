using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using Photon.Pun;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.ResourceLocations;
using Workspace.CodeBase.Extensions;
using Workspace.CodeBase.Services.Logging;
using Zenject;
using Object = UnityEngine.Object;

namespace Workspace.CodeBase.Networking.Factory
{
    public class NetworkFactory : INetworkFactory
    {
        private readonly DiContainer _container;
        private readonly ILogService _logger;

        public NetworkFactory(DiContainer container, ILogService logger)
        {
            _container = container;
            _logger = logger;
        }

        public async UniTask<T> Create<T>(AssetReference reference, Vector3 at, Quaternion rotation) where T : Component
        {
            try
            {
                var handler = Addressables.LoadResourceLocationsAsync(reference);

                IList<IResourceLocation> result = await handler.ToUniTask();
                
                GameObject go = PhotonNetwork.Instantiate(result[0].PrimaryKey, at, rotation);
                
                _container.InjectGameObject(go);
                
                return go.GetComponent<T>();
            }
            catch (Exception exception)
            {
                _logger.LogError(exception.Message);
                throw;
            }
        }
    }
}