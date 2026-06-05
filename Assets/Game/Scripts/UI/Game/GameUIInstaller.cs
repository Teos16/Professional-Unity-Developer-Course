using Atomic.Entities;
using Game.App;
using Game.Gameplay;
using TMPro;
using UnityEngine;

namespace Game.UI
{
    public sealed class GameUIInstaller : SceneEntityInstaller<IGameUI>
    {
        [Header("Countdown")]
        [SerializeField] private TMP_Text _countdownView;

        [Header("Score")]
        [SerializeField] private ScoreView _blueScoreView;
        [SerializeField] private ScoreView _redScoreView;
        [SerializeField] private GameOverPopupView _gameOverPopup;

        [SerializeField] private TeamCatalog _teamCatalog;
        
        
        public override void Install(IGameUI ui)
        {
            AppContext.TryGetInstance(out AppContext appContext);
            GameContext gameContext = GameContext.Instance;
            
            ui.AddValue(GameUIAPI.CountdownView, _countdownView);
            ui.AddBehaviour(new CountdownPresenter(gameContext));
            
            ui.AddBehaviour(new ScorePresenter(_blueScoreView, TeamType.BLUE, gameContext));
            ui.AddBehaviour(new ScorePresenter(_redScoreView, TeamType.RED, gameContext));
            
            ui.AddValue(GameUIAPI.GameOverPopupView, _gameOverPopup);
            ui.AddBehaviour(new GameOverPopupPresenter(_teamCatalog, gameContext, appContext));
        }
    }
}