using System;
using Better.Attributes.Runtime.Select;
using Better.DataStructures.Runtime.SerializedTypes;
using UnityEngine;

namespace Workspace.CodeBase.Core.Stats
{
    [Serializable]
    public class JumpStat : Stat<JumpAction>
    {
        [Select(typeof(IExecutor)), SerializeField]
        public SerializedType Type;
        
        public float JumpPower;

        protected override bool OnTryApply(JumpAction action)
        {
            action.JumpPower = JumpPower;
            return true;
        }
    }
}