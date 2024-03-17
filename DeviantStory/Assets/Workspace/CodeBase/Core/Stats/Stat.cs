using System;

namespace Workspace.CodeBase.Core.Stats
{
    [Serializable]
    public abstract class Stat<T> : Stat where T : StatAction
    {
        protected abstract bool OnTryApply(T action);

        public override bool TryApply(StatAction action)
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
        public abstract bool TryApply(StatAction action);
    }
}