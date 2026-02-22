using System.Collections.Generic;

namespace Game.Ships
{
    public sealed class CompositeCondition : ICondition
    {
        private readonly List<ICondition> _conditions = new();

        public void AddCondition(ICondition condition) => _conditions.Add(condition);

        public bool Evaluate()
        {
            for (var i = 0; i < _conditions.Count; i++)
            {
                var condition = _conditions[i];
                if (!condition.Evaluate())
                    return false;
            }

            return true;
        }
    }
}