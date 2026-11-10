using Modules.AI;
using UnityEngine;

namespace SampleGame
{
    public sealed class HoldNode : BehaviourNode
    {
        [SerializeField]
        private Blackboard _blackboard;

        protected override BehaviourResult OnUpdate(float deltaTime)
        {
            if (!_blackboard.TryGetValue(BlackboardAPI.Character, out GameObject character))
                return BehaviourResult.Failure;

            if (!_blackboard.TryGetValue(BlackboardAPI.ClosestEnemy, out GameObject enemy) || !enemy)
                return BehaviourResult.Running;

            Vector3 enemyPosition = enemy.transform.position;

            if (character.IsWithin(enemyPosition, _blackboard.GetValue(BlackboardAPI.MinRangeDistance)))
                character.RotateTo(enemyPosition, _blackboard.GetValue(BlackboardAPI.StoppingAngle), deltaTime);

            character.AttackInRange(enemy, _blackboard.GetValue(BlackboardAPI.MaxRangeDistance));
            return BehaviourResult.Running;
        }
    }
}
