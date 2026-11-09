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

            float lookDistance = _blackboard.GetValue(BlackboardAPI.MinRangeDistance);
            float attackDistance = _blackboard.GetValue(BlackboardAPI.MaxRangeDistance);
            float stoppingAngle = _blackboard.GetValue(BlackboardAPI.StoppingAngle);

            Vector3 delta = enemy.transform.position - character.transform.position;
            delta.y = 0;
            float sqrDistance = delta.sqrMagnitude;

            // LookAtEnemy
            if (sqrDistance <= lookDistance * lookDistance &&
                Vector3.Angle(character.transform.forward, delta.normalized) > stoppingAngle)
                character.GetComponent<RotateTransformComponent>().RotateTowards(delta.normalized, deltaTime);

            // AttackEnemy
            if (sqrDistance <= attackDistance * attackDistance)
                character.GetComponent<AttackComponent>().Attack(enemy);

            return BehaviourResult.Running;
        }
    }
}