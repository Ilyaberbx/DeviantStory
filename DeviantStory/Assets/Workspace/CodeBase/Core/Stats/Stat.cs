using System;

namespace Workspace.CodeBase.Core.Stats
{
    [Serializable]
    public abstract class Stat<T> : Stat where T : IStatAction
    {
        protected abstract bool OnTryApply(T action);

        public override bool TryApply(IStatAction action)
        {
            if (action is T playerAction)
                return OnTryApply(playerAction);

            return false;
        }
    }

    [Serializable]
    public abstract class Stat
    {
        public int Priority { get; set; }
        public abstract bool TryApply(IStatAction action);
    }
}