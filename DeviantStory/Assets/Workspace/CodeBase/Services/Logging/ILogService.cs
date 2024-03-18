using Cysharp.Threading.Tasks;

namespace Workspace.CodeBase.Services.Logging
{
    public interface ILogService
    {
        void LogNetworking(string message);
        void LogInfrastructure(string message);
        UniTask Initialize();
    }
}