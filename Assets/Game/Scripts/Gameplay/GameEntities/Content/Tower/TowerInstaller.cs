using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game.Gameplay
{
    public sealed class TowerInstaller : GameEntityInstaller
    {
        [SerializeField]
        private GameEntity _initialTarget;
        
        [SerializeField]
        private TransformInstaller _transformInstaller;

        [SerializeField]
        private RotateInstaller _rotateInstaller;
        
        [SerializeField]
        private HealthInstaller _healthInstaller;
        
        [SerializeField]
        private Const<float> _rotateSpeed = 720;
        
        [SerializeField]
        private TakeDamageInstaller _takeDamageInstaller;

        private readonly DisposableComposite _disposables = new();
        
        public override void Install(IGameEntity entity)
        {
            _transformInstaller.Install(entity);
            
            _rotateInstaller.Install(entity);
            entity.GetRotateCondition().Add(_ => entity.DoesHealthExist());
            entity.GetRotateAction().Add(entity.RotateStep);
            entity.AddRotationSpeed(_rotateSpeed);
            
            _healthInstaller.Install(entity);
            _takeDamageInstaller.Install(entity);
            
            entity.GetTakeDamageAction().Add(damage => entity.ReduceHealth(damage));
            entity.GetHealth().Subscribe(health => this.gameObject.SetActive(health > 0)).AddTo(_disposables);
            
            entity.AddTarget(new Variable<IGameEntity>(_initialTarget));
            entity.AddBehaviour<LookAtTargetBehaviour>();
        }

        public override void Uninstall(IGameEntity entity)
        {
            _disposables.Dispose();
        }
    }
}