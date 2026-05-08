using UnityEngine;

namespace SampleGame.Components
{
    public sealed class MoveComponentView : MonoBehaviour
    {
        private static readonly int IsMoving = Animator.StringToHash("IsMoving");
        
        [SerializeField] private Animator _animator;

        private MoveRequestComponent _moveRequestComponent;

        private void Awake() => 
            _moveRequestComponent = this.GetComponentInParent<MoveRequestComponent>();


        private void Update() => 
            _animator.SetBool(IsMoving, _moveRequestComponent.IsMoving);
    }
}