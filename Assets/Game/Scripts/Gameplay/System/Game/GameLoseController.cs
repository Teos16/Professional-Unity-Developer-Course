using Fusion;
using UnityEngine;

namespace Game
{
    public sealed class GameLoseController : NetworkBehaviour
    {
        [SerializeField] private Portal _portal;

        private GameCycle _gameCycle;
        private WaveManager _waveManager;
        private TeamStatus _teamStatus;
        private HealthComponent _portalHealth;

        public override void Spawned()
        {
            _gameCycle = GetBehaviour<GameCycle>();
            _waveManager = GetBehaviour<WaveManager>();
            _teamStatus = GetBehaviour<TeamStatus>();
            _portalHealth = _portal.GetBehaviour<HealthComponent>();
        }

        public override void FixedUpdateNetwork()
        {
            if (_gameCycle.State == GameStatus.Playing &&
                (_portalHealth.IsDead || _teamStatus.IsAnyCharacterDead()))
            {
                _waveManager.StopWave();
                _gameCycle.Lose();
            }
        }
    }
}
