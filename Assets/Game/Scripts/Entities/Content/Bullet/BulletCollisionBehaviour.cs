using Atomic.Elements;
using Atomic.Entities;
using SampleGame;
using UnityEngine;

namespace Game
{
    public sealed class BulletCollisionBehaviour : IEntityInit, IEntityDispose
    {
        private TriggerEvents _trigger;
        private IValue<int> _damage;
        private IEntity _self;
        
        public void Init(IEntity entity)
        {
            _self = entity;
            _damage = entity.GetDamage();
            _trigger = entity.GetTrigger();
            _trigger.OnEntered += OnTriggerEntered;
        }

        public void Dispose(IEntity entity)
        {
            _trigger.OnEntered -= OnTriggerEntered;
        }

        private void OnTriggerEntered(Collider col)
        {
            if (col.TryGetComponent(out IEntity entity) && entity.HasDamageableTag())
            {
                IAction<int> damageAction = entity.GetTakeDamageAction();
                damageAction?.Invoke(_damage.Value);
                
                if(entity.TryGetMoveConditon(out IExpression<bool> condition))
                    condition.Add(() => false);
                
                SceneEntity.Destroy(_self);
            }
        }
    }
}