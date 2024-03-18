using System;
using System.Globalization;
using Cysharp.Threading.Tasks;
using TMPro;
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

        public void LogInfrastructure(string message) 
            => Log($"[Infrastructure] {message}");

        public async UniTask Initialize()
        {
            Canvas canvas = await _factory.Create<Canvas>(_logTextReference);
            _logText = canvas.GetComponentInChildren<TextMeshProUGUI>();
        }

        public void Log(string message)
        {
            if (!string.IsNullOrEmpty(_logText.text))
                _logText.text += "\n";

            _logText.text += $"{message}: [{DateTime.Now:HH:mm:ss}]";
        }
    }
}