using UnityEngine;

namespace Game.Scripts.System
{
    public sealed class MovementController : MonoBehaviour
    {
        [SerializeField] private GameObject _character;

        private void Update()
        {
            Vector2 moveDirection;
            
            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
                moveDirection = Vector2.left;
            else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
                moveDirection = Vector2.right;
            else
                moveDirection = Vector2.zero;
                 
            if (moveDirection != Vector2.zero)
                _character.GetComponent<MoveComponent>().RequestMove(moveDirection);
        }
    }
}