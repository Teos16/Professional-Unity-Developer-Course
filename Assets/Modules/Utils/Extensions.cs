using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Modules.Utils
{
    public static partial class Extensions
    {
        public static T GetRandom<T>(this IEnumerable<T> collection)
        {
            int index = UnityEngine.Random.Range(0, collection.Count());
            return collection.ElementAt(index);
        }
        
        public static void Shuffle(this Transform[] array)
        {
            for (int i = array.Length - 1; i > 0; i--)
            {
                int j = Random.Range(0, i + 1);
                (array[i], array[j]) = (array[j], array[i]);
            }
        }
        
        public static Vector3 Next(this Transform[] array, ref int currentIndex)
        {
            if (currentIndex >= array.Length)
            {
                array.Shuffle();
                currentIndex = 0;
            }

            return array[currentIndex++].position;
        }
    }
}