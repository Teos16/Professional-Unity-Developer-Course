using Game.ShipRelated;
using Modules.Utils;
using UnityEngine;

namespace Game.Player
{
    public sealed class PlayerShipInputController : MonoBehaviour
    {
        private const string HORIZONTAL_AXIS = "Horizontal";
        private const string VERTICAL_AXIS = "Vertical";
        
        [SerializeField] private TransformBounds _playerArea;
        [SerializeField] private Ship _playerShip;
        
        private Vector2 _moveDirection;
        
        private void Update()
        {
            if (Input.GetKey(KeyCode.Space))
                _playerShip.Fire();
        }

        private void FixedUpdate()
        {
            float dx = Input.GetAxisRaw(HORIZONTAL_AXIS);
            float dy = Input.GetAxisRaw(VERTICAL_AXIS);
            _moveDirection = new Vector2(dx, dy);
            
            _playerShip.MoveStep(_moveDirection);
        }

        private void LateUpdate() => transform.position = _playerArea.ClampInBounds(transform.position);
    }
}