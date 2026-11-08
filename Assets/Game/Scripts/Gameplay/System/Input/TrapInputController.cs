using Fusion;
using UnityEngine;

namespace Game
{
    public sealed class TrapInputController : SimulationBehaviour
    {
        private TrapSpawner _spawner;

        private void Update()
        {
            if (Runner == null || !Runner.IsRunning)
                return;

            if (!TryGetLocalTrapSpawner(out TrapSpawner spawner))
                return;

            foreach (TrapConfig trap in spawner.Traps)
            {
                if (Input.GetKeyDown(trap.Key))
                    spawner.Place(trap);
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
