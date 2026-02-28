using System;

namespace Game.Ships
{
    public sealed class InlineCondition : ICondition
    {
        private readonly Func<bool> _func;
        public InlineCondition(Func<bool> func) => _func = func;
        public bool Evaluate() => _func();
    }
}