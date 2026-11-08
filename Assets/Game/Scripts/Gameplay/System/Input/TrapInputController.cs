using Fusion;
using UnityEngine;

namespace Game
{
    public sealed class TrapInputController : SimulationBehaviour
    {
        [SerializeField] private KeyCode _mineKey = KeyCode.Q;
        
        private TrapSpawner _spawner;

        private void Update()
        {
            if (Runner == null || !Runner.IsRunning)
                return;

            if (Input.GetKeyDown(_mineKey) && TryGetLocalTrapSpawner(out TrapSpawner spawner))
                spawner.PlaceMine();
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