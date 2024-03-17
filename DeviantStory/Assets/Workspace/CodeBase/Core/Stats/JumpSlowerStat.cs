using System;

namespace Workspace.CodeBase.Core.Stats
{
    [Serializable]
    public class JumpSlowerStat : Stat<JumpAction>
    {
        public float JumpPower;

        protected override bool OnTryApply(JumpAction action)
        {
            action.JumpPower /= JumpPower;
            return true;
        }
    }
}