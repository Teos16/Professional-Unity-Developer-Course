using Fusion;
using UnityEngine;

namespace Game
{
    public sealed class GameLoseController : NetworkBehaviour
    {
        [SerializeField] private Portal _portal;
        [SerializeField] private GameCycle _gameCycle;
        [SerializeField] private WaveManager _waveManager;
        [SerializeField] private TeamStatus _teamStatus;
        
        public override void FixedUpdateNetwork()
        {
            if (_gameCycle.State == GameStatus.Playing &&
                (_portal.GetBehaviour<HealthComponent>().IsDead || _teamStatus.IsAnyCharacterDead())) 
            {
                _waveManager.StopWave();
                _gameCycle.Lose();
            }
        }
    }
}