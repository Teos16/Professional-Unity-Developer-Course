namespace Game.Gameplay
{
    public static class EffectsUseCase
    {
        public static bool CanApplyEffect(this IGameEntity entity, EffectConfig config) => 
            entity != null && config.CanApply(entity);

        public static bool ApplyEffect(this IGameEntity entity, IEffectConfig config)
        {
            if (config is EffectConfigComposite composite)
            {
                foreach (EffectConfig effectConfig in composite.Effects)
                    entity.ApplyEffect(effectConfig);
            }
            else if(config is EffectConfig effectConfig)
            {
                if (!effectConfig.Apply(entity, out Effect effect)) 
                    return false;
                
                entity.GetEffects().Add(effect);
            }
            
            return true;
        }

        public static bool DiscardEffect(this IGameEntity entity, Effect effect)
        {
            return entity.GetEffects().Remove(effect) && effect.Cancel();
        }
    }
}