using UnityEngine;

namespace SampleGame
{
    [RequireComponent(typeof(TargetComponent))]
    public sealed class DetectTargetComponent : MonoBehaviour
    {
        [SerializeField]
        private float _detectDistance = 3f;

        [SerializeField]
        private LayerMask _targetLayer;

        private TargetComponent _targetComponent;

        [SerializeField]
        private float _minCooldown = 0.2f;

        [SerializeField]
        private float _maxCooldown = 0.4f;

        private float _cooldown;

        private void Awake()
        {
            _targetComponent = GetComponent<TargetComponent>();
        }

        private void FixedUpdate()
        {
            _cooldown -= Time.fixedDeltaTime;
            if (_cooldown <= 0)
            {
                _targetComponent.Target = FindClosestTarget();
                _cooldown = Random.Range(_minCooldown, _maxCooldown);
            }
        }

        private GameObject FindClosestTarget()
        {
            Collider[] hits = Physics.OverlapSphere(transform.position, _detectDistance, _targetLayer);

            float minSqrDistance = float.MaxValue;
            GameObject closestTarget = null;

            foreach (var hit in hits)
            {
                if (!hit.transform.TryGetComponent(out HitboxComponent hitboxComponent))
                    continue;

                GameObject root = hitboxComponent.Root;
                if (!root.CompareTag("Player"))
                    continue;

                float sqrDistance = (hit.transform.position - transform.position).sqrMagnitude;

                if (sqrDistance < minSqrDistance)
                {
                    minSqrDistance = sqrDistance;
                    closestTarget = root;
                }
            }

            return closestTarget;
        }
    }
}