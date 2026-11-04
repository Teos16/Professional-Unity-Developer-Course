using System.Linq;
using Fusion;
using UnityEngine;

namespace Game
{
    public sealed class GameStartController : NetworkBehaviour
    {
        [SerializeField] private int _startPlayerCount = 2;
        [SerializeField] private GameCycle _gameCycle;
        [SerializeField] private WaveSpawner _waveSpawner;

        public override void FixedUpdateNetwork()
        {
            if (_gameCycle.State == GameStatus.Waiting && Runner.ActivePlayers.Count() == _startPlayerCount)
            {
                _gameCycle.StartGame();
                _waveSpawner.StartWave();
            }
        }
    }
}