using System.Collections.Generic;
using Modules.AI;
using UnityEngine;

namespace SampleGame
{
    public sealed class PatrolNode : BehaviourNode
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

            if (!_blackboard.TryGetValue(BlackboardAPI.Waypoints, out List<IWaypoint> waypoints) ||
                !_blackboard.TryGetValue(BlackboardAPI.WaypointIndex, out int index) ||
                !_blackboard.TryGetValue(BlackboardAPI.StoppingDistance, out float stoppingDistance))
                return BehaviourResult.Failure;

            waypoints.RemoveAll(waypoint => !waypoint.IsValid);
            if (waypoints.Count == 0)
                return BehaviourResult.Failure;

            index %= waypoints.Count;
            Vector3 delta = waypoints[index].GetPosition - character.transform.position;
            delta.y = 0;

            if (delta.sqrMagnitude <= stoppingDistance * stoppingDistance)
                _blackboard.SetPrimitiveValue(BlackboardAPI.WaypointIndex, (index + 1) % waypoints.Count);
            else
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

            if (sqrDistance > chaseDistance * chaseDistance)
                character.GetComponent<MoveComponent>().MoveStep(delta.normalized, deltaTime);
            
            else if (Vector3.Angle(character.transform.forward, delta.normalized) > stoppingAngle)
                character.GetComponent<RotateTransformComponent>().RotateTowards(delta.normalized, deltaTime);

            if (sqrDistance <= attackDistance * attackDistance)
                character.GetComponent<AttackComponent>().Attack(enemy);
        }
    }
}