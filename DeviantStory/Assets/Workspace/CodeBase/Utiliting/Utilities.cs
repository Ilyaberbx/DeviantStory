using Workspace.CodeBase.Services.Logging;
using Zenject;

namespace Workspace.Workspace.CodeBase.Utiliting
{
    public static class Utilities
    {
        [Inject] public static ILogService Logger { get; private set; }
    }
}