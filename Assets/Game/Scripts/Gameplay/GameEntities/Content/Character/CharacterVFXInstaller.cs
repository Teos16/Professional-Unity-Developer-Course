using Atomic.Elements;
using UnityEngine;

namespace Game.Gameplay
{
    public sealed class CharacterVFXInstaller : GameEntityInstaller
    {
        [Header("Effects")]
        [SerializeField] private ParticleSystem _damageEffectVfx;
        [SerializeField] private ParticleSystem _speedEffectVfx;
        [SerializeField] private ParticleSystem _stunEffectVfx;
        [SerializeField] private ParticleSystem _armorEffectVfx;
        [SerializeField] private ParticleSystem _poisonVfx;

        private readonly DisposableComposite _disposables = new();

        public override void Install(IGameEntity entity)
        {
            IReactiveList<Effect> effects = entity.GetEffects();
            effects.SubscribeAdded(effect =>
            {
                if (effect is StunEffect)
                    _stunEffectVfx.Play();
                else if (effect is PoisonEffect)
                    _poisonVfx.Play();
            }).AddTo(_disposables);
            
            effects.SubscribeRemoved(effect =>
            {
                if (effect is StunEffect)
                    _stunEffectVfx.Stop();
                else if (effect is PoisonEffect)
                    _poisonVfx.Stop();
            }).AddTo(_disposables);
            
            //     if (effect is MoveSpeedEffect)
            //         _speedEffectVfx.Play();
            //     else if (effect is DamageEntityEffect)
            //         _damageEffectVfx.Play();
            //     else if (effect is ArmorEffect)
            //         _armorEffectVfx.Play();

            //
            //     if (effect is MoveSpeedEffect)
            //         _speedEffectVfx.Stop();
            //     else if (effect is DamageEntityEffect)
            //         _damageEffectVfx.Stop();
            //     else if (effect is StunEffect)
            //         _stunEffectVfx.Stop();
            //     else if (effect is ArmorEffect)
            //         _armorEffectVfx.Stop();
        }

        public override void Uninstall(IGameEntity entity)
        {
            _disposables.Dispose();
        }
    }
}