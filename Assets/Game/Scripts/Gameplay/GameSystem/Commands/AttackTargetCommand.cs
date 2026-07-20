using Modules.AI;
using UnityEngine;

namespace SampleGame
{
    public sealed class AttackTargetCommand : TargetCommand
    {
        private readonly Blackboard _blackboard;

        public AttackTargetCommand(Blackboard blackboard, GameObject target) : base(target)
            => _blackboard = blackboard;

        public override bool CanExecute() => _blackboard != null
                                             && TargetObject != null
                                             && TargetObject.activeInHierarchy;

        public override bool Execute()
        {
            // цель невалидна — команда завершена
            if (!TargetObject || !TargetObject.activeInHierarchy)
            {
                _blackboard.DelValue(BlackboardAPI.Enemy);
                return true;
            }

            if (TargetObject.TryGetComponent(out HealthComponent health) && !health.IsAlive)
            {
                _blackboard.DelValue(BlackboardAPI.Enemy);
                return true;
            }

            // держим цель на blackboard пока она жива
            if (!_blackboard.TryGetValue(BlackboardAPI.Enemy, out GameObject current) || current != TargetObject)
                _blackboard.SetReferenceValue(BlackboardAPI.Enemy, TargetObject);

            // команда продолжает выполняться
            return false;
        }

        public override void Cancel() => _blackboard.DelValue(BlackboardAPI.Enemy);
    }
}