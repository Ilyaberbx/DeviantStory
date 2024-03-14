using System.Collections.Generic;
using UnityEngine;

namespace Workspace.CodeBase.Extensions
{
    public static class RandomExtension
    {
        public static void Shuffle<T>(this List<T> list)
        {
            int listCount = list.Count;
            for (int i = 0; i < listCount; i++)
            {
                T oldVal = list[i];
                int randomIndex = UnityEngine.Random.Range(i, listCount);
                list[i] = list[randomIndex];
                list[randomIndex] = oldVal;
            }
        }


        public static T Random<T>(this List<T> list)
            => list[UnityEngine.Random.Range(0, list.Count)];

        public static float RangeBetweenPolar(this float value)
        {
            float absValue = Mathf.Abs(value);
            return UnityEngine.Random.Range(-absValue, absValue);
        }
    }
}