using Workspace.Workspace.CodeBase.Utiliting.Logging;
using Zenject;

namespace Workspace.Workspace.CodeBase.Utiliting
{
    public static class Utilities
    {
        [Inject] public static Logger Logger { get; private set; }
    }
}