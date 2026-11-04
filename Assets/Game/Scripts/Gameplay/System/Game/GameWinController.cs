using Fusion;
using UnityEngine;

namespace Game
{
    public sealed class GameWinController : NetworkBehaviour
    {
        [SerializeField] private Portal _portal;
        [SerializeField] private WaveSpawner _waveSpawner;
        [SerializeField] private GameCycle _gameCycle;

        public override void FixedUpdateNetwork()
        {
            if (_gameCycle.State == GameStatus.Playing && 
                _waveSpawner.IsFinished && 
                _waveSpawner.AreAllEnemiesDead() && 
                _portal.GetBehaviour<HealthComponent>().IsAlive) 
                _gameCycle.Win();
        }
    }
}