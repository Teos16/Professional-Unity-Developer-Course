using Atomic.Elements;
using Atomic.Entities;
using SampleGame;
using UnityEngine;

namespace Game
{
    public sealed class BulletInstaller : SceneEntityInstaller
    {
        [SerializeField] private TransformInstaller _transformInstaller;
        [SerializeField] private MoveInstaller _moveInstaller; 
        [SerializeField] private TriggerEvents _triggerEvents;
        [SerializeField] private Const<int> _damage;
        
        public override void Install(IEntity entity)
        {
            _transformInstaller.Install(entity);
            _moveInstaller.Install(entity);
            
            entity.AddTrigger(_triggerEvents);
            entity.AddDamage(_damage);
            entity.AddBehaviour<BulletMoveBehaviour>();
            entity.AddBehaviour<BulletCollisionBehaviour>();
        }
    }
}