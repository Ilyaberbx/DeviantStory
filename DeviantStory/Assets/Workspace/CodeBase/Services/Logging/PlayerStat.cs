using System;

namespace Workspace.CodeBase.Services.Logging
{
    [Serializable]
    public abstract class PlayerStat<T> : PlayerStat where T : PlayerAction
    {
        protected abstract bool OnTryApply(T action);

        public override bool TryApply(PlayerAction action)
        {
            if (action is T playerAction)
                return OnTryApply(playerAction);

            return false;
        }
    }

    [Serializable]
    public abstract class PlayerStat
    {
        public abstract bool TryApply(PlayerAction action);
    }
}