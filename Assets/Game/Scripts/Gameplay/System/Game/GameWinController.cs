using Fusion;
using UnityEngine;

namespace Game
{
    public sealed class GameWinController : NetworkBehaviour
    {
        [SerializeField] private Portal _portal;

        private GameCycle _gameCycle;
        private WaveManager _waveManager;
        private TeamStatus _teamStatus;
        private EnemyRegistry _enemyRegistry;
        private HealthComponent _portalHealth;

        public override void Spawned()
        {
            _gameCycle = GetBehaviour<GameCycle>();
            _waveManager = GetBehaviour<WaveManager>();
            _teamStatus = GetBehaviour<TeamStatus>();
            _enemyRegistry = GetBehaviour<EnemyRegistry>();
            _portalHealth = _portal.GetBehaviour<HealthComponent>();
        }

        public override void FixedUpdateNetwork()
        {
            if (_gameCycle.State == GameStatus.Playing &&
                _waveManager.IsFinished &&
                _enemyRegistry.Count == 0 &&
                _portalHealth.IsAlive &&
                _teamStatus.AreAllCharactersAlive())
                _gameCycle.Win();
        }
    }
}
