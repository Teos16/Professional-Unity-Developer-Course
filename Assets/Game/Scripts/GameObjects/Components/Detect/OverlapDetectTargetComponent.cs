using UnityEngine;
using Random = UnityEngine.Random;

namespace Game
{
    [RequireComponent(typeof(TargetComponent), typeof(OverlapComponent))]
    public sealed class OverlapDetectTargetComponent : MonoBehaviour
    {
        public interface ICondition
        {
            bool EvaluateTarget(GameObject target);
        }

        [SerializeField] private OverlapComponent _overlapComponent;
        [SerializeField] private float _minCooldown = 0.2f;
        [SerializeField] private float _maxCooldown = 0.4f;

        private TargetComponent _targetComponent;
        private ICondition _condition;

        private float _cooldown;

        private void Awake()
        {
            if(_overlapComponent == null)
                _overlapComponent = GetComponent<OverlapComponent>();
            
            _targetComponent = GetComponent<TargetComponent>();
        }

        private void FixedUpdate()
        {
            _cooldown -= Time.fixedDeltaTime;
            if (_cooldown > 0)
                return;

            if(_condition == null) 
                return;
            
            _targetComponent.Target = FindClosestTarget();
            _cooldown = Random.Range(_minCooldown, _maxCooldown);
        }

        public void SetCondition(ICondition condition) => _condition = condition;

        private GameObject FindClosestTarget()
        {
            int count = _overlapComponent.Detect(out Collider2D[] cols);
            
            if(count == 0) 
                return null;

            float minSqrDistance = float.MaxValue;
            GameObject closestTarget = null;

            for (int i = 0; i < count; i++)
            {
                Collider2D col = cols[i];
                if (col == null || !col.gameObject || !_condition.EvaluateTarget(col.gameObject))
                    continue;

                float sqrDistance = (col.transform.position - transform.position).sqrMagnitude;
                if (sqrDistance < minSqrDistance)
                {
                    minSqrDistance = sqrDistance;
                    closestTarget = col.gameObject;
                }
            }

            return closestTarget;
        }
    }
}