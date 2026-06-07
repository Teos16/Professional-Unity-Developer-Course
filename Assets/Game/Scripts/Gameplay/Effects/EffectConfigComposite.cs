using UnityEngine;

namespace Game.Gameplay
{
    [CreateAssetMenu(menuName = "Effects/Composite", fileName = "Composite")]
    public sealed class EffectConfigComposite : ScriptableObject, IEffectConfig
    {
        [field: SerializeField] public EffectConfig[] Effects { get; private set; }
    }
}