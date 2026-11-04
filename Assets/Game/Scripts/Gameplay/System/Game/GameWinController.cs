using Fusion;
using UnityEngine;

namespace Game
{
    public sealed class GameWinController : NetworkBehaviour
    {
        [SerializeField] private Portal _portal;
        [SerializeField] private WaveManager waveManager;
        [SerializeField] private GameCycle _gameCycle;
        [SerializeField] private TeamStatus _teamStatus;

        public override void FixedUpdateNetwork()
        {
            if (_gameCycle.State == GameStatus.Playing && 
                waveManager.IsFinished && 
                waveManager.AreAllEnemiesDead() && 
                _portal.GetBehaviour<HealthComponent>().IsAlive &&
                _teamStatus.AreAllCharactersAlive())
                _gameCycle.Win();
        }
    }
}