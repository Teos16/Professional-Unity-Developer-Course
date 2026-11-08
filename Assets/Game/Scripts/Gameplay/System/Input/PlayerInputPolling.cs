using Fusion;
using UnityEngine;

namespace Game
{
    public sealed class PlayerInputPolling : MonoBehaviour
    {
        [SerializeField] private NetworkEvents _networkEvents;

        private PlayerInputData _playerInput;

        private void OnEnable() => _networkEvents.OnInput.AddListener(OnInput);

        private void OnDisable() => _networkEvents.OnInput.RemoveListener(OnInput);

        private void Update()
        {
            float dx = Input.GetAxis("Horizontal");
            float dz = Input.GetAxis("Vertical");

            _playerInput = new PlayerInputData
            {
                moveDirection = new Vector2(dx, dz)
            };
        }

        private void OnInput(NetworkRunner runner, NetworkInput input) => input.Set(_playerInput);
    }
}
