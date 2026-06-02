using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Atomic.Elements
{
    public partial class Extensions
    {
        #region Sum

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Sum(this IEnumerable<float> list)
        {
            if (list == null)
                throw new ArgumentNullException(nameof(list));

            float result = 0;
            foreach (float item in list)
                result += item;

            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Sum(this IEnumerable<int> list)
        {
            if (list == null)
                throw new ArgumentNullException(nameof(list));

            float result = 0;
            foreach (float item in list)
                result += item;

            return result;
        }

        #endregion

        #region Mul

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Multiply(this IEnumerable<float> list)
        {
            if (list == null)
                throw new ArgumentNullException(nameof(list));

            float result = 1;
            foreach (float item in list)
                result *= item;

            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Multiply(this IEnumerable<int> list)
        {
            if (list == null)
                throw new ArgumentNullException(nameof(list));

            float result = 1;
            foreach (float item in list)
                result *= item;

            return result;
        }

        #endregion

        #region And

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool And(this IEnumerable<bool> list)
        {
            if (list == null)
                throw new ArgumentNullException(nameof(list));

            foreach (bool item in list)
                if (!item)
                    return false;

            return true;
        }

        #endregion

        #region Or

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Or(this IEnumerable<bool> list)
        {
            if (list == null)
                throw new ArgumentNullException(nameof(list));

            foreach (bool item in list)
                if (!item)
                    return true;

            return false;
        }

        #endregion
    }
}