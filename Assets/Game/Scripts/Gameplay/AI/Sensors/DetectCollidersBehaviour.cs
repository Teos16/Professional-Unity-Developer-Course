using Modules.AI;
using UnityEngine;

namespace SampleGame
{
    public sealed class DetectCollidersBehaviour : MonoBehaviour
    {
        [SerializeField]
        private Transform _center;

        [SerializeField]
        private float _radius;

        [SerializeField]
        private LayerMask _layerMask;

        [SerializeField]
        private QueryTriggerInteraction _triggerInteraction = QueryTriggerInteraction.Ignore;

        [SerializeField]
        private Blackboard _blackboard;

        private void FixedUpdate()
        {
            Collider[] buffer = _blackboard.GetValue<Collider[]>(BlackboardAPI.ColliderBuffer);

            int count = Physics.OverlapSphereNonAlloc(
                _center.position,
                _radius,
                buffer,
                _layerMask,
                _triggerInteraction
            );

            _blackboard.SetPrimitiveValue(
                BlackboardAPI.ColliderCount,
                count
            );
        }

        private void OnDrawGizmos()
        {
            if (_center == null)
                return;

            Color prevColor = Gizmos.color;

            Gizmos.color = Color.magenta;
            Gizmos.DrawWireSphere(_center.position, _radius);

            Gizmos.color = prevColor;
        }
    }
}