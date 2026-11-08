using UnityEngine;

namespace Game
{
    public sealed class SpawnPointService : MonoBehaviour
    {
        [SerializeField] private Transform[] _spawnPoints;

        public int Count => _spawnPoints.Length;

        public Transform GetSpawnPoint(int index) => _spawnPoints[index];

        public Transform GetRandomSpawnPoint() => _spawnPoints[Random.Range(0, Count)];
    }
}
