using Atomic.Elements;
using Atomic.Entities;
using Game.Gameplay;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.UI
{
    public sealed class GameUIInstaller : SceneEntityInstaller<IGameUI>
    {
        [BoxGroup("VIEWS"), SerializeField] private StatView _healthStatView;
        [BoxGroup("VIEWS"), SerializeField] private StatView _ammoStatView;
        [BoxGroup("VIEWS"), SerializeField] private ScoreView _scoreView;
        [BoxGroup("VIEWS"), SerializeField] private HealthScreenView _healthScreenView;
        [BoxGroup("JOYSTICKS"), SerializeField] private Joystick _moveJoystick;
        [BoxGroup("JOYSTICKS"), SerializeField] private Joystick _attackJoystick;
        
        public override void Install(IGameUI ui)
        {
            GameContext gameContext = GameContext.Instance;
            
            ui.AddValue(GameUIAPI.AmmoStatView, _ammoStatView);
            ui.AddValue(GameUIAPI.HealthStatView, _healthStatView);
            ui.AddValue(GameUIAPI.ScoreView, _scoreView);
            ui.AddValue(GameUIAPI.HealthScreenView, _healthScreenView);
            ui.AddValue(GameUIAPI.MoveJoystick, new Variable<Joystick>(_moveJoystick));
            ui.AddValue(GameUIAPI.AttackJoystick, new Variable<Joystick>(_attackJoystick));

            ui.AddBehaviour(new HealthStatPresenter(gameContext));
            ui.AddBehaviour(new AmmoStatPresenter(gameContext));
            ui.AddBehaviour(new ScorePresenter(gameContext));
            ui.AddBehaviour(new HealthScreenPresenter(gameContext));
        }
    }
}