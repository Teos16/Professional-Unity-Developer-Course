using UnityEngine;

namespace Game
{
    public sealed class MoveAnimationComponent : MonoBehaviour
    {
        private static readonly int IsMoving = Animator.StringToHash("IsMoving");

        private MoveComponent _moveComponent;
        private Animator _animator;

        private void Awake()
        {
            _moveComponent = GetComponentInParent<MoveComponent>();
            _animator = GetComponentInChildren<Animator>();
        }

        private void Update() => _animator.SetBool(IsMoving, _moveComponent.IsMoving);
    }
}