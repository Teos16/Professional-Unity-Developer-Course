using UnityEngine;

namespace Game.Gameplay
{
    [CreateAssetMenu(
        fileName = "InputMap",
        menuName = "Game/New InputMap"
    )]
    public sealed class InputMap : ScriptableObject
    {
        [SerializeField]
        public KeyCode MoveForward = KeyCode.W;
        public KeyCode MoveBack = KeyCode.S;
        public KeyCode MoveLeft = KeyCode.A;
        public KeyCode MoveRight = KeyCode.D;

        [Space]
        public KeyCode Fire = KeyCode.Space;
        public KeyCode Interact = KeyCode.E;
        public KeyCode Drop = KeyCode.Q;
        
        public Vector3 GetMoveDirection()
        {
            Vector3 direction = Vector3.zero;

            if (Input.GetKey(MoveForward))
                direction.z = 1;
            else if (Input.GetKey(MoveBack))
                direction.z = -1;

            if (Input.GetKey(MoveLeft))
                direction.x = -1;
            else if (Input.GetKey(MoveRight))
                direction.x = 1;
            
            return direction;
        }
        
        public bool IsInteractPressed() => Input.GetKeyDown(Interact);

        public bool IsFirePressed() => Input.GetKeyDown(Fire);

        public bool IsDropPressed() => Input.GetKeyDown(Drop);
    }
}