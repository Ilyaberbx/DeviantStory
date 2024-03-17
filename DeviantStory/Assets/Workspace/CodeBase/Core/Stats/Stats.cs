using System.Collections.Generic;
using System.Linq;
using Better.Attributes.Runtime.Select;
using UnityEngine;

namespace Workspace.CodeBase.Core.Stats
{
    [CreateAssetMenu(menuName = "Stats")]
    public class Stats : ScriptableObject
    {
        [Select, SerializeReference] private List<Stat> _stats;

        private void OnValidate()
            => _stats = _stats.OrderByDescending(x => x.Priority).ToList();

        public bool TryApply(StatAction action)
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