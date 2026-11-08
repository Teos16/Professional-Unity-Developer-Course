using System.Collections.Generic;
using Fusion;

namespace Game
{
    public sealed class EnemyRegistry : NetworkBehaviour
    {
        private readonly List<NetworkObject> _enemies = new();

        public IReadOnlyList<NetworkObject> Enemies
        {
            get
            {
                _enemies.RemoveAll(e => e == null || !e.IsValid);
                return _enemies;
            }
        }

        public int Count => Enemies.Count;

        public void Register(NetworkObject enemy) => _enemies.Add(enemy);
    }
}
