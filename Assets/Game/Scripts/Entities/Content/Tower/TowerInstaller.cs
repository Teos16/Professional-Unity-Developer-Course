using Atomic.Elements;
using Atomic.Entities;
using SampleGame;
using UnityEngine;

namespace Game
{
    public sealed class TowerInstaller : SceneEntityInstaller
    {
        [SerializeField] private SceneEntity _initialTarget;
        [SerializeField] private TransformInstaller _transformInstaller;
        [SerializeField] private RotationInstaller _rotationInstaller;
        [SerializeField] private HealthInstaller _healthInstaller;
        
        public override void Install(IEntity entity)
        {
            _transformInstaller.Install(entity);
            _rotationInstaller.Install(entity);
            _healthInstaller.Install(entity);
            
            entity.AddTakeDamageAction(new InlineAction<int>(entity.TakeDamage));
            
            entity.AddTarget(new Variable<IEntity>(_initialTarget));
            entity.AddBehaviour<LookAtTargetBehaviour>();
        }
    }
}