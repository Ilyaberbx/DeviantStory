using System;
using Better.Attributes.Runtime.Select;
using Better.DataStructures.Runtime.SerializedTypes;
using UnityEngine;

namespace Workspace.CodeBase.Core.Stats
{
    [Serializable]
    public class JumpAction : IStatAction
    {
        
        public float JumpPower;
    }

    public class StatsService
    {
        [Select(typeof(IExecutor)), SerializeField]
        public SerializedType Type;

        public void Execute<T>(IExecutor executor) where T : IStatAction 
            => throw new NotImplementedException();
    }

    public interface IExecutor
    {
    }
}