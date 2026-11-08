using Fusion;
using UnityEngine;

namespace Game
{
    public sealed class MoveAnimationView : NetworkBehaviour
    {
        private static readonly int IsMoving = Animator.StringToHash(nameof(IsMoving));

        [SerializeField] private Animator _animator;
        
        private MoveComponent _move;
        
        public override void Spawned() => _move = this.Object.GetBehaviour<MoveComponent>();
        
        public override void Render() => _animator.SetBool(IsMoving, _move.IsMoving);
    }
}