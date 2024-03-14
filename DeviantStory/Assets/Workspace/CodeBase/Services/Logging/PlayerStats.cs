using System.Collections.Generic;
using UnityEngine;
using Workspace.CodeBase.Services.Logging;

namespace Workspace.Workspace.CodeBase.Services.Logging
{
    [CreateAssetMenu(menuName = "Stats")]
    public class PlayerStats : ScriptableObject
    {
        [SerializeReference] private List<PlayerStat> _stats;

        public bool TryApply(PlayerAction action)
        {
            foreach (var stat in _stats)
            {
                if (!stat.TryApply(action))
                    return false;
            }

            return true;
        }
    }
}