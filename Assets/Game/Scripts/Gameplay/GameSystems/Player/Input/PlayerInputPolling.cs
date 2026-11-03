using Fusion;
using UnityEngine;

namespace Game
{
    public sealed class PlayerInputPolling : MonoBehaviour
    {
        [SerializeField] private NetworkEvents _networkEvents;
        
        private PlayerInputData _playerInput;

        private void OnEnable() =>
            _networkEvents.OnInput.AddListener(this.OnInput);

        private void OnDisable() =>
            _networkEvents.OnInput.RemoveListener(this.OnInput);

        private void Update()
        {
            float dx = Input.GetAxis("Horizontal");
            float dz = Input.GetAxis("Vertical");
            
            NetworkButtons buttons = new NetworkButtons();

            _playerInput = new PlayerInputData
            {
                moveDirection = new Vector2(dx, dz),
                buttons = buttons
            };
        }
        
        private void OnInput(NetworkRunner runner, NetworkInput input)
        {
            input.Set(_playerInput);
        }
    }
}