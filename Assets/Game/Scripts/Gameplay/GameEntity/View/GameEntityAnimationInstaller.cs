using System;
using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game.Gameplay
{
    [Serializable]
    public sealed class GameEntityAnimationInstaller : IGameEntityInstaller
    {
        private static readonly int Attack = Animator.StringToHash(nameof(Attack));
        private static readonly int TakeDamage = Animator.StringToHash(nameof(TakeDamage));
        private static readonly int Death = Animator.StringToHash(nameof(Death));
        
        [SerializeField] private Animator _animator;
        [SerializeField] private AnimatorEventReceiver _animatorEventReceiver;

        private readonly DisposableComposite _disposables = new();
        
        public void Install(IGameEntity entity)
        {
            entity.AddValue(GameEntityAPI.Animator, new Variable<Animator>(_animator));
            entity.AddValue(GameEntityAPI.AnimatorEventReceiver, new Variable<AnimatorEventReceiver>(_animatorEventReceiver));

            entity.GetValue(GameEntityAPI.AttackCommand)
                .Subscribe(() => _animator.SetTrigger(Attack)).AddTo(_disposables);
            entity.GetValue(GameEntityAPI.TakeDamageCommand)
                .Subscribe(_ => _animator.SetTrigger(TakeDamage)).AddTo(_disposables);
            entity.GetValue(GameEntityAPI.DeathEvent)
                .Subscribe(() => _animator.SetTrigger(Death)).AddTo(_disposables);
            
            entity.AddBehaviour(new GameEntityMoveAnimationBehaviour());
        }
        
        public void Uninstall(IGameEntity entity) => _disposables.Dispose();
    }
}