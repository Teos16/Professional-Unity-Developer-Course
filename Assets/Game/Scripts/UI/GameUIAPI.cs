using Atomic.Elements;
using Atomic.Entities;

namespace Game.UI
{
    public static class GameUIAPI
    {
        public static ValueKey<IGameUI, IVariable<Joystick>> MoveJoystick = new(nameof(MoveJoystick));
        public static ValueKey<IGameUI, IVariable<Joystick>> AttackJoystick = new(nameof(AttackJoystick));
        
        public static ValueKey<IGameUI, StatView> HealthStatView = new(nameof(HealthStatView));
        public static ValueKey<IGameUI, StatView> AmmoStatView = new(nameof(AmmoStatView));
        public static ValueKey<IGameUI, ScoreView> ScoreView = new(nameof(ScoreView));
        public static ValueKey<IGameUI, HealthScreenView> HealthScreenView = new(nameof(HealthScreenView));
    }
}