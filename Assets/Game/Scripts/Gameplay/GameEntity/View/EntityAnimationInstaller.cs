using System;
using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game.Gameplay
{
    [Serializable]
    public sealed class EntityAnimationInstaller : IGameEntityInstaller
    {
        private static readonly int Attack = Animator.StringToHash(nameof(Attack));
        private static readonly int TakeDamage = Animator.StringToHash(nameof(TakeDamage));
        private static readonly int Death = Animator.StringToHash(nameof(Death));
        
        [SerializeField] private Animator _animator;
        [SerializeField] private AnimationEvents _animationEvents;

        private readonly DisposableComposite _disposables = new();
        
        public void Install(IGameEntity entity)
        {
            entity.AddValue(GameEntityAPI.Animator, new Variable<Animator>(_animator));
            entity.AddValue(GameEntityAPI.AnimationEvents, new Variable<AnimationEvents>(_animationEvents));

            entity.GetValue(GameEntityAPI.AttackCommand)
                .Subscribe(() => _animator.SetTrigger(Attack)).AddTo(_disposables);
            entity.GetValue(GameEntityAPI.TakeDamageCommand)
                .Subscribe(_ => _animator.SetTrigger(TakeDamage)).AddTo(_disposables);
            entity.GetValue(GameEntityAPI.DeathEvent)
                .Subscribe(() => _animator.SetTrigger(Death)).AddTo(_disposables);
            
            entity.AddBehaviour(new MoveAnimationBehaviour());
        }
        
        public void Uninstall(IGameEntity entity) => _disposables.Dispose();
    }
}