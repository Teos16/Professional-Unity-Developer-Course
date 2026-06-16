using UnityEngine;

namespace Game.UI
{
    [RequireComponent(typeof(JoystickView))]
    public sealed class Joystick : MonoBehaviour
    {
        [field:SerializeField]
        public Vector2 Direction { get; private set; }
        
        private JoystickView _view;
        private float _radius;

        private void Awake()
        {
            _view = GetComponent<JoystickView>();
            _radius = _view.Radius;
        }

        private void OnEnable()
        {
            _view.OnDragged += OnDragged;
            _view.OnReleased += OnReleased;
        }

        private void OnDisable()
        {
            _view.OnDragged -= OnDragged;
            _view.OnReleased -= OnReleased;
        }

        private void OnDragged(Vector2 localPoint)
        {
            Vector2 clamped = Vector2.ClampMagnitude(localPoint, _radius);
            Direction = (clamped / _radius).normalized;
            _view.SetHandlePosition(clamped);
        }

        private void OnReleased()
        {
            Direction = Vector2.zero;
            _view.SetHandlePosition(Vector2.zero);
        }
    }
}