using Atomic.Entities;
using UnityEngine;

namespace SampleGame
{
    public class MoveController : MonoBehaviour
    {
        [SerializeField] private SceneEntity _character;

        private void Update()
        {
            HandleKeyboard();
        }

        private void HandleKeyboard()
        {
            Vector3 direction = Vector3.zero;

            if (Input.GetKey(KeyCode.UpArrow))
                direction.z = 1;
            else if (Input.GetKey(KeyCode.DownArrow))
                direction.z = -1;

            if (Input.GetKey(KeyCode.LeftArrow))
                direction.x = -1;
            else if (Input.GetKey(KeyCode.RightArrow))
                direction.x = 1;
            
            _character.GetMoveDirection().Value = direction;
        }
    }
}