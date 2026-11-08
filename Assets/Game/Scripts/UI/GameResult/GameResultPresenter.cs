using Fusion;
using UnityEngine;

namespace Game
{
    public sealed class GameResultPresenter : NetworkBehaviour
    {
        [SerializeField] private GameCycle _gameCycle;
        [SerializeField] private GameResultView _view;
        [SerializeField] private string _winText = "Victory";
        [SerializeField] private string _loseText = "Defeat";

        public override void Spawned()
        {
            _gameCycle = GetBehaviour<GameCycle>();
            _gameCycle.OnStateChanged += this.OnStateChanged;
            _view.OnMenuClicked += this.OnMenuClicked;

            this.OnStateChanged(_gameCycle.State);
        }

        public override void Despawned(NetworkRunner runner, bool hasState)
        {
            _gameCycle.OnStateChanged -= this.OnStateChanged;
            _view.OnMenuClicked -= this.OnMenuClicked;
        }

        private void OnStateChanged(GameStatus state)
        {
            switch (state)
            {
                case GameStatus.Won:
                    _view.Show(_winText);
                    break;
                case GameStatus.Lost:
                    _view.Show(_loseText);
                    break;
                default:
                    _view.Hide();
                    break;
            }
        }

        private void OnMenuClicked() => Runner.Shutdown();
    }
}