using Atomic.Elements;

namespace Game.Gameplay
{
    public sealed class StunEffect : Effect
    {
        private readonly IGameEntity _target;
        
        public StunEffect(EffectConfig config, IGameEntity target) : base(config)
        {
            _target = target;
            IExpression<bool> orExpression = _target.GetIsStunned();
            orExpression.Add(nameof(StunEffect), Constants.True);
        }
        
        protected override void OnComplete()
        {
            _target.GetIsStunned().Remove(nameof(StunEffect));
        }
    }
}