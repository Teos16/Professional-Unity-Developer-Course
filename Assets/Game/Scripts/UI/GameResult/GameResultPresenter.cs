using Fusion;
using UnityEngine;

namespace Game
{
    public sealed class GameResultPresenter : NetworkBehaviour
    {
        [SerializeField] private GameResultView _view;
        [SerializeField] private string _winText = "Victory";
        [SerializeField] private string _loseText = "Defeat";

        private GameCycle _gameCycle;

        public override void Spawned()
        {
            _gameCycle = GetBehaviour<GameCycle>();
            _gameCycle.OnStateChanged += OnStateChanged;
            _view.OnMenuClicked += OnMenuClicked;

            OnStateChanged(_gameCycle.State);
        }

        public override void Despawned(NetworkRunner runner, bool hasState)
        {
            _gameCycle.OnStateChanged -= OnStateChanged;
            _view.OnMenuClicked -= OnMenuClicked;
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
