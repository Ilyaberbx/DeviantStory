using Cysharp.Threading.Tasks;

namespace Workspace.CodeBase.UI.LoadingCurtain
{
    public interface ILoadingCurtain
    {
        UniTask Show();
        void ShowImmediately();
        UniTask Hide();
        void Cancel();
        
    }
}