using Fusion;
using UnityEngine;

namespace Game
{
    public sealed class Player : NetworkBehaviour
    {
        [field:SerializeField] public NetworkObject Character { get; private set; }
        
        public override void FixedUpdateNetwork()
        {
            if (this.GetInput(out PlayerInputData inputData)) 
                this.ProcessMove(inputData);
        }
        
        private void ProcessMove(PlayerInputData inputData)
        {
            Vector3 moveDirection = new Vector3(inputData.moveDirection.x, 0, inputData.moveDirection.y);
            Character.GetBehaviour<MoveComponent>().Move(moveDirection);
        }
    }
}