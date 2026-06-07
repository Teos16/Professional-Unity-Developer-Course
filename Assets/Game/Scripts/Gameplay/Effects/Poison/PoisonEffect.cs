using Atomic.Elements;

namespace Game.Gameplay
{
    public sealed class PoisonEffect : Effect
    {
        private readonly Cooldown _period;
        private readonly IValue<int> _damage;
        private readonly IGameEntity _target;

        public PoisonEffect(IGameEntity target, PoisonEffectConfig config) : base(config)
        {
            _target = target;
            _period = new Cooldown(config.Period);
            _damage = config.Damage;
        }

        protected override void OnUpdate(float deltaTime)
        {
            _period.Tick(deltaTime);
            if (_period.IsCompleted())
            {
                _target.GetTakeDamageCommand().Invoke(_damage.Value);
                _period.ResetTime();
            }
        }

        protected override void OnComplete()
        {
        }
    }
}