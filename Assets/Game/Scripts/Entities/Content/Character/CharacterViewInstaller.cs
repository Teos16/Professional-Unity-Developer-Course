using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game
{
    public sealed class CharacterViewInstaller : SceneEntityInstaller
    {
        private static readonly int Death = Animator.StringToHash("Death");
        
        [SerializeField] private Animator _animator;
        
        private readonly DisposableComposite _disposables = new();
        
        public override void Install(IEntity entity)
        {
            entity.AddAnimator(_animator);
            entity.AddBehaviour<MoveAnimBehaviour>();
            entity.GetHealth().Subscribe(health =>
            {
                if (health <= 0)
                    _animator.SetTrigger(Death);
            }).AddTo(_disposables);
        }
        
        public override void Uninstall(IEntity entity) => 
            _disposables.Dispose();
    }
}