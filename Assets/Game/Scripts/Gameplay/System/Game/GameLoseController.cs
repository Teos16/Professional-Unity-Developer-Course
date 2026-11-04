using Fusion;
using UnityEngine;

namespace Game
{
    public sealed class GameLoseController : NetworkBehaviour
    {
        [SerializeField] private Portal _portal;
        [SerializeField] private GameCycle _gameCycle;
        [SerializeField] private WaveSpawner _waveSpawner;

        public override void FixedUpdateNetwork()
        {
            if (_gameCycle.State == GameStatus.Playing && _portal.GetBehaviour<HealthComponent>().IsDead) 
            {
                _waveSpawner.StopWave();
                _gameCycle.Lose();
            }
        }
    }
}