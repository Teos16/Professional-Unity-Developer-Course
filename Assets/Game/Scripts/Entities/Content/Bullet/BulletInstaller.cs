using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game
{
    public sealed class BulletInstaller : SceneEntityInstaller
    {
        [SerializeField] private TransformInstaller _transformInstaller;
        [SerializeField] private MoveInstaller _moveInstaller;
        [SerializeField] private LifetimeInstaller _lifetimeInstaller;
        [SerializeField] private TriggerEvents _triggerEvents;
        [SerializeField] private Const<int> _damage;
        [SerializeField] private Const<float> _moveSpeed = 10;
        
        public override void Install(IEntity entity)
        {
            _transformInstaller.Install(entity);
            _moveInstaller.Install(entity);
            _lifetimeInstaller.Install(entity);
            
            entity.AddMoveSpeed(_moveSpeed);

            entity.AddTrigger(_triggerEvents);
            entity.AddDamage(_damage);
            entity.WhenFixedTick(deltaTime => 
                                    entity.MoveStep(entity.GetRotation().Value * Vector3.forward, deltaTime));


            entity.AddBehaviour<BulletCollisionBehaviour>();
            entity.AddDestroyAction(new InlineAction(() => GameContext.Instance.DespawnBullet((SceneEntity)entity)));
            entity.AddRespawnAction(new InlineAction(() => entity.GetLifetime().ResetTime()));
        }
    }
}