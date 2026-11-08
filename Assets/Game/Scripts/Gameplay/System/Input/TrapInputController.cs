using System;
using Fusion;
using UnityEngine;

namespace Game
{
    public sealed class TrapInputController : SimulationBehaviour
    {
        [Serializable]
        private struct TrapBinding
        {
            public KeyCode key;
            public TrapConfig trap;
        }

        [SerializeField] private TrapBinding[] _bindings;

        private TrapSpawner _spawner;

        private void Update()
        {
            if (Runner == null || !Runner.IsRunning)
                return;

            foreach (TrapBinding binding in _bindings)
            {
                if (Input.GetKeyDown(binding.key) && TryGetLocalTrapSpawner(out TrapSpawner spawner))
                    spawner.Place(binding.trap);
            }
        }

        private bool TryGetLocalTrapSpawner(out TrapSpawner spawner)
        {
            if (_spawner == null && Runner.TryGetPlayerObject(Runner.LocalPlayer, out NetworkObject player))
                player.TryGetBehaviour(out _spawner);

            spawner = _spawner;
            return spawner != null;
        }
    }
}