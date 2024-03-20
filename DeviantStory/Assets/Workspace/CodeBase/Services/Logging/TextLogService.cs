using System;
using Cysharp.Threading.Tasks;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AddressableAssets;
using Workspace.CodeBase.Services.Factory;

namespace Workspace.CodeBase.Services.Logging
{
    public class TextLogService : ILogService
    {
        private readonly AssetReference _logTextReference;
        private readonly IPrefabFactoryAsync _factory;
        private TextMeshProUGUI _logText;

        public TextLogService(AssetReference logTextReference
            , IPrefabFactoryAsync factory)
        {
            _logTextReference = logTextReference;
            _factory = factory;
        }

        public void LogNetworking(string message)
            => Log($"[Networking] {message}", Color.green);

        public void LogInfrastructure(string message)
            => Log($"[Infrastructure] {message}", Color.cyan);

        public async UniTask Initialize()
        {
            Canvas canvas = await _factory.Create<Canvas>(_logTextReference);
            _logText = canvas.GetComponentInChildren<TextMeshProUGUI>();
        }

        public void LogError(string message)
            => Log($"[Error] {message}", Color.red);

        private void Log(string message, Color color)
        {
            if (!string.IsNullOrEmpty(_logText.text))
                _logText.text += "\n";

            _logText.text += $"<color=#{color.ToHexString()}>{message}: [{DateTime.Now:HH:mm:ss}]</color>";
        }
    }
}