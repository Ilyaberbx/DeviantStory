using Cysharp.Threading.Tasks;
using UnityEngine.SceneManagement;

namespace Workspace.CodeBase.Services.SceneManagement
{
    public interface ISceneLoader 
    {
        UniTask LoadAsync(string name, LoadSceneMode mode);
    }
}