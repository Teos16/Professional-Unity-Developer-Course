using UnityEngine;

namespace Game
{
    [RequireComponent(typeof(TargetComponent), typeof(LookComponent))]
    public sealed class LookAtTargetComponent : MonoBehaviour
    {
        [SerializeField] private float _updateLookTime = 0.5f;
        
        private TargetComponent _targetComponent;
        private LookComponent _lookComponent;

        private float _nextAllowedLookTime;

        private void Awake()
        {
            _targetComponent = GetComponent<TargetComponent>();
            _lookComponent = GetComponent<LookComponent>();
        }

        private void FixedUpdate()
        {
            if( _targetComponent.Target != null && Time.time > _nextAllowedLookTime) 
            {
                _nextAllowedLookTime = Time.time + _updateLookTime;
                _lookComponent.Look(_targetComponent.Target.transform);
            }
        }
    }
}