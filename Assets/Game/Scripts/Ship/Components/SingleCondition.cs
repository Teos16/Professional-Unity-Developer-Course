using System;

namespace Game.ShipRelated
{
    public sealed class SingleCondition : ICondition
    {
        private readonly Func<bool> _func;
        public SingleCondition(Func<bool> func) => _func = func;
        public bool Evaluate() => _func();
    }
}