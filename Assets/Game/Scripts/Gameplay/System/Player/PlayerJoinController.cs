using Fusion;
using UnityEngine;

namespace Game
{
    public sealed class PlayerJoinController : MonoBehaviour
    {
        [SerializeField] private NetworkEvents _networkEvents;
        [SerializeField] private GameObject _playerPrefab;
        [SerializeField] private SpawnPointService _spawnPointService;

        private void OnEnable() => _networkEvents.PlayerJoined.AddListener(OnPlayerJoined);

        private void OnDisable() => _networkEvents.PlayerJoined.RemoveListener(OnPlayerJoined);

        private void OnPlayerJoined(NetworkRunner runner, PlayerRef playerRef)
        {
            if (!runner.IsServer)
                return;

            Transform spawnPoint = _spawnPointService.GetSpawnPoint(playerRef.AsIndex % _spawnPointService.Count);
            NetworkObject player = runner.Spawn(_playerPrefab, Vector3.zero, Quaternion.identity, playerRef);
            player.GetComponentInChildren<NetworkTransform>().Teleport(spawnPoint.position, spawnPoint.rotation);
            runner.SetPlayerObject(playerRef, player);
        }
    }
}
