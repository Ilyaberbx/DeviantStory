using Cysharp.Threading.Tasks;
using UnityEngine.SceneManagement;

namespace Workspace.CodeBase.Infrastructure.SceneManagement
{
    public interface ISceneLoader 
    {
        UniTask LoadAsync(string name, LoadSceneMode mode);
    }
}