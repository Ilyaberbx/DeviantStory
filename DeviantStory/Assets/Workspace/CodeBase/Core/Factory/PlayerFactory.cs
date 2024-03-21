using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using Workspace.CodeBase.Networking.Factory;

namespace Workspace.CodeBase.Core.Factory
{
    public class PlayerFactory 
    {
        private readonly INetworkFactory _networkFactory;
        private readonly AssetReference _playerReference;

        public PlayerFactory(INetworkFactory networkFactory, AssetReference playerReference)
        {
            _networkFactory = networkFactory;
            _playerReference = playerReference;
        }

        public async UniTask<Transform> Create(Vector3 at) 
            => await _networkFactory.Create<Transform>(_playerReference, at, Quaternion.identity);
    }
}