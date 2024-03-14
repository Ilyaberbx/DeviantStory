using System;

namespace Workspace.CodeBase.Services.Logging
{
    [Serializable]
    public class JumpStat : PlayerStat<JumpAction>
    {
        public float JumpPower;

        protected override bool OnTryApply(JumpAction action)
        {
            action.JumpPower = JumpPower;
            return true;
        }
    }
}