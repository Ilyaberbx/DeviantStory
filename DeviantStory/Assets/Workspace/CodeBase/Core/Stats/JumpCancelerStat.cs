using System;

namespace Workspace.CodeBase.Core.Stats
{
    [Serializable]
    public class JumpCancelerStat : Stat<JumpAction>
    {
        protected override bool OnTryApply(JumpAction action)
            => false;
    }
}