using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game
{
    public sealed class TowerInstaller : SceneEntityInstaller
    {
        [SerializeField] private SceneEntity _initialTarget;
        [SerializeField] private TransformInstaller _transformInstaller;
        [SerializeField] private Const<float> _rotationSpeed = 720;
        [SerializeField] private RotateInstaller _rotateInstaller;
        [SerializeField] private HealthInstaller _healthInstaller;
        
        public override void Install(IEntity entity)
        {
            _transformInstaller.Install(entity);
            
            _rotateInstaller.Install(entity);
            entity.GetRotateCondition().Add(_ => entity.IsAlive());
            entity.GetRotateAction().Add(entity.RotateStep);
            entity.AddRotationSpeed(_rotationSpeed);
            
            _healthInstaller.Install(entity);
            
            entity.AddTakeDamageAction(new InlineAction<int>(entity.TakeDamage));
            entity.AddTarget(new Variable<IEntity>(_initialTarget));
            entity.AddBehaviour<LookAtTargetBehaviour>();
        }
    }
}