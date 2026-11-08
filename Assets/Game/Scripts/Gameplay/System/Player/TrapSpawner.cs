using System;
using System.Collections.Generic;
using Fusion;
using UnityEngine;

namespace Game
{
    public sealed class TrapSpawner : NetworkBehaviour
    {
        [SerializeField] private TrapConfig[] _traps;

        private Player _player;
        private Wallet _wallet;

        public IReadOnlyList<TrapConfig> Traps => _traps;

        public override void Spawned()
        {
            _player = GetBehaviour<Player>();
            if (HasStateAuthority)
                _wallet = FindFirstObjectByType<Wallet>();
        }

        public void Place(TrapConfig trap)
        {
            int index = Array.IndexOf(_traps, trap);
            if (index >= 0)
                RpcPlace(index);
        }

        [Rpc(RpcSources.InputAuthority, RpcTargets.StateAuthority)]
        private void RpcPlace(int index)
        {
            if (index < 0 || index >= _traps.Length)
                return;

            TrapConfig trap = _traps[index];
            if (_wallet.TrySpend(trap.Cost))
                Runner.Spawn(trap.Prefab, _player.Character.transform.position, Quaternion.identity);
        }
    }
}
