using Cysharp.Threading.Tasks;

namespace Workspace.CodeBase.Services.Logging
{
    public interface ILogService
    {
        void Log(string message);
        void LogInfrastructure(string message);
        UniTask Initialize();
    }
}