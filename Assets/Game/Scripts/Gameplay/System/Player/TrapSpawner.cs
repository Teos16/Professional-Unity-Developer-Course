using Fusion;
using UnityEngine;

namespace Game
{
    public sealed class TrapSpawner : NetworkBehaviour
    {
        [SerializeField] private NetworkPrefabRef _minePrefab;
        [SerializeField] private int _mineCost = 10;

        private Player _player;
        private Wallet _wallet;

        public override void Spawned()
        {
            _player = GetBehaviour<Player>();
            if (HasStateAuthority)
                _wallet = FindFirstObjectByType<Wallet>();
        }

        public void PlaceMine() => this.RpcPlaceMine();

        [Rpc(RpcSources.InputAuthority, RpcTargets.StateAuthority)]
        private void RpcPlaceMine()
        {
            if (_wallet.TrySpend(_mineCost))
                Runner.Spawn(_minePrefab, _player.Character.transform.position, Quaternion.identity);
        }
    }
}