using Fusion;
using UnityEngine;

namespace Game
{
    public sealed class PlayerJoinController : MonoBehaviour
    {
        [SerializeField]
        private NetworkEvents _networkEvents;

        [SerializeField]
        private GameObject _characterPrefab;

        private void OnEnable()
        {
            _networkEvents.PlayerJoined.AddListener(this.OnPlayerJoined);
        }

        private void OnDisable()
        {
            _networkEvents.PlayerJoined.RemoveListener(this.OnPlayerJoined);
        }

        private void OnPlayerJoined(NetworkRunner runner, PlayerRef playerRef)
        {
            if (runner.IsServer)
            {
                NetworkObject character = runner.Spawn(
                    _characterPrefab, Vector3.zero, Quaternion.identity,
                    playerRef);
                runner.SetPlayerObject(playerRef, character);
            }
        }
    }
}