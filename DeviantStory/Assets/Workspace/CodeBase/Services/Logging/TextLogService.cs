using TMPro;

namespace Workspace.CodeBase.Services.Logging
{
    public class TextLogService : ILogService
    {
        private readonly TextMeshProUGUI _logText;

        public TextLogService(TextMeshProUGUI logText) 
            => _logText = logText;

        public void Log(string message)
        {
            if (!string.IsNullOrEmpty(_logText.text))
                _logText.text += "\n";

            _logText.text += message;
        }
    }
}