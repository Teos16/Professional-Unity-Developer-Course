using Modules.AI;
using UnityEngine;

namespace SampleGame
{
    public sealed class GuardNode : BehaviourNode
    {
        [SerializeField]
        private Blackboard _blackboard;

        protected override BehaviourResult OnUpdate(float deltaTime)
        {
            if (!_blackboard.TryGetValue(BlackboardAPI.Character, out GameObject character))
                return BehaviourResult.Failure;

            if (_blackboard.TryGetValue(BlackboardAPI.ClosestEnemy, out GameObject enemy) && enemy)
            {
                FightEnemy(character, enemy, deltaTime);
                return BehaviourResult.Running;
            }

            if (!_blackboard.TryGetValue(BlackboardAPI.GuardPosition, out Vector3 position) ||
                !_blackboard.TryGetValue(BlackboardAPI.StoppingDistance, out float stoppingDistance))
                return BehaviourResult.Failure;

            Vector3 delta = position - character.transform.position;
            delta.y = 0;

            if (delta.sqrMagnitude > stoppingDistance * stoppingDistance)
                character.GetComponent<MoveComponent>().MoveStep(delta.normalized, deltaTime);

            return BehaviourResult.Running;
        }

        private void FightEnemy(GameObject character, GameObject enemy, float deltaTime)
        {
            float chaseDistance = _blackboard.GetValue(BlackboardAPI.MinRangeDistance);
            float attackDistance = _blackboard.GetValue(BlackboardAPI.MaxRangeDistance);
            float stoppingAngle = _blackboard.GetValue(BlackboardAPI.StoppingAngle);

            Vector3 delta = enemy.transform.position - character.transform.position;
            delta.y = 0;
            float sqrDistance = delta.sqrMagnitude;

            // MoveToEnemy
            if (sqrDistance > chaseDistance * chaseDistance)
                character.GetComponent<MoveComponent>().MoveStep(delta.normalized, deltaTime);
            
            // LookAtEnemy
            else if (Vector3.Angle(character.transform.forward, delta.normalized) > stoppingAngle)
                character.GetComponent<RotateTransformComponent>().RotateTowards(delta.normalized, deltaTime);

            // AttackEnemy
            if (sqrDistance <= attackDistance * attackDistance)
                character.GetComponent<AttackComponent>().Attack(enemy);
        }
    }
}