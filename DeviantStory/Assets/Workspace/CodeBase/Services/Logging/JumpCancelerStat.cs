using System;

namespace Workspace.CodeBase.Services.Logging
{
    [Serializable]
    public class JumpCancelerStat : PlayerStat<JumpAction>
    {
        protected override bool OnTryApply(JumpAction action)
            => false;
    }
}