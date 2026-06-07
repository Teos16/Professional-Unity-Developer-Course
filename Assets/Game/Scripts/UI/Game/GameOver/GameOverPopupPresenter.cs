using Atomic.Elements;
using Atomic.Entities;
using Cysharp.Threading.Tasks;
using Game.App;
using Game.Gameplay;
using UnityEngine;

namespace Game.UI
{
    public sealed class GameOverPopupPresenter : IGameUIInit, IGameUIDispose
    {
        private readonly IGameContext _gameContext;
        private readonly IAppContext _appContext;
        private readonly TeamCatalog _teamCatalog;

        private GameOverPopupView _view;
        private Subscription _subscription;

        public GameOverPopupPresenter(
            TeamCatalog teamCatalog,
            IGameContext gameContext,
            IAppContext appContext
        )
        {
            _gameContext = gameContext;
            _appContext = appContext;
            _teamCatalog = teamCatalog;
        }

        public void Init(IGameUI ui)
        {
            _subscription = _gameContext.GetGameFinishedEvent().Subscribe(this.OnGameFinished);
            _view = ui.GetValue(GameUIAPI.GameOverPopupView);
            
            _view.Hide();
            _view.OnContinueClicked += this.OnContinueClicked;
            _view.OnCloseClicked += this.OnCloseClicked;
        }

        public void Dispose(IGameUI entity)
        {
            _subscription.Dispose();
            _view.OnContinueClicked -= this.OnContinueClicked;
            _view.OnCloseClicked -= this.OnCloseClicked;
        }

        private void OnGameFinished()
        {
            TeamType winner = _gameContext.GetWinnerTeam();
            string message = winner == TeamType.NEUTRAL ? "DRAW" : $"{winner} PLAYER \nWINS";
            _view.SetMessage(message);

            Color color = _teamCatalog.GetTeam(winner).Material.color;
            _view.SetMessageColor(color);
            _view.Show();
        }

        private void OnContinueClicked() => _appContext?.LoadGame().Forget();

        private void OnCloseClicked() => _appContext.LoadMenu().Forget();
    }
}