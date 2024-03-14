using Cysharp.Threading.Tasks;

namespace Workspace.CodeBase.Infrastructure.Service.StateMachineSystem.State
{
    public interface IPayloadedState<in T> : IExitableState
    {
        UniTask Enter(T payload);
    }
    
    public interface IPayloadedState<in T, in V> : IExitableState
    {
        UniTask Enter(T payloadFirst ,V needToFeed);
    }
}