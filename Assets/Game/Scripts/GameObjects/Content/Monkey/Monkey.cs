using UnityEngine;

namespace Game
{
    [RequireComponent(typeof(HealthComponent), typeof(JumpRequestComponent), typeof(JumpRigidbodyComponent))]
    [RequireComponent(typeof(GroundedComponent), typeof(CollisionComponent), typeof(OverlapComponent))]
    [RequireComponent(typeof(OverlapDetectTargetComponent), typeof(PushRigidbodyComponent), typeof(ExtraGravityComponent))]
    public sealed class Monkey : MonoBehaviour, 
        JumpRequestComponent.IAction, 
        JumpRequestComponent.ICondition,
        OverlapDetectTargetComponent.ICondition,
        PushRigidbodyComponent.ICondition
    {
        [SerializeField] private AttackConfig _attackConfig;
        [SerializeField] private float _pushRange = 5f;
        
        private HealthComponent _healthComponent;
        private JumpRequestComponent _jumpRequestComponent;
        private JumpRigidbodyComponent _jumpRigidbodyComponent;
        private GroundedComponent _groundedComponent;
        private CollisionComponent _collisionComponent;
        private OverlapComponent _overlapComponent;
        private OverlapDetectTargetComponent _overlapDetectTargetComponent;
        private PushRigidbodyComponent _pushRigidbodyComponent;

        private void Awake()
        {
            _healthComponent = GetComponent<HealthComponent>();
            _groundedComponent = GetComponent<GroundedComponent>();
            _jumpRequestComponent = GetComponent<JumpRequestComponent>();
            _jumpRigidbodyComponent = GetComponent<JumpRigidbodyComponent>();
            _collisionComponent = GetComponent<CollisionComponent>();
            _overlapComponent = GetComponent<OverlapComponent>();
            _overlapDetectTargetComponent = GetComponent<OverlapDetectTargetComponent>();
            _pushRigidbodyComponent = GetComponent<PushRigidbodyComponent>();
            
            _jumpRequestComponent.SetAction(this);
            _jumpRequestComponent.SetCondition(this);
            _overlapDetectTargetComponent.SetCondition(this);
            _pushRigidbodyComponent.SetCondition(this);
        }

        private void OnEnable()
        {
            _groundedComponent.OnGrounded += AttackOnLanding;
            _collisionComponent.OnEntered += AttackOnCollision;
        }

        private void OnDisable()
        {
            _groundedComponent.OnGrounded -= AttackOnLanding;
            _collisionComponent.OnEntered -= AttackOnCollision;
        }

        void JumpRequestComponent.IAction.Invoke() => _jumpRigidbodyComponent.Jump();

        bool JumpRequestComponent.ICondition.Evaluate() => _healthComponent.IsAlive && _groundedComponent.IsGrounded;

        bool OverlapDetectTargetComponent.ICondition.EvaluateTarget(GameObject target) =>
            target.TryGetComponent(out Character character) 
            && target.TryGetComponent(out HealthComponent healthComponent) 
            && healthComponent.IsAlive;

        private void AttackOnCollision(Collision2D col)
        {
            if(!_healthComponent.IsAlive) 
                return;

            AttackTarget(col);
        }

        private void AttackTarget(Collision2D col)
        {
            if (!col.otherRigidbody)
                return;
            
            if (!col.gameObject.TryGetComponent(out HealthComponent targetHealth) || !targetHealth.IsAlive)
                return;
            
            _pushRigidbodyComponent.TryPush(col.otherRigidbody, _attackConfig.PushConfig, transform.position);
            targetHealth.TakeDamage(_attackConfig.Damage);
        }

        private void AttackOnLanding(bool _)
        {
            if(!_healthComponent.IsAlive || !_groundedComponent.IsGrounded)
                return;
            
            _jumpRequestComponent.TryJump();
            GetTargetsAndPush();
        }

        private void GetTargetsAndPush()
        {
            int count = _overlapComponent.Detect(out Collider2D[] colliders);
            if (count == 0) return;
            
            for (int i = 0; i < count; i++)
            {
                Collider2D col = colliders[i];
                
                if (!col || col.gameObject == gameObject || !col.attachedRigidbody) 
                    continue;
                
                if (!col.TryGetComponent(out GroundedComponent targetGrounded) || !targetGrounded.IsGrounded) 
                    continue;
                
                if (Vector2.Distance(transform.position, col.transform.position) > _pushRange)
                    continue;
                
                _pushRigidbodyComponent.TryPush(col.attachedRigidbody, _attackConfig.PushConfig, transform.position);
            }
        }
        
        bool PushRigidbodyComponent.ICondition.Evaluate() => _healthComponent.IsAlive && _groundedComponent.IsGrounded;
    }
}