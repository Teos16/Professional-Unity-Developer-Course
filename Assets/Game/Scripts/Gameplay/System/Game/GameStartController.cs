using System.Linq;
using Fusion;
using UnityEngine;

namespace Game
{
    public sealed class GameStartController : NetworkBehaviour
    {
        [SerializeField] private int _startPlayerCount = 2;

        private GameCycle _gameCycle;
        private WaveManager _waveManager;

        public override void Spawned()
        {
            _gameCycle = GetBehaviour<GameCycle>();
            _waveManager = GetBehaviour<WaveManager>();
        }

        public override void FixedUpdateNetwork()
        {
            if (_gameCycle.State == GameStatus.Waiting && Runner.ActivePlayers.Count() == _startPlayerCount)
            {
                _gameCycle.StartGame();
                _waveManager.StartWave();
            }
        }
    }
}
