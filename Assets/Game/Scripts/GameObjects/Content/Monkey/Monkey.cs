using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game
{
    [RequireComponent(typeof(HealthComponent), typeof(JumpRequestComponent), typeof(JumpRigidbodyComponent))] 
    [RequireComponent(typeof(ExtraGravityComponent), typeof(LookComponent), typeof(CollisionComponent))] 
    [RequireComponent(typeof(GroundedComponent))]
    public sealed class Monkey : MonoBehaviour, 
        JumpRequestComponent.IAction, 
        JumpRequestComponent.ICondition,
        PushRigidbodyComponent.ICondition
    {
        [SerializeField, Title("Attack Parameters")] private AttackComponent _attackOnLandingComponent;
        [SerializeField] private PushRigidbodyComponent _pushRigidbodyComponent;
        [SerializeField] private OverlapDetectComponent _attackOnLandingDetectComponent;
        [SerializeField] private AttackComponent _attackOnCollisionComponent;
        [SerializeField, Title("Detect Parameters")] private TriggerComponent _lookTriggerComponent;

        private HealthComponent _healthComponent;
        private JumpRequestComponent _jumpRequestComponent;
        private JumpRigidbodyComponent _jumpRigidbodyComponent;
        private ExtraGravityComponent _extraGravityComponent;
        private LookComponent _lookComponent;
        private GroundedComponent _groundedComponent;
        private CollisionComponent _collisionComponent;

        private void Awake()
        {
            _healthComponent = GetComponent<HealthComponent>();
            _jumpRequestComponent = GetComponent<JumpRequestComponent>();
            _jumpRigidbodyComponent = GetComponent<JumpRigidbodyComponent>();
            _extraGravityComponent = GetComponent<ExtraGravityComponent>();
            _lookComponent = GetComponent<LookComponent>();
            _groundedComponent = GetComponent<GroundedComponent>();
            _collisionComponent = GetComponent<CollisionComponent>();
            
            _jumpRequestComponent.SetAction(this);
            _jumpRequestComponent.SetCondition(this);
            _pushRigidbodyComponent.SetCondition(this);
            _attackOnCollisionComponent.SetConditions(EvaluateAttackTarget, EvaluateConditionsOnCollision);
            _attackOnLandingComponent.SetConditions(EvaluateAttackTarget, EvaluateConditionsOnLanding);
        }

        private void OnEnable()
        {
            _groundedComponent.OnGrounded += AttackOnLanding;
            _collisionComponent.OnEntered += AttackOnCollision;
            _lookTriggerComponent.OnTargetsChanged += LookAtTarget;
        }

        private void OnDisable()
        {
            _groundedComponent.OnGrounded -= AttackOnLanding;
            _collisionComponent.OnEntered -= AttackOnCollision;
            _lookTriggerComponent.OnTargetsChanged -= LookAtTarget;
        }

        void JumpRequestComponent.IAction.Invoke() => _jumpRigidbodyComponent.Jump();

        bool JumpRequestComponent.ICondition.Evaluate() => _healthComponent.IsAlive && _groundedComponent.IsGrounded;

        bool PushRigidbodyComponent.ICondition.Evaluate() => _healthComponent.IsAlive && _groundedComponent.IsGrounded;

        private void AttackOnCollision(Collision2D col) => _attackOnCollisionComponent.Attack(col);

        private bool EvaluateAttackTarget(GameObject target) => 
            target.TryGetComponent(out HealthComponent enemyHealth) && enemyHealth.IsAlive;

        private bool EvaluateConditionsOnLanding() => _healthComponent.IsAlive && _groundedComponent.IsGrounded;

        private bool EvaluateConditionsOnCollision() => _healthComponent.IsAlive;

        private void AttackOnLanding(bool _)
        {
            _jumpRequestComponent.TryJump();
            GetTargetsAndAttack();
        }

        private void LookAtTarget(IReadOnlyCollection<Collider2D> targets)
        {
            foreach (Collider2D col in targets)
            {
                if (!col.TryGetComponent(out Character character)) continue;
                
                _lookComponent.Look(character.transform);
                return;
            }
        }

        private void GetTargetsAndAttack()
        {
            int count = _attackOnLandingDetectComponent.Detect(out Collider2D[] colliders);
            if (count == 0) return;
            
            for (int i = 0; i < count; i++)
            {
                Collider2D col = colliders[i];
                if (col == null || col.attachedRigidbody == null) 
                    continue;
                _attackOnLandingComponent.Attack(col);
            }
        }
    }
}