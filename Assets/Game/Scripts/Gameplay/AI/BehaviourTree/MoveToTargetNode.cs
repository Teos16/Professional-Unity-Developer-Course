using Modules.AI;
using UnityEngine;

namespace SampleGame
{
    public sealed class MoveToTargetNode : BehaviourNode
    {
        [SerializeField]
        private Blackboard _blackboard;

        protected override BehaviourResult OnUpdate(float deltaTime)
        {
            if (!_blackboard.TryGetValue(BlackboardAPI.Character, out GameObject character) ||
                !_blackboard.TryGetValue(BlackboardAPI.MovementTarget, out GameObject target) ||
                !_blackboard.TryGetValue(BlackboardAPI.StoppingDistance, out float stoppingDistance))
                return BehaviourResult.Failure;

            if (!target || !target.activeInHierarchy ||
                !target.TryGetComponent(out HealthComponent health) || health.IsDead)
                return BehaviourResult.Failure;

            Vector3 delta = target.transform.position - character.transform.position;
            delta.y = 0;

            if (delta.sqrMagnitude <= stoppingDistance * stoppingDistance)
                return BehaviourResult.Success;

            character.GetComponent<MoveComponent>().MoveStep(delta.normalized, deltaTime);
            return BehaviourResult.Running;
        }
    }
}