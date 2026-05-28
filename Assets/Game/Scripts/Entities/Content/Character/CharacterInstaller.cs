using Atomic.Elements;
using Atomic.Entities;
using SampleGame;
using UnityEngine;

namespace Game
{
    public sealed class CharacterInstaller : SceneEntityInstaller
    {
        [SerializeField] private TransformInstaller _transformInstaller;
        [SerializeField] private MoveInstaller _moveInstaller; 
        [SerializeField] private RotationInstaller _rotationInstaller;
        [SerializeField] private HealthInstaller _healthInstaller;
        [SerializeField] private Const<float> _armorPercent = 0.5f;
        [SerializeField] private GameObject _gameObject;
        
        public override void Install(IEntity entity)
        {
            _transformInstaller.Install(entity);
            _moveInstaller.Install(entity);
            _rotationInstaller.Install(entity);
            _healthInstaller.Install(entity);

            entity.AddGameObject(_gameObject);
            entity.AddBehaviour<CharacterDeathBehaviour>();
            entity.GetMoveConditon().Add(entity.IsAlive);
            
            entity.AddTakeDamageAction(new InlineAction<int>(
                                    damage => entity.TakeDamageArmored(damage, _armorPercent)));
            entity.AddBehaviour<CharacterMoveBehaviour>();
        }
    }
}