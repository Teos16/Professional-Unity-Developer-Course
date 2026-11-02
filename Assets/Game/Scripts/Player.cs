using Fusion;
using UnityEngine;

namespace Game
{
    public sealed class Player : NetworkBehaviour
    {
        [SerializeField] private NetworkObject _character;
        
        [Networked] private NetworkButtons _previousButtons { get; set; }

        public override void FixedUpdateNetwork()
        {
            if (this.GetInput(out PlayerInputData inputData))
            {
                NetworkButtons inputButtons = inputData.buttons;
                this.ProcessMove(inputButtons, inputData);
                _previousButtons = inputButtons;
            }
        }
        
        private void ProcessMove(
            NetworkButtons inputButtons, PlayerInputData inputData)
        {
            bool isSprint = inputButtons.IsSet(PlayerInputButtons.Sprint);
            Vector3 moveDirection = new Vector3(
                inputData.moveDirection.x, 0, inputData.moveDirection.y);
            _character.GetBehaviour<MoveComponent>()
                .Move(moveDirection, isSprint);
        }
    }
}