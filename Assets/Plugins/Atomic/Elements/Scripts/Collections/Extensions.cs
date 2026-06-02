using System.Collections.Generic;

namespace Atomic.Elements
{
    public partial class Extensions
    {
        public static void AddRange<T>(this ICollection<T> it, params T[] items)
        {
            for (int i = 0, count = items.Length; i < count; i++) 
                it.Add(items[i]);
        }
        
        public static void AddRange<T>(this ICollection<T> it, IEnumerable<T>  items)
        {
            foreach (T item in items) 
                it.Add(item);
        }
    }
}