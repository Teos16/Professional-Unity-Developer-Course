using System;
using System.Collections.Generic;
using System.Linq;

namespace Atomic.Elements
{
    /// <summary>
    /// Represents an expression that computes the product of multiple parameterless float-returning functions.
    /// </summary>
    [Serializable]
    public class FloatMulExpression : ExpressionBase<float>
    {
        /// <summary>
        /// Initializes a new empty instance of the <see cref="FloatMulExpression"/> class.
        /// </summary>
        /// <param name="capacity">Initial internal capacity.</param>
        public FloatMulExpression(int capacity = INITIAL_CAPACITY) : base(capacity)
        {
        }

        /// <summary>
        /// Initializes the expression with the specified function members.
        /// </summary>
        /// <param name="members">An array of float-returning functions.</param>
        public FloatMulExpression(params Func<float>[] members) : base(members)
        {
        }

        /// <summary>
        /// Initializes the expression with the specified collection of function members.
        /// </summary>
        /// <param name="members">A collection of float-returning functions.</param>
        public FloatMulExpression(IEnumerable<Func<float>> members) : base(members)
        {
        }

        /// <summary>
        /// Initializes the expression with the specified <see cref="IFunction{T}"/> members.
        /// </summary>
        /// <param name="members">An array of function objects implementing <see cref="IFunction{float}"/>.</param>
        public FloatMulExpression(params IFunction<float>[] members) : base(members.Length)
        {
            for (int i = 0, count = members.Length; i < count; i++)
                this.Add(members[i]);
        }

        /// <summary>
        /// Initializes the expression with the specified collection of <see cref="IFunction{T}"/> members.
        /// </summary>
        /// <param name="members">A collection of function objects implementing <see cref="IFunction{float}"/>.</param>
        public FloatMulExpression(IEnumerable<IFunction<float>> members) : base(members.Count())
        {
            foreach (IFunction<float> member in members)
                this.Add(member);
        }

        protected override float Invoke(Enumerator enumerator)
        {
            float result = 1;
            while (enumerator.MoveNext())
                result *= enumerator.Current!.Invoke();

            return result;
        }
    }

    /// <summary>
    /// Represents an expression that computes the product of float values returned from functions with a single input parameter.
    /// </summary>
    /// <typeparam name="T">The input parameter type.</typeparam>
    [Serializable]
    public class FloatMulExpression<T> : ExpressionBase<T, float>
    {
        /// <summary>
        /// Initializes a new empty instance of the <see cref="FloatMulExpression{T}"/> class.
        /// </summary>
        /// <param name="capacity">Initial internal capacity.</param>
        public FloatMulExpression(int capacity = INITIAL_CAPACITY) : base(capacity)
        {
        }

        /// <summary>
        /// Initializes the expression with the specified function members.
        /// </summary>
        /// <param name="members">An array of functions that take a <typeparamref name="T"/> and return a float.</param>
        public FloatMulExpression(params Func<T, float>[] members) : base(members)
        {
        }

        /// <summary>
        /// Initializes the expression with the specified collection of function members.
        /// </summary>
        /// <param name="members">A collection of functions that take a <typeparamref name="T"/> and return a float.</param>
        public FloatMulExpression(IEnumerable<Func<T, float>> members) : base(members)
        {
        }

        /// <summary>
        /// Initializes the expression with the specified <see cref="IFunction{T, TResult}"/> members.
        /// </summary>
        /// <param name="members">An array of <see cref="IFunction{T, float}"/> instances.</param>
        public FloatMulExpression(params IFunction<T, float>[] members) : base(members.Length)
        {
            for (int i = 0, count  = members.Length; i < count; i++)
                this.Add(members[i]);
        }

        /// <summary>
        /// Initializes the expression with the specified collection of <see cref="IFunction{T, TResult}"/> members.
        /// </summary>
        /// <param name="members">A collection of <see cref="IFunction{T, float}"/> instances.</param>
        public FloatMulExpression(IEnumerable<IFunction<T, float>> members) : base(members.Count())
        {
            foreach (var member in members)
                this.Add(member);
        }

        protected override float Invoke(Enumerator enumerator, T arg)
        {
            float result = 1;
            while (enumerator.MoveNext())
                result *= enumerator.Current!.Invoke(arg);

            return result;
        }
    }

    /// <summary>
    /// Represents an expression that computes the product of float values returned from functions with two input parameters.
    /// </summary>
    /// <typeparam name="T1">The first input parameter type.</typeparam>
    /// <typeparam name="T2">The second input parameter type.</typeparam>
    [Serializable]
    public class FloatMulExpression<T1, T2> : ExpressionBase<T1, T2, float>
    {
        /// <summary>
        /// Initializes a new empty instance of the <see cref="FloatMulExpression{T1, T2}"/> class.
        /// </summary>
        /// <param name="capacity">Initial internal capacity.</param>
        public FloatMulExpression(int capacity = INITIAL_CAPACITY) : base(capacity)
        {
        }

        /// <summary>
        /// Initializes the expression with the specified function members.
        /// </summary>
        /// <param name="members">An array of functions taking <typeparamref name="T1"/> and <typeparamref name="T2"/> and returning a float.</param>
        public FloatMulExpression(params Func<T1, T2, float>[] members) : base(members)
        {
        }

        /// <summary>
        /// Initializes the expression with the specified collection of function members.
        /// </summary>
        /// <param name="members">A collection of functions taking <typeparamref name="T1"/> and <typeparamref name="T2"/> and returning a float.</param>
        public FloatMulExpression(IEnumerable<Func<T1, T2, float>> members) : base(members)
        {
        }

        /// <summary>
        /// Initializes the expression with the specified <see cref="IFunction{T1, T2, TResult}"/> members.
        /// </summary>
        /// <param name="members">An array of <see cref="IFunction{T1, T2, float}"/> instances.</param>
        public FloatMulExpression(params IFunction<T1, T2, float>[] members) : base(members.Length)
        {
            for (int i = 0, count = members.Length; i < count; i++)
                this.Add(members[i]);
        }

        /// <summary>
        /// Initializes the expression with the specified collection of <see cref="IFunction{T1, T2, TResult}"/> members.
        /// </summary>
        /// <param name="members">A collection of <see cref="IFunction{T1, T2, float}"/> instances.</param>
        public FloatMulExpression(IEnumerable<IFunction<T1, T2, float>> members) : base(members.Count())
        {
            foreach (IFunction<T1, T2, float> member in members)
                this.Add(member);
        }

        protected override float Invoke(Enumerator enumerator, T1 arg1, T2 arg2)
        {
            float result = 1;
            while (enumerator.MoveNext())
                result *= enumerator.Current!.Invoke(arg1, arg2);

            return result;
        }
    }
}