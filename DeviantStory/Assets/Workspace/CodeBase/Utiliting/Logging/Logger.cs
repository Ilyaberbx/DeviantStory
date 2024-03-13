using TMPro;

namespace Workspace.Workspace.CodeBase.Utiliting.Logging
{
    public class Logger
    {
        private readonly TextMeshProUGUI _logText;

        public Logger(TextMeshProUGUI logText) 
            => _logText = logText;

        public void Log(string message)
        {
            if (!string.IsNullOrEmpty(_logText.text))
                _logText.text += "\n";

            _logText.text += message;
        }
    }
}