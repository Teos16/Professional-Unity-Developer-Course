using Atomic.Elements;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.Gameplay
{
    public abstract class EffectConfig : ScriptableObject, IEffectConfig
    {
        [field: SerializeField]
        public Const<float> Duration { get; private set; }
        
        [Button]
        public bool Apply(IGameEntity target, out Effect effect)
        {
            effect = CanApply(target) ? Create(target) : null;
            return effect != null;
        }
        
        [Button]
        public abstract bool CanApply(IGameEntity target);

        protected abstract Effect Create(IGameEntity target);
    }
}