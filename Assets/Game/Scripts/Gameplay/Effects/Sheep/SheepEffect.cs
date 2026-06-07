using Atomic.Elements;

namespace Game.Gameplay
{
    public sealed class SheepEffect : Effect
    {
        private readonly IGameEntity _target;
        private readonly IValue<float> _speedMultiplier;
        
        public SheepEffect(IGameEntity target, SheepEffectConfig config) : base(config)
        {
            _target = target;
            _speedMultiplier = config.SpeedMultiplier;
            
            _target.GetIsSheep().Value = true;
            _target.GetMoveSpeedMultiplier().Add(_speedMultiplier);
            _target.GetFireCommand().AddCondition(Constants.False);
        }
        
        protected override void OnComplete()
        {
            _target.GetIsSheep().Value = false;
            _target.GetMoveSpeedMultiplier().Remove(_speedMultiplier);
            _target.GetFireCommand().RemoveCondition(Constants.False);
        }
    }
}